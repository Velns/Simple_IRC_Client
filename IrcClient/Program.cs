using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IrcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("To load bor-reader press [r], to load client press [c]..");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    {
                        var userMode = new UserReadder();
                        userMode.StartClient();
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        Console.WriteLine("Program closing..");
                        break;
                    }
                case ConsoleKey.T:
                    {
                        var userMode = new UserTester();
                        userMode.StartClient();
                        break;
                    }
                default:
                    {
                        var userMode = new UserStandert();
                        userMode.StartClient();
                        break;
                    }
                    
            }
            
            

        }
        
    }
}
