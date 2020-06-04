using IrcClient.Composite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient
{
    class Serializer
    {
        

        public static void SaveContacts(ContactFolder contacts)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("CContact.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, contacts);
            }      
            
        }
        public static ContactFolder LoadContacts()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            ContactFolder res = new ContactFolder();
            using (FileStream fs = new FileStream("CContact.dat", FileMode.OpenOrCreate))
            {
                res = (ContactFolder)formatter.Deserialize(fs);
            }
            
            return res;

        }

    }
}
