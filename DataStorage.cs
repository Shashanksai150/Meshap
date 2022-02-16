using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace meshap
{
    internal class DataStorage : meminterface
    {
        #region client1 user data
        static string Userid = "GSS@150";
        static string Pd = "GSS143150";
        static string Name = "GSS";
        static ulong number = 1445552204;

        String directory = @"D:\meshap";
        static String Contactsdir = @"D:\meshap\Contactsdir\Contactsdir.bin";
        static String num1hist = @"D:\meshap\history\num1.txt";
        static String num2hist = @"D:\meshap\history\num2.txt";
        static String num3hist = @"D:\meshap\history\num3.txt";
        static String num4hist = @"D:\meshap\history\num4.txt";
        static String num5hist = @"D:\meshap\history\num5.txt";
        

        static public Dictionary<int, ArrayList> Phonecont = new Dictionary<int, ArrayList>()
            {
                { 1 , new ArrayList(){ 1425552251, "GSS" , @"D:\meshap\history\num1.txt" } },
                { 2 , new ArrayList(){ 1425552252, "RAM", @"D:\meshap\history\num2.txt" } },
                { 3 , new ArrayList(){ 1425552253, "RAJ", @"D:\meshap\history\num3.txt" } },
                { 4 , new ArrayList(){ 1425552254, "MANU", @"D:\meshap\history\num4.txt" } },
                { 5 , new ArrayList(){ 1425552255, "SONY", @"D:\meshap\history\num5.txt" } }
            };

        //public Dictionary<, ArrayList> History = new Dictionary<string, ArrayList>()
        //    {
        //        { 1425552251 , new ArrayList(){"GSS143150", "GSS", 1445552204} },
        //        { 1425552252 , new ArrayList(){"GSS143150", "GSS", 1445552204} },
        //        { 1425552253 , new ArrayList(){"GSS143150", "GSS", 1445552204} },
        //        { 1425552254 , new ArrayList(){"GSS143150", "GSS", 1445552204} },
        //        { 1425552255 , new ArrayList(){"GSS143150", "GSS", 1445552204} }
        //        { "num1" , Phonecount[0] },
        //        { "num2" , Phonecount[0] },
        //        { "num3" , Phonecount[0] },
        //        { "num4" , Phonecount[0] },
        //        { "num5" , Phonecount[0] }
        //    };

        #endregion

        #region Contacts related
        public void continfo(int num)
        {
            Dictionary<int, ArrayList> Phonecont;
            //ArrayList c = new ArrayList();
            //BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Contactsdir))
            {
                Stream openf = File.OpenWrite(Contactsdir);
                Phonecont = (Dictionary<int, ArrayList>)deserializer.Deserialize(openf);
                //openf.Close();
                
                Console.WriteLine(Phonecont[num][0] + " : " + num);
                
                openf.Close();
            }
            
        }


        public bool delContacts(ulong num)
        {
            Dictionary<ulong, ArrayList> Phonecont;
            //ArrayList c = new ArrayList();
            BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Contactsdir))
            {
                Stream openf = File.OpenWrite(Contactsdir);
                Phonecont = (Dictionary<ulong, ArrayList>)deserializer.Deserialize(openf);
                //openf.Close();

                Phonecont.Remove(num);
                Console.WriteLine("Registration Successfull");
                serializer.Serialize(openf, Phonecont);
                openf.Close();
            }
            return true;
            
        }

        
        public bool AddContacts(ulong pnum, String Name, string path)
        {
            //Dictionary
            Dictionary<int,ArrayList> Phonecont;
            ArrayList c = new ArrayList();
            BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Contactsdir))
            {
                Stream openf = File.OpenRead(Contactsdir);
                Phonecont = (Dictionary<int, ArrayList>)deserializer.Deserialize(openf);
                openf.Close();
                c.Add(pnum);
                c.Add(Name);
                string dir = @"D:\meshap\history\";
                c.Add(dir + Name + ".txt");
                int count = Phonecont.Count + 1;
                Phonecont.Add(count, c);
                StreamWriter openf1 = File.AppendText(Contactsdir);
                serializer.Serialize(openf1, Phonecont);

                openf.Close();
                Console.WriteLine("Contact added Successfully");
            }
            return true;
        }


        public void Contactslist()
        {
            Dictionary<int, ArrayList> Phonecont;
            //ArrayList c = new ArrayList();
            //BinaryFormatter serializer = new BinaryFormatter();
            BinaryFormatter deserializer = new BinaryFormatter();
            if (File.Exists(Contactsdir))
            {
                Stream openf = File.OpenRead(Contactsdir);
                Phonecont = (Dictionary<int, ArrayList>)deserializer.Deserialize(openf);
                //openf.Close();
                foreach (var i in Phonecont.Keys)
                {
                    Console.WriteLine(i + ". " + Phonecont[i][1] + " : " + Phonecont[i][0]);
                }
                openf.Close();
            }
            else Console.WriteLine("Not found");

        }

        #endregion

        #region Chat history and imp
        public void chat_history(ulong num, string msg)
        {
            string Path = num1hist;// (string) Phonecont[num][1];
            if (!File.Exists(Path))
            {
                using (StreamWriter sr = File.AppendText(Path))
                {
                    sr.Write(num + " : ");
                    sr.WriteLine(msg);
                }
            }                      
        }

        public void chat_history(ulong num, bool me,string msg)
        {

            string Path = num1hist;// (string)(Phonecont[num][1]);
            if (!File.Exists(Path))
            {
                using (StreamWriter sr = File.AppendText(Path))
                {
                    sr.Write(DataStorage.number + " : ");
                    sr.WriteLine(msg);
                }
            }
        }

        public void Gethistory(ulong num)
        {
            string Path = num1hist; //(string)(Phonecont[num][1]);
            using (StreamReader sr = File.OpenText(Path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        #endregion

    }
}
