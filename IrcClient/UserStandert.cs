using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrcClient
{
    class UserStandert : User
    {
        public override void InitializeReaderAndWriter()
        {
            try
            {
                Console.WriteLine("Connecting..");
                while (true)
                {
                    string inputStr = _irc.readMessage();
                    if (inputStr.Contains("/NAMES list") && inputStr != null)
                    {
                        Console.Title = "Connected to: " + _irc.server + " #" + _irc.channel;
                        break;
                    }

                    Console.WriteLine(inputStr);
                }
                Console.WriteLine("Conected");

                Thread readeThread = new Thread(() => ReadingStreams(_irc));
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
        public override void ReadingStreams(ircClient irc)
        {      

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
                                               
                        count++;

                        ShowMessage();
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
