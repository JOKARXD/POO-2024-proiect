using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Companie : IMetodeLocuri
    {
        public List<LocBirou> LocuriLaBirou;

        public string numeCompanie {  get; set; }

        public int locuriTotale {  get; set; }

        public Companie(string numeCompanie,int locuriTotale)
        {
            LocuriLaBirou = new List<LocBirou>();
            this.locuriTotale = locuriTotale;
            this.numeCompanie = numeCompanie;
        }

        public void VizualizareLocuri()
        {
            foreach (var loc in LocuriLaBirou)
            {
                Console.WriteLine(loc);
            }
        }

        public void AdaugareLocuri(Loc locP)
        {
            if (locP is LocBirou)
            {
                LocuriLaBirou.Add((LocBirou)locP);
            }
        }

    }
}
