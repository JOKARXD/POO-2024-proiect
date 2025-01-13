using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Rezervare
    {
        private Loc locRez;
        private string utilizator;

        public Rezervare(Loc LocRez,string Utilizator)
        {
            this.locRez = LocRez;
            this.utilizator = Utilizator;
            LocRez.Rezerva();
        }

        public Loc LocRez
        {
            get { return locRez; }
            set { locRez = value; }
        }

        public string Utilizator
        {
            get { return utilizator; }
            set { utilizator = value; }
        }

        ~Rezervare()
        {
            LocRez.Elibereaza();
        }

        public override string ToString()
        {
    
            return LocRez.ToString() + $"  de {Utilizator} ";

        }

    }
}
