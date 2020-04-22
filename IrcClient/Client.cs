using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrcClient
{
    class Client
    {
        private static ircClient _irc;

        private static string _server;
        private static string _userName;
        private static string _channel;
        private static int _port;

        private static int pongs = 0;
        private static int count = 0;

        static void ChangeParametersServer()
        {
            Console.WriteLine("Enter IRC server address:");
            _server =    "irc.freenode.net";        
                        // Console.ReadLine();

            Console.WriteLine("Enter IRC server port:");
            _port = 6667;                        
                   // Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter username:");
            _userName =  "tester_bot_1";         
                        // Console.ReadLine();

            Console.WriteLine("Enter channel:");
            _channel =   "testing_bot";            
                        // Console.ReadLine();

            _irc = ircClient.GetIrcClient(_server, _port, _userName, _channel);
        }

        public void Start()
        {
            ChangeParametersServer();
            _irc.ConnectToServer();
            _irc.joinRoom();
            InitializeReaderAndWriter();
        }
        private void InitializeReaderAndWriter()
        {
            try
            {
                Console.WriteLine("Connecting..");

                while (true)
                {
                    string message = _irc.readMessage();
                    if (message.Contains("/NAMES list") && message != null)
                    {
                        Console.Title = "Connected to: " + _channel + ". Messages: " + count + ". Pongs: " + pongs;
                        break;
                    }
                }

                Console.WriteLine("Conected");

                Thread readeThread = new Thread(() => ReadingChat(_irc));
                readeThread.Start();

                Thread writeThread = new Thread(() => SendingMessage(_irc));
                writeThread.Start();

            }
            catch (Exception x)
            {
                Console.WriteLine("Error: " + x);
            }
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
        static void ReadingChat(ircClient irc)
        {

            while (true)
            {
                try
                {
                    string message = irc.readMessage();
                    if (message.Contains("PING"))
                    {
                        irc.sendIrcMessage(message.Replace("PING", "PONG"));
                        Console.WriteLine("PONG message sent");
                        pongs++;
                        Console.Title = "Connected to: " + _channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                    else if (message != null)
                    {
                        var offset = message.IndexOf(':');
                        var result = message.IndexOf(':', offset + 1);
                        string userName = message.Substring(1, message.IndexOf("!") - 1);
                        message = message.Substring(result + 1);

                        Console.Write(DateTime.Now.ToString("HH:mm tt("));
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(userName);
                        Console.ResetColor();
                        Console.WriteLine(") " + message);
                        count++;
                        Console.Title = "Connected to: " + _channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                }
                catch
                {

                }
            }
        }
        static void SendingMessage(ircClient irc)
        {
            while (true)
            {
                string sendingMessage = Console.ReadLine();
                irc.sendChatMessage(sendingMessage);
            }
        }

    }
}
