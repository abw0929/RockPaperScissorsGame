using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using RockPaperScissorsGame.WebSocket;
using RockPaperScissorsGame.Message;

namespace RockPaperScissorsGame.Game
{
    public class GameFlowControl
    {

        public static void ReceiveNewPlayer(MessageNewPlayer msg)
        {
            GameFlow.OnNewPlayer(msg);
        }
        public static void ReceiveMove(MessageMove msg)
        {
            GameFlow.OnMove(msg);
        }

        public static void ReceiveTalk(MessageTalk msg)
        {
            GameFlow.OnTalk(msg);
        }

        public static void ReceiveHand(MessageHand msg)
        {
            GameFlow.OnHand(msg);
        }

        public static void ReceiveScore(MessageScore msg)
        {
            GameFlow.OnScore(msg);
        }

        public static void ReceiveGameOver(MessageGameOver msg)
        {
            GameFlow.OnGameOver(msg);
        }

        public static void SendNewPlayer(MessageNewPlayer msg)
        {
            MessageControl.SendNewPlayer(msg);
        }

        public static void SendAllPlayers(MessageAllPlayers msg)
        {
            MessageControl.SendAllPlayers(msg);
        }

        public static void SendNewPlayerOK(MessageNewPlayer msg)
        {
            MessageControl.SendNewPlayerOK(msg);
        }

        public static void SendNewPlayerFail(MessageNewPlayer msg)
        {
            MessageControl.SendNewPlayerFail(msg);
        }

        public static void SendTalk(MessageTalk msg)
        {
            MessageControl.SendTalk(msg);
        }

        public static void SendHand(MessageHand msg)
        {
            MessageControl.SendHand(msg);
        }

        public static void SendScore(MessageScore msg)
        {
            MessageControl.SendScore(msg);
        }

        public static void SendMove(MessageMove msg)
        {
            MessageControl.SendMove(msg);
        }

        public static void SendGameOver(MessageGameOver msg)
        {
            MessageControl.SendGameOver(msg);
        }

    }
}