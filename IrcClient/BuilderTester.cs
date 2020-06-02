using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrcClient
{
    class BuilderTester : Builder
    {
        private static int pongs = 0;
        private static int count = 0;

        public override void ConnectToServer()
        {
            Console.WriteLine("Connecting To Server {0}", _irc.server);
            Console.WriteLine("To skeep press [s]..");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    {
                        break;
                    }
                default:
                    _irc.ConnectToServer();
                    break;
            }
            
        }
        public override void JoinRoom()
        {
            Console.WriteLine("Connecting To Room {0}", _irc.channel);
            Console.WriteLine("To skeep press [s]..");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    {
                        break;
                    }
                default:
                    _irc.joinRoom();
                    break;
            }
            
        }

        public override void InitializeReaderAndWriter()
        {
            try
            {
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
        public override void ReadingChat(ircClient irc)
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
                        Console.Title = "Connected to: " + _irc.channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                    else if (message != null)
                    {
                        
                        Console.WriteLine(message);
                        Console.Title = "Connected to: " + _irc.channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                }
                catch
                {

                }
            }
        }
        public override void SendingMessage(ircClient irc)
        {
            while (true)
            {
                string sendingMessage = Console.ReadLine();
                irc.sendIrcMessage(sendingMessage);
            }
        }

    }
}
