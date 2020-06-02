using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient
{
    abstract class Builder
    {
       
        public ircClient _irc { get; private set; }
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
        public abstract void ReadingChat(ircClient irc);
        public abstract void SendingMessage(ircClient irc);

    }
}
