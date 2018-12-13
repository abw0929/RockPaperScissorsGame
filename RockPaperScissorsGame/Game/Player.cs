using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsGame.Game
{
    public class Player
    {
        public string Id;
        public string Name;
        public string Gender;
        public string HairColor;
        public string BodyColor;
        public string IsMe;

        public int Score;
        public string Hand;
        public string Message;

        public Coordinates Pos;

        public Player Clone()
        {
            return (Player)MemberwiseClone();
        }
    }
}