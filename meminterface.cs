using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meshap
{
    internal interface meminterface
    {
        
        void continfo(int num);

        bool delContacts(int num);

        bool AddContacts(ulong pnum, String Name, string path);

        void Contactslist();

        void chat_history(int num, string msg);

        void chat_history(int num, bool me, string msg);

        void Gethistory(int num);

    }

}
