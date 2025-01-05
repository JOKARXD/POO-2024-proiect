using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 
{
    internal class Parcare : IMetodeLocuri
    {
        public List<LocParcare> LocuriParcare;
        public string numeParcare {  get; set; }

        public int locuriTotale {  get; set; }

        public Parcare(string numeParcare, int locuriTotale)
        {
            LocuriParcare = new List<LocParcare>();
            this.numeParcare = numeParcare;
            this.locuriTotale = locuriTotale;
        }

        public void VizualizareLocuri()
        {
            foreach (var loc in LocuriParcare)
            {
                Console.WriteLine(loc);
            }
        }
        public void AdaugareLocuri(Loc locP) 
        { 
            if(locP is LocParcare)
            {
                LocuriParcare.Add((LocParcare)locP);
            }
        }



    }
}
