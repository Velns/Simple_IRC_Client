using System;
using System.Collections.Generic;
using System.Text;

namespace IrcClient
{
    public interface IConverter
    {
        void ConvertToMassage(ircClient client, string message);
    }
}
