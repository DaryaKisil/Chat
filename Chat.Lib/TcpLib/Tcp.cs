using System.Net.Sockets;
using System.Text;

namespace Chat.Lib.TcpLib;

public class Tcp
{
    protected readonly Socket socket;

    protected Tcp()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public Tcp(Socket socket)
    {
        this.socket = socket;
    }

    public void Send(string message)
    {
        var msg = Encoding.UTF8.GetBytes(message);
        socket.Send(msg);
    }

    public string Receive()
    {
        var message = new StringBuilder();
        int bytes = 0;
        var data = new byte[256];
        do
        {
            bytes = socket.Receive(data);
            var msg = Encoding.UTF8.GetString(data, 0, bytes);
            message.Append(msg);
        }
        while (socket.Available > 0);

        return message.ToString();
    }
}