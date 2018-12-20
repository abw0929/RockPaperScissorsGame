using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RockPaperScissorsGame.Game;
using RockPaperScissorsGame.WebSocket;
using Microsoft.Web.WebSockets;

namespace RockPaperScissorsGame.Message
{
    public class MessageControl
    {
        private static readonly WebSocketCollection clients = new WebSocketCollection();
        private static readonly Dictionary<string, MyWebSocket> clientsMap = new Dictionary<string, MyWebSocket>();


        public static bool AddClient(string id, MyWebSocket socket)
        {
            if(!clientsMap.ContainsKey(id))
            {
                clientsMap.Add(id, socket);
                clients.Add(socket);

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveClient(string id)
        {
            if(clientsMap.ContainsKey(id))
            {
                clients.Remove(clientsMap[id]);
                clientsMap.Remove(id);

                return true;
            }
            else
            {
                return false;
            }
        }
        public static void OnMessage(string message)
        {
            MessageBase msgBase = JsonConvert.DeserializeObject<MessageBase>(message);

            switch (msgBase.Header)
            {
                case "NewPlayer":
                    {
                        ReceiveNewPlayer(message);
                        break;
                    }
                case "Move":
                    {
                        ReceiveMove(message);
                        break;
                    }
                case "Talk":
                    {
                        ReceiveTalk(message);
                        break;
                    }
                case "Hand":
                    {
                        ReceiveHand(message);
                        break;
                    }
                case "Score":
                    {
                        ReceiveScore(message);
                        break;
                    }
                case "GameOver":
                    {
                        ReceiveTalk(message);
                        break;
                    }
            }
        }

        public static void OnClose(string id)
        {
            MessageGameOver msg = new MessageGameOver { Header = "GameOver", Id = id };
            GameFlowControl.ReceiveGameOver(msg);
        }

        public static void SendMessage(string message)
        {
            clients.Broadcast(message);
        }

        public static void SendMessage(string id, string message)
        {
            if (clientsMap.ContainsKey(id))
            {
                clientsMap[id].Send(message);
            }
        }

        public static void ReceiveNewPlayer(string message)
        {
            MessageNewPlayer msg = JsonConvert.DeserializeObject<MessageNewPlayer>(message);
            GameFlowControl.ReceiveNewPlayer(msg);
        }

        public static void ReceiveMove(string message)
        {
            MessageMove msg = JsonConvert.DeserializeObject<MessageMove>(message);
            GameFlowControl.ReceiveMove(msg);
        }

        public static void ReceiveTalk(string message)
        {
            MessageTalk msg = JsonConvert.DeserializeObject<MessageTalk>(message);
            GameFlowControl.ReceiveTalk(msg);
        }

        public static void ReceiveHand(string message)
        {
            MessageHand msg = JsonConvert.DeserializeObject<MessageHand>(message);
            GameFlowControl.ReceiveHand(msg);
        }

        public static void ReceiveScore(string message)
        {
            MessageScore msg = JsonConvert.DeserializeObject<MessageScore>(message);
            GameFlowControl.ReceiveScore(msg);
        }

        public static void ReceiveGameOver(string message)
        {
            MessageGameOver msg = JsonConvert.DeserializeObject<MessageGameOver>(message);
            GameFlowControl.ReceiveGameOver(msg);
        }

        public static void SendNewPlayer(MessageNewPlayer message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendNewPlayerOK(MessageNewPlayer message)
        {
            MessageBase newMessage = new MessageBase { Header = "NewPlayerOK", Id = message.Id };
            string jsonMessage = JsonConvert.SerializeObject(newMessage);
            SendMessage(message.Id, jsonMessage);
        }

        public static void SendNewPlayerFail(MessageNewPlayer message)
        {
            MessageBase newMessage = new MessageBase { Header = "NewPlayerFail", Id = message.Id };
            string jsonMessage = JsonConvert.SerializeObject(newMessage);
            SendMessage(message.Id, jsonMessage);
        }

        public static void SendAllPlayers(MessageAllPlayers message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(message.Id, jsonMessage);
        }

        public static void SendMove(MessageMove message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendTalk(MessageTalk message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendHand(MessageHand message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendScore(MessageScore message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendGameOver(MessageGameOver message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

        public static void SendError(MessageError message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            SendMessage(jsonMessage);
        }

    }
}