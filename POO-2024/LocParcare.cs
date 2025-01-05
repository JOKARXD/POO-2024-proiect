using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class LocParcare: Loc
    {
        public LocParcare(int number): base(number) { }

        public override void Elibereaza()
        {
            EsteRezervat = false;
        }
        public override void Rezerva()
        {
            EsteRezervat=true;
        }

        public override string ToString()
        {
            return $"Loc Parcare {numar}: {(EsteRezervat ? "Rezervat" : "Liber")}";
        }
    }
}
