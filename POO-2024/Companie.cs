using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POO_2024
{
    internal class Companie
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

        private static List<LocBirou> GetAll()
        {
            List<LocBirou> buffer = new List<LocBirou>();
            string data;
            StreamReader reader = new StreamReader("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Companie.txt");
            try
            {
                data = reader.ReadLine();

                while (data != null)
                {
                    string[] parts = data.Split('|');
                    int number = int.Parse(parts[0]);
                    LocBirou loc = new LocBirou(number);
                    if (parts[1] == "X")
                    {
                        loc.Rezerva();
                    }
                    data = reader.ReadLine();

                    buffer.Add(loc);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
            }

            return buffer;


        }
        // create pentru locuri in plus


        public static void Update(int number)
        {
            string data;
            List<string> lines = new List<string>();
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Companie.txt");
                data = reader.ReadLine();

                while (data != null)
                {
                    string[] parts = data.Split('|');
                    int numberLoc = int.Parse(parts[0]);
                    if (numberLoc == number)
                    {
                        parts[1] = "X";
                        data = string.Join('|', parts);
                    }
                    lines.Add(data);
                    data = reader.ReadLine();
                }
                reader.Close();
                writer = new StreamWriter("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Companie.txt", false);
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer?.Close();
            }
        }

        public static void Delete(int number)
        {
            string data;
            List<string> lines = new List<string>();
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Companie.txt");
                data = reader.ReadLine();

                while (data != null)
                {
                    string[] parts = data.Split('|');
                    int numberLoc = int.Parse(parts[0]);
                    if (numberLoc == number)
                    {
                        parts[1] = "O";
                        data = string.Join('|', parts);
                    }
                    lines.Add(data);
                    data = reader.ReadLine();
                }
                reader.Close();
                writer = new StreamWriter("C:\\Users\\pykem\\OneDrive\\Desktop\\POO-2024\\POO-2024\\Companie.txt", false);
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                writer?.Close();
            }
        }

        public static void ShowAll()
        {
            List<LocBirou> buffer = GetAll();

            foreach (LocBirou loc in buffer)
            {
                Console.Write(loc + "\n");        
            }
        }

    }
}
