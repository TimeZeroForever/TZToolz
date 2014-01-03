﻿using System;
using System.Collections.Generic;
using System.Media;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.Constants;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameStep_IMS : IActionStep
    {
        private readonly SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.ims);

        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            List<string> messages = new List<string>();

            Packet[] packets = networkClient.InputQueue.PopAll(FromServer.IMS);
            foreach (Packet packet in packets)
            {
                string sMessages = packet["@m"];
                messages.AddRange(sMessages.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
            }

            if (messages.Count > 0)
            {
                networkClient.OnLogMessage(string.Format("Instant message(s), {0} received:", messages.Count));
                foreach (string message in messages)
                {
                    string logMessage;

                    string[] messageParts = message.Split('\t');

                    //Switch IMS command type
                    switch (messageParts[1])
                    {
                        //Private IM
                        case "100":
                            {
                                logMessage = string.Format("\t• {0}. Private from '{1}': {2}",
                                    messageParts[0], messageParts[2], messageParts[3]);
                                break;
                            }
                        //Shop message
                        case "217":
                            {
                                logMessage = string.Format("\t• {0}. Was received Coins[{1}] from '{2}'. Target: {3}",
                                    messageParts[0], messageParts[3], messageParts[4], messageParts[6]);
                                break;
                            }
                        default:
                            {
                                logMessage = message;
                                break;
                            }
                    }

                    //Play alert
                    _soundPlayer.Play();

                    networkClient.OnLogMessage(logMessage);
                }

                //Clear all IMS on server
                string clearIMS = Packet.BuildPacket(FromClient.CLEAR_IMS);
                networkClient.SendData(clearIMS);

                return true;
            }
            return false;
        }

        public void Reset() { }
    }
}