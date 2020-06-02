using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class ReceivedMessage : IMessage
    {
        public string UserName { get; }
        public string Server { get; }
        public string Chanel { get; }
        public string Text { get; }
        public DateTime Time => DateTime.Now;
        public ReceivedMessage(ircClient client, string message)
        {
            var offset = message.IndexOf(':');
            var result = message.IndexOf(':', offset + 1);
            UserName = message.Substring(1, message.IndexOf("!") - 1);
            Text = message.Substring(result + 1);           
            Server = client.server;
            Chanel = client.channel;
            
        }
    }
}
