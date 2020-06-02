using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public interface IMessage
    {
        Int32 Id { set; get; }
        string Server { set; get; }
        string Chanel { set; get; }
        string SenderNickname { set; get; }
        string ReceiverNickname { set; get; }
        string Text { set; get; }
    }
}
