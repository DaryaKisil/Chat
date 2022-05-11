using System.Net;

namespace Chat.Lib.TcpLib { };

public class TcpClient : Tcp
{
    private string _ip;
    private int _port;

    public TcpClient(string ip, int port) : base()
    {
        _ip = ip;
        _port = port;
    }

    public void Connect()
    {
        var server = new IPEndPoint(IPAddress.Parse(_ip), _port);
        socket.Connect(server);
    }
}