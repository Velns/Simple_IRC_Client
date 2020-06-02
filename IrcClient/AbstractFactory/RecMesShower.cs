using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient.AbstractFactory
{
    class RecMesShower : IShower
    {
        public void ShowMessage()
        {
            Console.Write(">>>");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(SenderNickname);
            Console.ResetColor();
            Console.WriteLine(": " + Text);
        }
    }
}
