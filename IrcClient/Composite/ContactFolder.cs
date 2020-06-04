using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace IrcClient.Composite
{
    [Serializable]
    class ContactFolder : IContact
    {
        public static List<ContactFolder> folders = new List<ContactFolder>();            //шось інше придумати
        public List<IContact> contacts = new List<IContact>();

        public string Name { set; get; }

        public void Add(IContact con)
        {
            contacts.Add(con);
        }
        public static void Add(IContact con, string folderName)
        {
            Console.WriteLine("В розробці..");
        }

        public void Remove(IContact con)
        {
            contacts.Remove(con);
        }
        public void Show() { Show(0); }
        public void Show(int tabs)
        {
            Console.WriteLine();
            Console.Write(new string(' ', tabs) + "-->");           //формат виводу
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            Console.WriteLine(Name);

            Console.ResetColor();

            foreach (var item in contacts)
            {
                item.Show(tabs+6);
            }
            Console.WriteLine();
        }
        public ContactFolder()
        {
            folders.Add(this);
        }
        
    }
}
