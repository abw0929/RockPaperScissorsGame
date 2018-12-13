using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaperScissorsGame.Game;

namespace RockPaperScissorsGame.Message
{
    public class MessageBase
    {
        public string Header { get; set; }
        public string Id { get; set; }
    }

    public class MessageAllPlayers : MessageBase
    {
        public Player[] Players { get; set; }

    }

    public class MessageNewPlayer : MessageBase
    {
        public Player Player { get; set; }
    }

    public class MessageGameOver : MessageBase
    {
        public Player Player { get; set; }
    }

    public class MessageMove : MessageBase
    {
        public Coordinates From { get; set; }
        public Coordinates To { get; set; }
    }

    public class MessageTalk : MessageBase
    {
        public string Name { get; set; }
        public string Message { get; set; }
    }

    public class MessageError : MessageBase
    {
        public string Message { get; set; }
    }
}