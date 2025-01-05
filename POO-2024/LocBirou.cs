using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class LocBirou:Loc
    {
        public LocBirou(int number) : base(number) { }

        public override void Elibereaza()
        {
            EsteRezervat = false;
        }
        public override void Rezerva()
        {
            EsteRezervat = true;
        }

        public override string ToString()
        {
            return $"Loc Birou {numar}: {(EsteRezervat ? "Rezervat" : "Liber")}";
        }
    }
}
