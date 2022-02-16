using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace meshap
{
    
    internal class Server 
    {
     
        meminterface ds = new DataStorage();

        #region Server data
        static String Clientdir = @"D:\meshap\Server\Clients.bin";

        static string ramcont;

        public Dictionary<String, ArrayList> Clients = new Dictionary<string, ArrayList>()
            {
                { "GSS@150" , new ArrayList(){"GSS143150", "GSS", 1445552204, DataStorage.Phonecont } },
                { "RAM" ,  new ArrayList(){ "RAM", "GSS1", 1445552204, ramcont}},
                { "RAJ" , new ArrayList() { "RAJ", "GSS2", 1445552204, ramcont}},
                { "MANU" , new ArrayList() { "MANU", "GSS3", 1445552204, ramcont}},
                { "SONY" , new ArrayList() { "SONY", "GSS4", 1445552204, ramcont}}
            };
        #endregion

        #region CLient evaluation and client server connection part

        static public bool connectserver(ulong numr)
        {
            Client.connectclient(numr, true);
            Console.WriteLine("Client Connected");
            return true;
        }

        public bool clientlogin(String id, String Pd)
        {
            bool v = false;
            Dictionary<string, ArrayList> Clients;
            ArrayList c = new ArrayList();
            BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Clientdir))
            {
                Stream openf = File.OpenRead(Clientdir);
                Clients = (Dictionary<string, ArrayList>)deserializer.Deserialize(openf);
                //openf.Close();

                if (Clients.ContainsKey(id))
                {
                    if ((String)Clients[id][0] == Pd)
                    {
                        
                        Client.loginvrf(true);
                        //Console.WriteLine("Login Successfull");
                        v = true;
                    }
                    else { Console.WriteLine("Incorrect Password");  }
                }
                else { Console.WriteLine("Incorrect userID");  }

                
                
                openf.Close();
                
            }
            return v;
        }

        #endregion

        #region Client registration and deregistration part

        public void Clientregistration(String ID, String Pd, String Nam, ulong num)
        {
            Dictionary<string, ArrayList> Clients;
            ArrayList c = new ArrayList();
            BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Clientdir))
            {
                Stream openf = File.OpenRead(Clientdir);
                Clients = (Dictionary<string, ArrayList>)deserializer.Deserialize(openf);
                openf.Close();
                c.Add(Pd);
                c.Add(Nam);
                c.Add(num);
                Clients.Add(ID, c);
                
                Stream open = File.OpenWrite(Clientdir);
                serializer.Serialize(open, Clients);
                Console.WriteLine("Registration Successfull");
                openf.Close();
            }
            //this.Clients = Clients;
            //ArrayList c = new ArrayList();
            //c.Add(Pd);
            //c.Add(Nam);
            //c.Add(num);
            //Clients.Add(ID, c);
            //Console.WriteLine("Registration Successfull");

            //Stream SaveFileStream = File.Create(Clientdir);
            //BinaryFormatter serializer = new BinaryFormatter();
            //serializer.Serialize(SaveFileStream, Clients);
            //SaveFileStream.Close();
        }

        public void Clientderegistration(String id)
        {
            Dictionary<string, ArrayList> Clients;
            ArrayList c = new ArrayList();
            BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Clientdir))
            {
                Stream openf = File.OpenWrite(Clientdir);
                Clients = (Dictionary<string, ArrayList>)deserializer.Deserialize(openf);
                //openf.Close();
                Clients.Remove(id);
                Console.WriteLine("Deregistration Successfull");
                serializer.Serialize(openf, Clients);
                openf.Close();
            }
            
        }

        #endregion

        #region Contacts addition
        public void AddContacts(ulong pnum, String Name, string path, Client C)
        {
            //Dictionary
            
                C.AddContacts(pnum, Name, path);
                //Console.WriteLine("Contact Added");
            
        }

        #endregion

        #region Send and receive message block
        public void sendmsg(Server s ,Client fc, Client tc , String msg, int pb)
        {
            //Send msg
            
            tc.receivemsg(s, fc , tc , msg, pb);

            //Console.WriteLine(msg);
            //return true;
        }


        public void receivemsg(Server s, Client fc, Client tc , string msg ,int pb)
        {
            tc.sendmsg(s ,tc ,fc , msg,pb);
            
        }

        #endregion

        #region group chat related
        public void Creategrp(bool vfn)
        {
            //grp creation
            if (vfn)
            {
                Console.WriteLine("Group Created");
            }
        }
        //public void continfo(bool vfn)
        //{
        //    if (vfn)
        //    {
        //        Console.WriteLine("Group Created");
        //    }
        //}
        #endregion
    
    }
}
