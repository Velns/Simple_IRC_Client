using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class SentMessage : IMessage
    {
        public string UserName { get; }
        public string Server { get; }
        public string Chanel { get; }
        public string Text { get; }
        public DateTime Time => DateTime.Now;
        public SentMessage(ircClient client, string mes)
        {
            UserName = client.userName;
            Server = client.server;
            Chanel = client.channel;
            Text = string.Copy(mes);
        }
    }
}
