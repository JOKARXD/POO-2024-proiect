using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal interface IManager
    {
        public void VizualizareRezervariEchipa();
        public void ModificareRezervariEchipa(int numarLoc,string utilizator,Loc locNou);
        public void StergereRezervareEchipa(int numarLoc);

    }
}
