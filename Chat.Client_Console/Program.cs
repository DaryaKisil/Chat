using Chat.Client_Console;
using Chat.Lib;
using Chat.Lib.TcpLib;

var config = await Config.ReadConfigAsync("config.json");

if (config is null)
{
    var _ip = CLI.Input("Введите ip-адрес сервера: ");
    var _port = Convert.ToInt32(CLI.Input("Введите порт сервера: "));
    config = new Config() { IpAddress = _ip, Port = _port };
}

var (ip, port) = config;

var server = new TcpClient(ip, port);
server.Connect();

while (true)
{
    Task.Run(() =>
    {
        var receive = server.Receive();
        CLI.PrintInfo($"[{DateTime.Now:G}] {receive}");
    });

    var message = CLI.Input($"[{DateTime.Now:G}] -> ");
    server.Send(message);
}
