using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meshap
{
    enum funcmenu 
    {
        Add_Contact = 1,
        Messaging,
        Opening_history,
        Get_Contacts,
        del_contacts,
        Groupcreation
    }

    internal class Program
    {
        # region Menu Function
        public static void functions(Server s, Client c, string id ,bool b)
        {
            meminterface ds = new DataStorage();
            if (!b) { return; }
            Console.WriteLine("Menu : ");
            int f = int.Parse(Console.ReadLine());
            switch (f)
            {
                case (int)funcmenu.Add_Contact:
                    // To ADD contact
                    Console.WriteLine("Enter number and next name : ");
                    ulong p1 = ulong.Parse(Console.ReadLine());
                    var n1 = Console.ReadLine();
                    var n2 = Console.ReadLine();
                    s.AddContacts(p1,n1,n2, C: c);
                    break;

                case (int)funcmenu.Messaging:
                    // To send msg
                    ds.Contactslist();
                    Console.WriteLine("Select contact : ");
                    var pb = int.Parse(Console.ReadLine());
                    Dictionary<int , ArrayList> dictph = (Dictionary<int, ArrayList>)s.Clients[id][3];
                    
                    var num = Convert.ToUInt64(dictph[pb][0]);
                    Client c1 = new Client(num);
                    c1.number = c.number;
                    Console.WriteLine("client 1 message: ");
                    var m1 = Console.ReadLine();
                    
                    s.sendmsg(s, c, c1 , m1, pb);
                    s.receivemsg(s, c1, c , m1,pb);

                    Console.WriteLine("client 2 message: ");
                    var m2 = Console.ReadLine();
                    
                    s.sendmsg(s, c1, c, m2, pb);
                    s.receivemsg(s , c, c1, m2, pb);
                    break;
               
                case (int)funcmenu.Opening_history:
                    Console.WriteLine("Select contact : ");
                    var cs = int.Parse(Console.ReadLine());
                    ds.Gethistory(cs);
                    break;
                
                case (int)funcmenu.Get_Contacts:
                    ds.Contactslist();
                    break;

                case (int)funcmenu.del_contacts:
                    Console.WriteLine("Select contact : ");
                    var cs1 = int.Parse(Console.ReadLine());
                    ds.delContacts(cs1);
                    break;

                case (int)funcmenu.Groupcreation:
                    Console.WriteLine("Select contact : ");
                    var cs2 = ulong.Parse(Console.ReadLine());
                    c.Creategrp(cs2);
                    break;
            }
        }
        #endregion
        
        static void Main(string[] args)
        {
            //#region opening App
            Console.WriteLine("TO Start App press y and to close q");
            bool op = 'y' == Console.ReadKey().KeyChar;
            
            while (op)
            {
                #region login / registration
                Server s1 = new Server();
                //Console.WriteLine("Enter User ID : ");
                //var id = Console.ReadLine();
                //Console.WriteLine("Enter Password : ");
                //var pd = Console.ReadLine();
                //if (!(s1.clientlogin(id, pd))) { break; }
                //Console.WriteLine("Enter User ID : ");
                //var id = Console.ReadLine();
                //Console.WriteLine("Enter new password : ");
                //var pd = Console.ReadLine();
                //Console.WriteLine("Enter Name : ");
                //var Name = Console.ReadLine();
                Console.WriteLine("Enter Choice 0 or 1 : ");
                //var numb = ulong.Parse(Console.ReadLine());
                //s1.Clientregistration(id, pd, Name, numb);
                int login = int.Parse(Console.ReadLine());

                switch (login)
                {
                    case 0:
                        {
                        //    Console.WriteLine("Enter User ID : ");
                        //var id = Console.ReadLine();
                        //    Console.WriteLine("Enter Password : ");
                        //    var pd = Console.ReadLine();
                        var id = "GSS@150";
                            if (/*s1.clientlogin(id, pd)*/true) { Client me = new Client(1445552204); functions(s: s1, c: me, id ,b: true); }
                            //else { break; }                           
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("Enter User ID : ");
                            var nid = Console.ReadLine();
                            Console.WriteLine("Enter new password : ");
                            var npd = Console.ReadLine();
                            Console.WriteLine("Enter Name : ");
                            var Name = Console.ReadLine();
                            Console.WriteLine("Enter Number : ");
                            var numb = ulong.Parse(Console.ReadLine());
                            s1.Clientregistration(nid, npd, Name, numb);
                            break;
                        }

                    default:
                        break;
                        #endregion
            }
            //#endregion
                //switch (s) 
                //{
                //    case 0:
                //        Console.WriteLine("Enter number and next name : ");
                //        ulong p1 = ulong.Parse(Console.ReadLine());
                //        var n1 = Console.ReadLine();
                //        var n2 = Console.ReadLine();
                //        s1.AddContacts(c1.AddContacts(p1, n1, n2));
                //        break;

                //    case 1:
                //        Console.WriteLine("client 1 message: ");
                //        var m1 = Console.ReadLine();
                //        s1.receivemsg(c1.sendmsg(m1));
                //        s1.sendmsg(m1);

                //        Console.WriteLine("client 2 message: ");
                //        var m2 = Console.ReadLine();
                //        s1.receivemsg(c2.sendmsg(m2));
                //        s1.sendmsg(m2);
                //        break;

                //}

                //Console.WriteLine("client 1 message: ");
                //var m1 = Console.ReadLine();
                //bool v2 = s1.receivemsg(c1.sendmsg(m1));
                //Console.WriteLine("client 2 message: ");
                //var m2 = Console.ReadLine();
                //c1.receivemsg(c2.sendmsg(m2));

                //var v4 = c1.AddContacts(1425552256, "LILY");
                //s1.AddContacts(v4);
                //c1.continfo(1425552256);
                //if (Console.ReadKey().KeyChar == 'q') { op = false; }
            }
        }
    }
}
