using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal abstract class Loc
    {
        public int numar{  get; set; }
        public bool EsteRezervat {  get; set; }

        public Loc(int numar)
        {
            this.numar = numar;
            this.EsteRezervat = false;
        }

        public abstract void Rezerva();
        public abstract void Elibereaza();

    }
}
