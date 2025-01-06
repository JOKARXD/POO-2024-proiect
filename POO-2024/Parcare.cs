using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Parcare 
    {
        public List<LocParcare> LocuriParcare {  get; set; }

        public Parcare()
        {
            LocuriParcare = new List<LocParcare>();
        }

        public void VizualizareLocuri()
        {
            Console.WriteLine("Aici o sa fie desenul cu charactere si caracterrul X si O pe care o sa le iau din fisier");
        }




    }
}
