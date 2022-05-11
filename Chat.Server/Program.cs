using System.Collections.Concurrent;
using System.Net;
using Chat.Lib;
using Chat.Lib.TcpLib;

var config = await Config.ReadConfigAsync("config.json") ?? new Config { IpAddress = IPAddress.Loopback.ToString(), Port = 8005 };

var (ip, port) = config;

var clients = new ConcurrentBag<Tcp>();

var server = new TcpServer(ip, port);
server.Init();

while (true)
{
    var client = server.ClientConnection();
    clients.Add(client);

    Task.Run(() =>
    {
        while (true)
        {
            var message = client.Receive();

            foreach (var _client in clients)
            {
                _client.Send($"{message}");
            }
        }
    });

    
}