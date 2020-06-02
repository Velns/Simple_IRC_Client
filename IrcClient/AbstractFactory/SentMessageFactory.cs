using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class SentMessageFactory:IFactory
    {
        public IMessage CreateEntity(ircClient client, string message)
        {
            return new SentMessage(client, message);
        }
    }
}
