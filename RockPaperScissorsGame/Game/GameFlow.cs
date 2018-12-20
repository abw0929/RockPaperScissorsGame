using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaperScissorsGame.Message;

namespace RockPaperScissorsGame.Game
{
    public class GameFlow
    {

        private static readonly PlayerControl playerControl = new PlayerControl();

        public static void OnNewPlayer(MessageNewPlayer msg)
        {
            Player newPlayer = msg.Player;
            newPlayer.Id = msg.Id;
            bool ret = playerControl.Add(msg.Id, newPlayer);

            if (ret)
            {
                MessageAllPlayers msgAllPlayers = new MessageAllPlayers
                {
                    Header = "AllPlayers",
                    Id = msg.Id,
                    Players = playerControl.GetAll(msg.Id)
                };
                GameFlowControl.SendNewPlayer(msg);
                GameFlowControl.SendNewPlayerOK(msg);
                GameFlowControl.SendAllPlayers(msgAllPlayers);
            }
            else
            {
                GameFlowControl.SendNewPlayerFail(msg);
            }
        }

        public static void OnMove(MessageMove msg)
        {
            playerControl.OnMove(msg.Id, msg.To);
            GameFlowControl.SendMove(msg);
        }

        public static void OnTalk(MessageTalk msg)
        {
            msg.Name = playerControl.GetNameById(msg.Id);
            playerControl.OnTalk(msg.Id, msg.Message);
            GameFlowControl.SendTalk(msg);
        }

        public static void OnHand(MessageHand msg)
        {
            msg.Name = playerControl.GetNameById(msg.Id);
            playerControl.OnHand(msg.Id, msg.Hand);
            GameFlowControl.SendHand(msg);
        }

        public static void OnScore(MessageScore msg)
        {
            msg.Name = playerControl.GetNameById(msg.Id);
            playerControl.OnScore(msg.Id, msg.Score);
            GameFlowControl.SendScore(msg);
        }

        public static void OnGameOver(MessageGameOver msg)
        {
            if (msg.Player == null)
                msg.Player = playerControl.GetPlayer(msg.Id);

            playerControl.Remove(msg.Id);
            GameFlowControl.SendGameOver(msg);
        }
    }
}