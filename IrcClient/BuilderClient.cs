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
