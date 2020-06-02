using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class Message
    {
        public IMessage message { get; }
        public Message(IFactory factory, ircClient client, string mes)
        {
            message = factory.CreateEntity(client, mes);
        }
    }
}
