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
            Director d = new Director();
            Builder b;
           
            Console.WriteLine("To load bor-reader press [r], to load client press [c]..");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    {
                        b = new builderReader();
                        d.Build(b);
                        break;
                    }
                case ConsoleKey.C:
                    {
                        b = new BuilderClient();
                        d.Build(b);
                        break;
                    }
                case ConsoleKey.T:
                    {
                        b = new BuilderTester();
                        d.Build(b);
                        break;
                    }
                default:
                    Console.WriteLine("Program closing..");
                    break;
            }
            
            

        }
        
    }
}
