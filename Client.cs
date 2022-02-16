using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace meshap
{
    internal class Client
    {

        #region CLient class fields, constructor & properties
        string Userid { get; set; }
        string Pd { get; set; }
        string Name { get; set; }
        
        public ulong number;

        public Client(ulong number)
        {
           
            this.number = number;
            
        }
        #endregion
        
        meminterface ds = new DataStorage();

        #region Contacts

        //Dictionary
        public Dictionary<int, ArrayList> Phonecont = new Dictionary<int, ArrayList>()
            {
                { 1 , new ArrayList(){ "SAM" , 1425552251 } },
                { 2 , new ArrayList(){ "RAM", 1425552252 } },
                { 3 , new ArrayList(){ "RAJ", 1425552253 } },
                { 4 , new ArrayList(){ "MANU", 1425552254 } },
                { 5 , new ArrayList(){ "SONY", 1425552255 } }
            };

        #endregion

        #region Server conn & login verif
        public static void connectclient(ulong nbr, bool vrf)
        {
            ulong num = nbr;
            if (vrf)
            {
                Console.WriteLine("Server Connected");
            }
        }
        
        public static void loginvrf(bool vrf)
        {
            if (vrf)
            {
                
                Console.WriteLine("Login Successful");
            }
            
        }

        #endregion

        #region Contacts methods
        public void continfo(int num) 
        {
            ds.continfo(num);             
        }

        
        public bool Contdel(int num)
        {
            if (ds.delContacts(num))
            { return true; }
            else return false;
            
        }

        public void AddContacts(ulong pnum, String Name, string path)
        {
            //Dictionary
            if (ds.AddContacts(pnum, Name, path))
            { Console.WriteLine("Contact Added"); }
            else Console.WriteLine("Contact Added");
        }

        #endregion

        #region Send and receive messages
        public bool sendmsg(Server s, Client fc, Client tc, String msg , int pb)
        {
            //Sending message and creating a new thread to save the chat history            
            Console.WriteLine( fc.number + " : " + msg);           
            //new Thread(ds.chat_history).Start();
            ds.chat_history(pb, true, msg);
            return true;
        }

        public bool receivemsg(Server s ,Client fc, Client tc , String msg,int pb)
        {
            //Receiving message and creating a new thread to save the chat history
            Console.WriteLine( tc.number + " : " + msg);
            //new Thread(ds.chat_history).Start();
            ds.chat_history( pb , msg);
            return true;
        }


        #endregion

        #region Group chat related
        public void Creategrp(int num)
        {
            //grp creation
            ArrayList grpn = new ArrayList();           
            grpn.Add(num);
        }

        public void Creategrp(ulong num)
        {
            //grp creation
            ArrayList grpn = new ArrayList();
            grpn.Add(num);
        }

        #endregion

    }
}
