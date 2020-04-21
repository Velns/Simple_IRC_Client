using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IrcClient
{
    class Program
    {
        static string server;
        static string username;
        static string port;
        static string channel;
        static int pongs = 0;
        static int count = 0;

        static void Main(string[] args)
        {
            SetParameters();
            ircClient irc = new ircClient(server, username);
            irc.joinRoom(channel);
            try
            {
                while (true)
                {
                    string message = irc.readMessage();
                    if (message.Contains("/NAMES list") && message != null)
                    {
                        Console.Title = "Connected to: " + channel + ". Messages: " + count + ". Pongs: " +  pongs;
                        break;
                    }
                }
                Thread t = new Thread(() => readChat(irc));
                t.Start();
                Thread send = new Thread(() => sendMessage(irc));
                send.Start();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: " + x);
            }
            while(true)
            {
                Thread.Sleep(1000);
            }

        }
        static void readChat(ircClient irc)
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
                        Console.Title = "Connected to: " + channel + ". Messages: " + count + ". Pongs: " + pongs;
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
                        Console.Title = "Connected to: " + channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                }
                catch
                {

                }
            }             
        }
        static void sendMessage(ircClient irc)
        {
            while(true)
            {
                string sendingMessage = Console.ReadLine();
                irc.sendChatMessage(sendingMessage);
            }
        }
        static void SetParameters()
        {
            Console.WriteLine("Enter IRC server address:");
            server = "irc.freenode.net";        //Console.ReadLine();
            
            Console.WriteLine("Enter IRC server port:");
            port = "6667";                      //Console.ReadLine();
            

            Console.WriteLine("Enter username:");
            username = "tester_bot_1";          // Console.ReadLine();
            
            Console.WriteLine("Enter channel:");
            channel = "testing_bot";            // Console.ReadLine();
            
            
        }
    }
}
