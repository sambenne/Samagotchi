using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Samagotchi.App
{
    public class ServerManager
    {
        private TcpClient _client;
        private readonly string _serverAddress;
        private readonly int _port;

        public ServerManager(string serverAddress, int port)
        {
            _serverAddress = serverAddress;
            _port = port;
        }

        public void Connect()
        {
            _client = new TcpClient(_serverAddress, _port);
            if (_client.Connected)
            {
                Task.Run(Reconnect);
            }
        }

        public void SendMessage(string message)
        {
            var stream = _client.GetStream();
            var writer = new StreamWriter(stream);
            writer.WriteLine(message);
            writer.Flush();
        }

        public void Close()
        {
            SendMessage("EndConnection");
            _client.Close();
        }

        private async Task Reconnect()
        {
            while (true)
            {
                if (!IsConnected())
                {
                    Console.WriteLine("Close Connection");
                    _client.Close();

                    try
                    {
                        Console.WriteLine("Reconnecting...");
                        _client = new TcpClient(AddressFamily.InterNetwork);
                        await _client.ConnectAsync(IPAddress.Parse(_serverAddress), Convert.ToInt16(_port));
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine(e);
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        private bool IsConnected()
        {
            try
            {
                var socket = _client.Client;
                if (!socket.Connected) return false;

                if (!socket.Poll(0, SelectMode.SelectWrite) || socket.Poll(0, SelectMode.SelectError)) return false;

                var buffer = new byte[1];
                return socket.Receive(buffer, SocketFlags.Peek) != 0;

                //https://msdn.microsoft.com/en-us/library/system.net.sockets.socket.poll.aspx
                //This method cannot detect certain kinds of connection problems, such as a broken network cable, or that the remote host was shut down ungracefully. You must attempt to send or receive data to detect these kinds of errors.
            }
            catch (SocketException)
            {
                return false;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }
    }
}
