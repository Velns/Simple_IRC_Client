using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace IrcClient
{
    class ircClient
    {
        private static ircClient _client;

        private string _server;
        private string _userName;
        private string _channel;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outpurStream;
        private int _port;

       

        public static ircClient GetIrcClient(string server, int port, string userName, string channel)
        {
            if (_client == null)
                _client = new ircClient(server, port, userName, channel);
            return _client;
        }
        public void ConnectToServer()
        {
            tcpClient = new TcpClient(_server, _port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outpurStream = new StreamWriter(tcpClient.GetStream());
            outpurStream.WriteLine("NICK " + _userName);
            outpurStream.WriteLine("USER " + _userName + " 8 * " + _userName);
            outpurStream.Flush();
        }
        public void joinRoom()
        {
            outpurStream.WriteLine("JOIN #" + _channel);
            outpurStream.Flush();
        }
        public void joinRoom(string channel)
        {
            _channel = channel;
            outpurStream.WriteLine("JOIN #" + _channel);
            outpurStream.Flush();

        }
        public void sendIrcMessage(string message)
        {
            outpurStream.WriteLine(message);
            outpurStream.Flush();

        }
        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + _userName + " PRIVMSG #" + _channel + " :" + message);
                    }        
        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
        }

        private ircClient(string server, int port, string userName, string channel)
        {
            _server = server;
            _port = port;
            _userName = userName;
            _channel = channel;
        }

    }
}
