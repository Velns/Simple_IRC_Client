using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient
{
    class Director
    {
        public User Build (User builder)
        {
            builder.ChangeParametersServer();
            builder.ConnectToServer();
            builder.JoinRoom();
            builder.InitializeReaderAndWriter();
            
            return builder;
        } 

    }
}   
