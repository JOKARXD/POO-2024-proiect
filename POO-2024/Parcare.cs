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


        public static int GetNrLocuriParcare()
        {
            var lineCount = 0;
            var reader = File.OpenText("Parcare.txt");
            try
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return lineCount;
        }

        public static bool LocOcupat(int numberLoc)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader("Parcare.txt");
                string data;
                data = reader.ReadLine();

                while (data!=null)
                {
                    string[] parts = data.Split('|');
                    int number = int.Parse(parts[0]);
                    if(number==numberLoc)
                    {
                        if (parts[1] == "X")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    data = reader.ReadLine();
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
            return false;
        }
        

        private static List<LocParcare> GetAll()
        {
            List<LocParcare> buffer = new List<LocParcare>();
            string data;
            StreamReader reader = new StreamReader("Parcare.txt");
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



        public static void Update(int number)
        {
            string data;
            List<string> lines = new List<string>();
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader("Parcare.txt");
                data =reader.ReadLine();

                while(data != null)
                {
                    string[] parts=data.Split('|');
                    int numberLoc=int.Parse(parts[0]);
                    if(numberLoc == number) 
                    {
                        parts[1] = "X";
                        data = string.Join('|', parts);
                    }
                    lines.Add(data);
                    data=reader.ReadLine();
                }
                reader.Close();
                writer = new StreamWriter("Parcare.txt", false);
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }

            }
            catch (Exception e) 
            {
                Console.WriteLine (e.Message);
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
                reader = new StreamReader("Parcare.txt");
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
                writer = new StreamWriter("Parcare.txt", false);
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
            List<char> caractere=new List<char>();
            List<LocParcare> buffer = GetAll();

            foreach (LocParcare loc in buffer)
            {
                if (loc.EsteRezervat)
                {
                    caractere.Add('X');
                }
                else
                {
                    caractere.Add('O');
                }
            }
           DrawPark(caractere);
        }
        private static void DrawPark(List<char> caractere)
        {
            int i = 1;
            foreach (var _ in caractere)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            foreach (var _ in caractere)
            {
                if (i < 10)
                {
                    Console.Write($"|{i}  ");
                    i++;
                }
                else if (i < 99)
                {
                    Console.Write($"|{i} ");
                    i++;
                }
                else
                {
                    Console.Write($"|{i}");
                    i++;
                }

            }
            Console.WriteLine("|");

            foreach (var _ in caractere)
            {
                Console.Write("|   ");
            }
            Console.WriteLine("|");

            foreach (var status in caractere)
            {
                Console.Write($"| {status} ");
            }
            Console.WriteLine("|");

            foreach (var _ in caractere)
            {
                Console.Write("|   ");
            }
            Console.WriteLine("|");

            foreach (var _ in caractere)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            
        }

    }
}
