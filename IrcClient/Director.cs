using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient
{
    class Director
    {
        public Builder Build (Builder builder)
        {
            builder.ChangeParametersServer();
            builder.ConnectToServer();
            builder.JoinRoom();
            builder.InitializeReaderAndWriter();
            
            return builder;
        } 

    }
}   
