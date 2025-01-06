using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Companie
    {
        public List<LocBirou> LocuriLaBirou {  get; set; }


        public Companie()
        {
            LocuriLaBirou = new List<LocBirou>();
        }

        public void VizualizareLocuri()
        {
            Console.WriteLine("Aici o sa fie desenul cu charactere si caracterrul X si O pe care o sa le iau din fisier");
        }

    }
}
