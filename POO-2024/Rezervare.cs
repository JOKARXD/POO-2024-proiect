using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Rezervare
    {
        public Loc LocRez {  get; set; }
        public string Utilizator {  get; set; }

        public Rezervare(Loc LocRez,string Utilizator)
        {
            this.LocRez = LocRez;
            this.Utilizator = Utilizator;
            LocRez.Rezerva();
        }

        ~Rezervare()
        {
            LocRez.Elibereaza();
        }

    }
}
