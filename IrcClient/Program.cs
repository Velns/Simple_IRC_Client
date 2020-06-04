using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using IrcClient.Composite;

namespace IrcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var f_A = new ContactFolder() { Name = "A_folder" };
                //var f_B = new ContactFolder() { Name = "B_folder" };
                //var f_C = new ContactFolder() { Name = "C_folder" };
                //var f_D = new ContactFolder() { Name = "D_folder" };

                //f_A.Add(f_B);

                //for (int i = 0; i < 2; i++)
                //{
                //    f_A.Add(new Person() { Name = "a" + i });
                //}
                //f_A.Add(f_C);
                //for (int i = 4; i < 5; i++)
                //{
                //    f_A.Add(new Person() { Name = "a" + i });
                //}
                //f_C.Add(f_D);
                //for (int i = 1; i < 5; i++)
                //{
                //    f_B.Add(new Person() { Name = "b" + i });
                //}
                //for (int i = 1; i < 5; i++)
                //{
                //    f_C.Add(new Person() { Name = "c" + i });
                //}
                //for (int i = 1; i < 5; i++)
                //{
                //    f_D.Add(new Person() { Name = "d" + i });
                //}

                //f_A.Show();

                //Serializer.SaveContacts(f_A);
                //ContactFolder f = Serializer.LoadContacts();
                //f.Show();
            }

            while (true)
            {
                
                StartChoice();
            }
            


        }
        static void StartChoice()
        {
            Console.WriteLine("To load bot-reader press [r], to load client press [c], to load backup utilite press [b]..");
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
                        Environment.Exit(0);
                        break;
                    }
                case ConsoleKey.T:
                    {
                        var userMode = new UserTester();
                        userMode.StartClient();
                        break;
                    }
                case ConsoleKey.B:
                    {
                        Console.WriteLine("поки не судьба :(");
                        break;
                    }
                default:
                    {
                        var userMode = new UserStandart();
                        userMode.StartClient();
                        break;
                    }
            }
        }
    }
}
