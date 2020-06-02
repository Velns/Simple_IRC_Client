﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public class SentMessage : IMessage
    {
        public Int32 Id { set; get; }
        public string Server { set; get; }
        public string Chanel { set; get; }
        public string SenderNickname { set; get; }
        public string ReceiverNickname { set; get; }
        public string Text { set; get; }
        public SentMessage(ircClient client, string message)
        {
            ConvertToMassage(client, message);
        }

        public void ConvertToMassage(ircClient client, string mes)
        {
            Server = client.server;
            Chanel = client.channel;
            var offset = mes.IndexOf(':');
            var result = mes.IndexOf(':', offset + 1);
            SenderNickname = mes.Substring(1, mes.IndexOf("!") - 1);
            Text = mes.Substring(result + 1);

        }

        public void ShowMassage()
        {
           // Console.Write(">>>");
           // Console.BackgroundColor = ConsoleColor.DarkRed;
           // Console.ForegroundColor = ConsoleColor.Black;
           // Console.Write(SenderNickname);
           // Console.ResetColor();
           // Console.WriteLine(": " + Text);
        }
    }
}