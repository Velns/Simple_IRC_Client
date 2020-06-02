using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class ReceivedMessageFactory : IFactory
    {
        public IMessage CreateEntity(ircClient client, string message)
        {
            return new ReceivedMessage(client, message);
        }
    }
}
