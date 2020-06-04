using IrcClient.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrcClient
{
    class UserStandart : User
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

                if (sendingMessage[0] == '~')
                {
                    switch (sendingMessage.Substring(1, sendingMessage.IndexOf(' ') - 1).ToLower())         // перевірка чи перший символ є службовим
                    {
                        case "addc":
                            {
                                string str = sendingMessage.Substring(sendingMessage.IndexOf(' ') + 1);

                                string folderName = str.Substring(0, str.IndexOf(' '));

                                string contName = str.Remove(0, str.IndexOf(' ') + 1);

                                ContactFolder.Add(new Person(contName), folderName);
                                break;
                            }
                        case "showc":
                            {
                                contacts.Show();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Поки нема такої команди");
                                break;
                            }
                    }
                }          
                    
                else
                    irc.sendChatMessage(sendingMessage);
            }
        }

    }
}
