using IrcClient.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace IrcClient
{
    [Serializable]
    class Person:IContact
    {
        public string Name { set; get; }

        public void Show(int tabs)
        {
            Console.Write(new string('-', tabs) + "-->");           //формат виводу
            Console.WriteLine(Name);                                //дані виводу    
        }
        public Person() { }
        public Person(string name) { Name = name; }
    }
}
