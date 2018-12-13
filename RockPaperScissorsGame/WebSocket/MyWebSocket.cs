using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using RockPaperScissorsGame.Game;
using RockPaperScissorsGame.Message;
using Newtonsoft.Json.Linq;

namespace RockPaperScissorsGame.WebSocket
{
    public class MyWebSocket : WebSocketHandler
    {
        private string Id;
        public override void OnOpen()
        {
            Id = Guid.NewGuid().ToString();
            bool ret = MessageControl.AddClient(Id, this);

            if(!ret)
            {
                Close();
            }
        }

        public override void OnMessage(string message)
        {
            message = SetMessageId(message);
            MessageControl.OnMessage(message);
        }

        public override void OnClose()
        {
            MessageControl.OnClose(Id);
            MessageControl.RemoveClient(Id);
        }

        public override void OnError()
        {
            MessageControl.SendError(new MessageError { Header = "Error", Message = Error.Message });
        }

        private string SetMessageId(string message)
        {
            JObject jObj = JObject.Parse(message);
            jObj["Id"] = Id;
            return jObj.ToString();
        }

        
    }
}