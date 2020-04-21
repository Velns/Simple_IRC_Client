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
        private string userName;
        private string channel;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outpurStream;
        private string address = "";
        private int port = 6667;

        public ircClient(string ip, string userName)
        {
            this.userName = userName;
            tcpClient = new TcpClient(ip, port);
            address = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
            inputStream = new StreamReader(tcpClient.GetStream());
            outpurStream = new StreamWriter(tcpClient.GetStream());
            outpurStream.WriteLine("NICK " + userName);
            outpurStream.WriteLine("USER " + userName + " 8 * " + userName);
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
        
    }
}
