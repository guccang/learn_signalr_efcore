using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace signalR_client
{
    class MySignalRClient
    {
        HubConnection connection;
        public MySignalRClient()
        {
             connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/myhub")
            .Build();

            connection.Closed += (error) =>
            {
                Console.WriteLine($"closeed {connection}");
                return null;
            };
        }

        public async void Start()
        {
            regist();
            // signalR service call client method
            await connection.StartAsync();

            await connection.InvokeAsync("test");
        }

        private void regist()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"recv from server {user}: {message}";
                Console.WriteLine(newMessage);
            });
        }

        public bool IsDisconnected()
        {
            if (null == connection)
                return true;

            if (connection.State == HubConnectionState.Disconnected)
                return true;

            return false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("client start!!!");

            MySignalRClient client = new MySignalRClient();
            client.Start();

            Thread.Sleep(3000); // 3s
           
            var line = "";
            while (true)
            {
                if (line.Contains("q"))
                    break;
                if (client.IsDisconnected())
                    break;
                if (line.Contains("start"))
                {

                }
                Thread.Sleep(999);
            }
        }
    }
}
