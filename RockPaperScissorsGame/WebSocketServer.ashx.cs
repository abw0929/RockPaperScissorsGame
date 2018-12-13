using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace RockPaperScissorsGame.WebSocket
{
    /// <summary>
    /// WebSocketServer 的摘要描述
    /// </summary>
    public class WebSocketServer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new MyWebSocket());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}