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

            connection.Closed += async (error) =>
            {
                Console.WriteLine($"closeed {connection}");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
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

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MySignalRClient client = new MySignalRClient();
            client.Start();

            var line = "";
            while (true)
            {
                if (line.Contains("q"))
                    break;
                if(line.Contains("start"))
                {
                  
                }
                Thread.Sleep(1000);
            }
        }
    }
}
