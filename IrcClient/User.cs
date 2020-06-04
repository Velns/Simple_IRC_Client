using IrcClient.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient
{
    abstract class User
    {
        public ContactFolder contacts = Serializer.LoadContacts();
        public static int pongs { get; set; } = 0;
        public static int count { get; set; } = 0;
        public IFactory factory { get; } = new ReceivedMessageFactory();
        public IMessage message { get; set; }
        public ircClient _irc { get; private set; }
        public void StartClient()
        {
            ChangeParametersServer();
            ConnectToServer();
            JoinRoom();
            InitializeReaderAndWriter();
        }
        public void ChangeParametersServer()
        {
            Console.WriteLine("Enter IRC server address:");
           string  _server = "irc.freenode.net";
            // Console.ReadLine();

            Console.WriteLine("Enter IRC server port:");
            int _port = 6667;
            // Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter username:");
            string _userName = "tester_bot_1";
            // Console.ReadLine();

            Console.WriteLine("Enter channel:");
            string _channel = "testing_bot";
            // Console.ReadLine();

            _irc = ircClient.GetIrcClient(_server, _port, _userName, _channel);
        }
        public virtual void ConnectToServer() 
        {
            _irc.ConnectToServer();
        }
        public virtual void JoinRoom()
        {
            _irc.joinRoom();
        }
        public abstract void InitializeReaderAndWriter();
        public abstract void ReadingStreams(ircClient irc);
        public abstract void SendingMessage(ircClient irc);
        public virtual void ShowMessage()
        {
            Console.Write(message.Time.ToString("HH:mm tt("));
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message.UserName);
            Console.ResetColor();
            Console.WriteLine(") " + message.Text);

            Console.Title = "Connected to: " + _irc.channel + ". Messages: " + count + ". Pongs: " + pongs;
        }


    }
}
