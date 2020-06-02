using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public interface IFactory
    {
        IMessage CreateEntity(ircClient client, string mes);
    }
}
