using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public interface IMessage
    {
        string UserName { get; }
        string Server { get; }
        string Chanel { get; }
        string Text { get; }
        DateTime Time { get; }
    }
}
