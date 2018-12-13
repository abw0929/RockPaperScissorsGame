using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsGame.Game
{
    public class PlayerControl
    {
        private readonly Dictionary<string, Player> playersMap = new Dictionary<string, Player>();
        private readonly Dictionary<string, string> playerNames = new Dictionary<string, string>();

        public bool Add(string id, Player player)
        {
            if (playersMap.ContainsKey(id) || playerNames.ContainsKey(player.Name))
            {
                return false;
            }
            else
            {
                playersMap.Add(id, player);
                playerNames.Add(player.Name, id);

                return true;
            }
        }

        public void Remove(string id)
        {
            if(playersMap.ContainsKey(id))
            {
                playerNames.Remove(playersMap[id].Name);
                playersMap.Remove(id);
            }
        }

        public Player[] GetAll()
        {
            List<Player> tempList = new List<Player>();
            foreach (KeyValuePair<string, Player> player in playersMap)
            {
                tempList.Add(player.Value);
            }

            return tempList.ToArray();
        }

        public Player[] GetAll(string id)
        {
            List<Player> tempList = new List<Player>();
            foreach (KeyValuePair<string, Player> player in playersMap)
            {
                Player tempPlayer = player.Value.Clone();
                if (tempPlayer.Id == id)
                    tempPlayer.IsMe = "True";
                else
                    tempPlayer.IsMe = "False";

                tempList.Add(tempPlayer);
            }

            return tempList.ToArray();
        }

        public Player GetPlayer(string id)
        {
            if (playersMap.ContainsKey(id))
                return playersMap[id];
            else
                return null;
        }

        public void OnTalk(string id, string text)
        {
            if (playersMap.ContainsKey(id))
                playersMap[id].Message = text;
        }

        public void OnMove(string id, Coordinates pos)
        {
            if (playersMap.ContainsKey(id))
                playersMap[id].Pos = pos;
        }

        public string GetNameById(string id)
        {
            if (playersMap.ContainsKey(id))
                return playersMap[id].Name;
            else
                return "";
        }
    }
}