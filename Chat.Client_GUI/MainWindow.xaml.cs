using System;
using System.Threading.Tasks;
using System.Windows;
using Chat.Lib;
using Chat.Lib.TcpLib;

namespace Chat.Client_GUI
{
    public partial class MainWindow : Window
    {
        private TcpClient server;

        public MainWindow()
        {
            InitConnect();
            InitializeComponent();
            Loaded += (sender, args) => { Dispatcher.Invoke(() =>
            {
                var message = server?.Receive();
                Output.Content += $"{message}\n";
            }); 
            };
        }

        private void InitConnect()
        {
            var config = Config.ReadConfigAsync("config.json").Result ??
                         new Config { IpAddress = "127.0.0.1", Port = 8005 };

            var (ip, port) = config;

            server = new TcpClient(ip, port);
            server.Connect();
        }
    }
}