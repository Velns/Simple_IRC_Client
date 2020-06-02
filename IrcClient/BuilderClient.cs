using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrcClient
{
    class BuilderClient : Builder
    {
        private static int pongs = 0;
        private static int count = 0;
        private IFactory factory = new ReceivedMessageFactory();

        public override void InitializeReaderAndWriter()
        {
            try
            {
                Console.WriteLine("Connecting..");
                while (true)
                {
                    string message = _irc.readMessage();
                    if (message.Contains("/NAMES list") && message != null)
                    {
                        Console.Title = "Connected to: " + _irc.server + " #" + _irc.channel + ". Messages: " + count + ". Pongs: " + pongs;
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
        public override void ReadingChat(ircClient irc)
        {
            IMessage message;
            while (true)
            {
                try
                {
                    string inputStr = irc.readMessage();
                    if (inputStr.Contains("PING"))
                    {
                        irc.sendIrcMessage(inputStr.Replace("PING", "PONG"));
                        Console.WriteLine("PONG message sent");
                        pongs++;
                        Console.Title = "Connected to: " + _irc.channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                    else if (inputStr != null)
                    {
                        byte[] data = Encoding.Unicode.GetBytes(inputStr);
                        var messageFactory = new Message(factory, irc, inputStr);
                        message = messageFactory.message;

                       
                        Console.Write(message.Time.ToString("HH:mm tt("));
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(message.UserName);
                        Console.ResetColor();
                        Console.WriteLine(") " + message.Text);
                        count++;
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
                irc.sendChatMessage(sendingMessage);
            }
        }

    }
}
