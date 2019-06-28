using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_signalR_efcore.Hubs
{
    public class MyHub : Hub
    {
        ILogger _log;
        public MyHub(ILogger<MyHub> log)
        {
            _log = log;
        }

        public string test()
        {
            sendMessage("test caller.");
            return "hello hub";
        }

        public void sendMessage(string str)
        {
            _log.LogDebug($"sendMessage str");
            Clients.Caller.SendAsync("ReceiveMessage", str, $"hello world {str}");
        }

        public override Task OnConnectedAsync()
        {
            _log.LogDebug("OnConnectedAsync Start, Connected: {0}", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
