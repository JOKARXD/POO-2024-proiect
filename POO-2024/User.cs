using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_2024
{
    internal  class User
    {
        public static List<Angajat> GetAngajati()
        {
            List<Angajat> listaAngajati = new List<Angajat>();
            string data;
            StreamReader reader = new StreamReader("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Users.txt");
            data = reader.ReadLine();
                while (data != null)
                {
                    string[] parts=data.Split('|');
                    if (parts[1] == "A")
                    {
                        Angajat angajat =new Angajat(parts[0]);
                        listaAngajati.Add(angajat);
                    }
                    data = reader.ReadLine();
                }
                reader.Close();
            return listaAngajati;
        }
        /*
        public static Manager LogManager(string name)
        {

        }
        */

        /*
         * public static List<Manager> GetManageri ()
         * {
         * 
         * }
         * 
         * 
         */
        public static int LogAngajat(List<Angajat> angajati,string name)
        {
            for(int i=0;i<=angajati.Count;i++)
            {
                if (angajati[i].Nume==name)
                {
                
                    return i;
                }
            }

            return -1;
        }

    }
}
