using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal abstract class Loc
    {
        private int Numar { get; set; }
        private bool esteRezervat { get; set; }

        public Loc(int numar)
        {
            this.Numar = numar;
            this.EsteRezervat = false;
        }
        public int numar
        {
            get { return this.Numar; }
            set { this.Numar = value; }
        }
        public bool EsteRezervat
        {
            get { return this.esteRezervat; }
            set { this.esteRezervat = value; }
        }




        public abstract void Rezerva();
        public abstract void Elibereaza();

    }
}
