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
    public class ircClient
    {
        private static ircClient _client;

        public string server { get; private set; }
        public string userName { get; private set; }
        public string channel { get; private set; }
        public TcpClient tcpClient { get; private set; }
        public StreamReader inputStream { get; private set; }
        public StreamWriter outpurStream { get; private set; }
        public int port { get; private set; }



        public static ircClient GetIrcClient(string server, int port, string userName, string channel)
        {
            if (_client == null)
                _client = new ircClient(server, port, userName, channel);
            return _client;
        }
        public void ConnectToServer()
        {
            tcpClient = new TcpClient(server, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outpurStream = new StreamWriter(tcpClient.GetStream());
            outpurStream.WriteLine("NICK " + userName);
            outpurStream.WriteLine("USER " + userName + " 8 * " + userName);
            outpurStream.Flush();
        }
        public void joinRoom()
        {
            outpurStream.WriteLine("JOIN #" + channel);
            outpurStream.Flush();
        }
        public void joinRoom(string channel)
        {
            this.channel = channel;
            outpurStream.WriteLine("JOIN #" + channel);
            outpurStream.Flush();

        }
        public void sendIrcMessage(string message)
        {
            outpurStream.WriteLine(message);
            outpurStream.Flush();

        }
        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + userName + " PRIVMSG #" + channel + " :" + message);
                    }        
        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
        }

        private ircClient(string server, int port, string userName, string channel)
        {
            this.server = server;
            this.port = port;
            this.userName = userName;
            this.channel = channel;
        }

    }
}
