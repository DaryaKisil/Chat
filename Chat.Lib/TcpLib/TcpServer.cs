using System.Net;
using System.Net.Sockets;

namespace Chat.Lib.TcpLib;

public class TcpServer : Tcp
{
    private string _ip;
    private int _port;
    
    public TcpServer(string ip, int port) : base()
    {
        _ip = ip;
        _port = port;
    }

    public void Init()
    {
        var end_point = new IPEndPoint(IPAddress.Parse(_ip), _port);

        socket.Bind(end_point);
        socket.Listen(10);
    }

    public Tcp ClientConnection()
    {
        return new Tcp(socket.Accept());
    }
}