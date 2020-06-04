using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcClient.Composite
{
    interface IContact
    {
        string Name { set; get; }        // ім'я папки чи контакту
        void Show(int tabs);        

    }
}
