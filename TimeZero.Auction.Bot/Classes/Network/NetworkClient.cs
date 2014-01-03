using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.Acitons;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Game;
using TimeZero.Auction.Bot.Classes.Network.Acitons.GameSystem;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Login;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network
{
    public delegate void OnData(string data);
    public delegate void OnNetworkActivity(int dataLength);
    public delegate void OnLogMessage(string message);
    
    public delegate void OnActionStepStarted(IActionStep actionStep);
    public delegate void OnActionStepCompleted(IActionStep actionStep, bool done);

    public sealed class NetworkClient : IDisposable
    {

#region Constants

        private const int GAME_ACTIONS_PREIOD_MS = 500; //In milliseconds, 500 msec

#endregion

#region Static private fields

        private static readonly string LogSeparator1 = new string('-', 155);
        private static readonly string LogSeparator2 = new string('=', 77);

        private static readonly IActionStep[] LoginSteps = new IActionStep[]
            {
                 new LoginStep1_Greeting()
                ,new LoginStep2_ConnectToGameServer()
            };

        private static readonly IActionStep[] AuthorizationSteps = new IActionStep[]
            {
                 new LoginStep3_Authorization()
                ,new LoginStep4_GetMe()
                ,new LoginStep5_StartChat()
            };

        private static readonly IActionStep[] GameSystemSteps = new IActionStep[]
            {
                 new GameSystemStep_Ping()
                ,new GameSystemStep_Errors()
            };

        private static readonly IActionStep[] GameSteps = new IActionStep[]
            {
                 new GameStep_IMS()
                ,new GameStep_GC()
                ,new GameStep_JoinInventory()
                ,new GameStep_Shopping()
                ,new GameStep_Selling()
            };

        private static readonly IActionStep[][] ActionStepsList = new[]
            {
                LoginSteps,
                AuthorizationSteps,
                GameSystemSteps,
                GameSteps
            };

        private static readonly Regex _regexPacketData = new Regex(@"(?s+)^(?:<(.*?)[ |>].*?</(\1)>|<(.(?!<))+?/>)");

#endregion

#region Events

        public OnLogMessage OnLogMessage { get; set; }

        public OnData OnDataReceived { get; set; }
        public OnData OnDataSended { get; set; }

        public OnNetworkActivity OnNetworkActivityIn { get; set; }
        public OnNetworkActivity OnNetworkActivityOut { get; set; }

        public Action OnConnected { get; set; }
        public Action OnDisconnected { get; set; }

        public OnActionStepStarted OnActionStepStarted { get; set; }
        public OnActionStepCompleted OnActionStepCompleted { get; set; }

#endregion

#region Private fields

        private string _server;
        private int _port;
        private int _chatServerPort;

        private GameClient _client;

        private TcpClient _tcpClient;
        private NetworkStream _networkStream;

        private TcpClient _chatTcpClient;
        private NetworkStream _chatNetworkStream;

        private Thread _dataThread;
        private Thread _clientThread;
        private Thread _sysThread;
        private Thread _chatThread;

        private int _connected;
        private volatile bool _terminated;
        private volatile bool _intermediateState;

        private ProtoPacketsQueue _inputQueue = new ProtoPacketsQueue();

#endregion

#region Properties

        public bool Connected
        {
            get { return _connected == 1; }
        }

        public string CurrentGameServer { get; private set; }

        public ProtoPacketsQueue InputQueue
        {
            get { return _inputQueue; }
        }

        public bool OutLogs { get; set; }

        public bool OutDetailedLogs { get; set; }

        internal int LastSendDataTime { get; private set; } 

#endregion

#region Class methods

        public NetworkClient()
        {
            OutLogs = true;
        }

        public NetworkClient(string server, int port, int chatServerPort)
            : this()
        {
            Init(server, port, chatServerPort);
        }

        public void Init(string server, int port, int chatServerPort)
        {
            _server = server;
            _port = port;
            _chatServerPort = chatServerPort;
        }

        public void SendLogMessage(string message)
        {
            if (OutLogs && OnLogMessage != null)
            {
                OnLogMessage(message);
            }
        }

        public void ThrowError(string errorMessage)
        {
            ThrowError(errorMessage, true);
        }

        public void ThrowError(string errorMessage, bool disconnect)
        {
            SendLogMessage("ERROR: " + errorMessage);
            if (disconnect)
            {
                Disconnect();
            }
        }

#endregion

#region Network methods

        #region Connection

        public bool Connect(GameClient client)
        {
            try
            {
                if (!_intermediateState)
                {
                    SendLogMessage("Trying to establish connection...");
                }

                //Terminate current connection
                Disconnect();

                //Establish TCP connection
                _tcpClient = new TcpClient { ReceiveBufferSize = 100000 };
                _tcpClient.Connect(_server, _port);
                _networkStream = _tcpClient.GetStream();

                //Create data thread
                _dataThread = new Thread(() => ReceiveData(_tcpClient, _networkStream));
                _dataThread.Start();

                //Assign variables
                _client = client;
                _connected = 1;

                //Fire OnConnected event
                if (!_intermediateState && OnConnected != null)
                {
                    OnConnected();
                }

                SendLogMessage("A connection was successfully established");
            }
            catch (Exception ex)
            {
                SendLogMessage(string.Format("CONNECTION ERROR: {0}\r\n", ex));
                _connected = 0;
            }

            //Done
            return Connected;
        }

        public bool ConnectToGameServer(string server)
        {
            //Set intermediate state on
            _intermediateState = true;

            //Store greeting server address and set game server address
            string greetingServer = _server;
            _server = server;

            //Connect to the game server
            bool result = Connect(_client);
            if (result)
            {
                CurrentGameServer = server;
            }

            //Restore greeting server address
            _server = greetingServer;

            //Set intermediate state off
            _intermediateState = false;

            //Done
            return result;
        }

        private void ResetActionSteps()
        {
            foreach (IActionStep[] actionSteps in ActionStepsList)
            {
                foreach (IActionStep actionStep in actionSteps)
                {
                    actionStep.Reset();
                }
            }
        }

        public void Disconnect()
        {
            if (Interlocked.CompareExchange(ref _connected, 0, 1) == 1)
            {
                _terminated = true;
                try
                {
                    //Stop chat
                    StopChat();

                    //Break WaitForData execution inside the queue
                    _inputQueue.Terminate();

                    //Terminate data thread
                    if (_dataThread != null && _dataThread.IsAlive &&
                        Thread.CurrentThread != _dataThread)
                    {
                        _dataThread.Abort();
                        _dataThread.Join();
                        _dataThread = null;
                    }

                    //Terminate sys. commands thread
                    if (_sysThread != null && _sysThread.IsAlive &&
                        Thread.CurrentThread != _sysThread)
                    {
                        _sysThread.Abort();
                        _sysThread.Join();
                        _sysThread = null;
                    }

                    //Terminate client thread
                    if (_clientThread != null && _clientThread.IsAlive &&
                        Thread.CurrentThread != _clientThread)
                    {
                        _clientThread.Abort();
                        _clientThread.Join();
                        _clientThread = null;
                    }

                    //Free the network stream and close existing connection
                    _networkStream.Dispose();
                    _tcpClient.Close();
                }
                catch (Exception ex)
                {
                    SendLogMessage(string.Format("DISCONNECTION ERROR: {0}\r\n", ex));
                }
                finally
                {
                    //Reset variables
                    _terminated = false;
                    CurrentGameServer = null;

                    if (!_intermediateState)
                    {
                        //Clear input queue
                        _inputQueue = new ProtoPacketsQueue();

                        //Reset client data
                        _client.Reset();

                        //Reset all action steps
                        ResetActionSteps();

                        //Fire OnDisconnected event
                        if (OnDisconnected != null)
                        {
                            OnDisconnected();
                        }

                        SendLogMessage(string.Format("Disconnected from the server\r\n{0}\r\n",
                            LogSeparator2));
                    }
                }
            }
        }

        #endregion

        #region Login

        public void Login()
        {
            //Create client thread
            _clientThread = new Thread(DoLogin);
            _clientThread.Start();
        }

        private void DoLogin()
        {
            try
            {
                //Do login steps
                foreach (IActionStep loginStep in LoginSteps)
                {
                    loginStep.DoStep(this, _client);
                    if (_terminated)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    SendLogMessage(string.Format("LOGIN ERROR: {0}\r\n", ex));
                    Disconnect();
                }
            }
        }

        #endregion

        #region Authorization

        public bool DoAuthorization()
        {
            try
            {
                //Do authorization steps
                foreach (IActionStep authorizationStep in AuthorizationSteps)
                {
                    if (_terminated || !authorizationStep.DoStep(this, _client))
                    {
                        return false;
                    }
                }

                //Play the game
                PlayGame();

                return true;
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    SendLogMessage(string.Format("AUTHORIZATION ERROR: {0}\r\n", ex));
                    Disconnect();
                }
                return false;
            }
        }

        #endregion

        #region Game

        public void PlayGame()
        {
            SendLogMessage(string.Format("{0}", LogSeparator1));

            //Create client thread
            _sysThread = new Thread(DoSysCommands);
            _sysThread.Start();
            
            //Create client thread
            _clientThread = new Thread(DoPlayGame);
            _clientThread.Start();
        }

        private void DoSysCommands()
        {
            try
            {
                while (!_terminated && _tcpClient.Connected)
                {
                    foreach (IActionStep step in GameSystemSteps)
                    {
                        //Do current step
                        step.DoStep(this, _client);

                        //Check is the process was terminated?
                        if (_terminated)
                        {
                            return;
                        }
                    }
                    Thread.Sleep(GAME_ACTIONS_PREIOD_MS);
                }
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    SendLogMessage(string.Format("SYSCOMMAND ERROR: {0}\r\n", ex));
                    Disconnect();
                }
            }
        }

        private void DoPlayGame()
        {
            try
            {
                while (!_terminated && _tcpClient.Connected)
                {
                    foreach (IActionStep step in GameSteps)
                    {
                        if (step.IsReadyForAction)
                        {
                            //Fire OnActionStepStarted event
                            if (OnActionStepStarted != null)
                            {
                                OnActionStepStarted(step);
                            }

                            //Do current step
                            bool result = step.DoStep(this, _client);

                            //Check is the process was terminated?
                            if (_terminated)
                            {
                                return;
                            }

                            //Fire OnActionStepCompleted event
                            if (OnActionStepCompleted != null)
                            {
                                OnActionStepCompleted(step, result);
                            }
                        }
                    }
                    Thread.Sleep(GAME_ACTIONS_PREIOD_MS);
                }
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    SendLogMessage(string.Format("GAME ERROR: {0}\r\n", ex));
                    Disconnect();
                }
            }
        }

        #endregion

        #region Chat

        public bool StartChat(string chatServer, string sessionId)
        {
            if (_chatTcpClient == null)
            {
                try
                {
                    //Establish TCP connection
                    _chatTcpClient = new TcpClient { ReceiveBufferSize = 100000 };
                    _chatTcpClient.Connect(chatServer, _chatServerPort);
                    _chatNetworkStream = _chatTcpClient.GetStream();

                    //Create data thread
                    _chatThread = new Thread(() => ReceiveData(_chatTcpClient, _chatNetworkStream));
                    _chatThread.Start();

                    return true;
                }
                catch (Exception ex)
                {
                    SendLogMessage(string.Format("CHAT ERROR: {0}\r\n", ex));
                    _connected = 0;
                }
            }
            return false;
        }

        public void StopChat()
        {
            if (_chatTcpClient != null)
            {
                try
                {
                    //Terminate chat thread
                    if (_chatThread != null && _chatThread.IsAlive &&
                        Thread.CurrentThread != _chatThread)
                    {
                        _chatThread.Abort();
                        _chatThread.Join();
                        _chatThread = null;
                    }

                    //Free the network stream and close existing connection
                    _chatNetworkStream.Dispose();
                    _chatTcpClient.Close();
                }
                catch (Exception ex)
                {
                    SendLogMessage(string.Format("CHAT STOPPING ERROR: {0}\r\n", ex));
                }
                finally
                {
                    //Reset variables
                    _chatThread = null;
                    _chatTcpClient = null;
                    _chatNetworkStream = null;
                    SendLogMessage("Chat was stopped");
                }
            }
        }

        #endregion

        #region Data

        public void SendData(string data)
        {
            SendData(_networkStream, data);
        }

        public void SendChatData(string data)
        {
            if (_chatNetworkStream != null)
            {
                SendData(_chatNetworkStream, data);
            }
        }

        //Possible POP packet deadlock if data sending will failed 
        private void SendData(NetworkStream networkStream, string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    byte[] byteBuffer = Encoding.UTF8.GetBytes(data);
                    int dataLength = byteBuffer.Length;
                    networkStream.Write(byteBuffer, 0, dataLength);
                    LastSendDataTime = Environment.TickCount;

                    //Fire OnDataSended event
                    if (OutDetailedLogs && OnDataSended != null)
                    {
                        OnDataSended(data);
                    }

                    //Fire OnNetworkActivityOut event
                    if (OnNetworkActivityOut != null)
                    {
                        OnNetworkActivityOut(dataLength);
                    }
                }
            }
            catch (Exception ex)
            {
                SendLogMessage(string.Format("DATA SEND ERROR: {0}\r\n", ex));
                Disconnect();
            }
        }

        private void ProcessPacket(StringBuilder dataPart, StringBuilder bufferedDataPart)
        {
            if (bufferedDataPart.Length >  0)
            {
                dataPart.Insert(0, bufferedDataPart);
            }
            Match match;
            string data = dataPart.ToString();
            while ((match = _regexPacketData.Match(data)).Success)
            {
                Packet packet = new Packet(match.Value);
                _inputQueue.Push(packet);
                data = data.Remove(0, match.Length);
            }
            bufferedDataPart.Length = 0;
            if (data.Length > 0)
            {
                bufferedDataPart.Append(data);
            }
            dataPart.Length = 0;
        }

        private void ReceiveData(TcpClient tcpClient, NetworkStream networkStream)
        {
            StringBuilder dataPart = new StringBuilder();
            StringBuilder bufferedDataPart = new StringBuilder();
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize * 2];

            while (!_terminated && tcpClient.Connected)
            {
                try
                {
                    if (networkStream.DataAvailable)
                    {
                        //Read received data from net. buffer
                        int dataSize = _tcpClient.Available;
                        if (dataSize == 0)
                        {
                            continue;
                        }

                        networkStream.Read(buffer, 0, dataSize);

                        //Ingnore 'players in the room' packets
                        if (buffer[0] == '\x4')
                        {
                            continue;
                        }

                        //Received data to string and trim junk data
                        string data = Encoding.UTF8.GetString(buffer, 0, dataSize).
                            Replace("\0",       "").    //Extra zero
                            Replace("\x1",      "\" "). //0x1   -> " 
                            Replace("\x4",      ">").   //0x4   -> >
                            Replace("\x6",      "\" "). //0x6   -> " 
                            Replace("\x1\x46",  "=");   //0x1+F -> =
                        dataPart.Append(data);

                        //Process packet
                        ProcessPacket(dataPart, bufferedDataPart);

                        //Fire OnDataReceived event
                        if (OutDetailedLogs && OnDataReceived != null)
                        {
                            OnDataReceived(data);
                        }

                        //Fire OnNetworkActivityIn event
                        if (OnNetworkActivityIn != null)
                        {
                            OnNetworkActivityIn(dataSize);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
                }
                catch (Exception ex)
                {
                    if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                    {
                        SendLogMessage(string.Format("DATA RECEIVE ERROR: {0}\r\n", ex));
                        Disconnect();
                    }
                    return;
                }
            }
        }

        #endregion

#endregion

#region IDisposable

        public void Dispose()
        {
            Disconnect();
        }

#endregion

    }
}
