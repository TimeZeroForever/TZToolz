using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;
using TimeZero.Auction.Bot.Classes.Network.Constants;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Login
{
    public sealed class LoginStep3_Authorization : IActionStep
    {
        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            //Get password key
            Packet data = networkClient.InputQueue.Pop();
            if (data != null)
            {
                string key = data["@s"];

                //Store password key
                client.AdditionalData.Add(ObjectPropertyName.PASSWORD_KEY, key);

                //Get hashed password
                string passwordHash = client.GetPasswordHash(key);

                networkClient.SendLogMessage(
                    string.Format("Trying to login: U = {0}, P = {1}, K = {2}, H = {3}...", 
                    client.Login, client.Password, key, passwordHash));

                //Do login
                string login = Packet.BuildPacket(FromClient.LOGIN_DATA,
                    client.LocalIP, client.Version2, client.Version, passwordHash, client.Login);
                networkClient.SendData(login);

                //Get login result
                data = networkClient.InputQueue.Pop();

                if (data != null)
                {
                    //Check on login error
                    string errorCode = data["@code"];
                    if (errorCode != null)
                    {
                        string errorMessage = Errors.GameError.GetErrorMessage(errorCode);
                        switch (errorCode)
                        {
                            //Should be login to another server
                            case Errors.GameError.E_PLAYER_ON_ANOTHER_SERVER:
                                {
                                    networkClient.ThrowError(errorMessage, false);
                                    break;
                                }
                            //General login error
                            default:
                                {
                                    networkClient.ThrowError(errorMessage);
                                    break;
                                }
                        }
                        return false;
                    }

                    //No errors? Continue...
                    string sessionId = data["@ses"];
                    client.AdditionalData.Add(ObjectPropertyName.SESSION_ID, sessionId);

                    networkClient.SendLogMessage(string.Format("User login successful"));

                    return true;
                }
            }

            networkClient.ThrowError("Failed to login or the connection was terminated");
            return false;
        }

        public void Reset() { }
    }
}
