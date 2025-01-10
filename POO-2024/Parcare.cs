using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_2024
{
    internal class  Parcare 
    {

        public static void VizualizareLocuri()
        {
            Console.WriteLine("Aici o sa fie desenul cu charactere si caracterrul X si O pe care o sa le iau din fisier");
        }

        /*
        public LocParcare GetLocById(int id)
        {

        }
        */

        private static List<LocParcare> GetAll()
        {
            List<LocParcare> buffer = new List<LocParcare>();
            string data;
            StreamReader reader = new StreamReader("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Parcare.txt");
            try
            {
                data = reader.ReadLine();

                while (data != null)
                {
                    string[] parts=data.Split('|');
                    int number =int.Parse( parts[0]);
                    LocParcare loc = new LocParcare(number);
                    if (parts[1]=="X")
                    {
                        loc.Rezerva();
                    }
                    data = reader.ReadLine();
                    
                    buffer.Add(loc);
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
            }

            return buffer;

            
        }
        // create

        // update
        // delete

        public static void ShowAll()
        {
            List<LocParcare> buffer = GetAll();

            foreach (LocParcare loc in buffer)
            {
                Console.WriteLine(loc);
            }
        }

    }
}
