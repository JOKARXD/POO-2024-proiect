using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Manager: Angajat, IManager
    {
        public List<Angajat> echipa;
        public Manager(string Nume) : base(Nume) 
        {
            echipa = new List<Angajat>();
        }
        public  void AdaugareAngajat(Angajat angajat)
        {
            echipa.Add(angajat);
        }
        public  void VizualizareRezervariEchipa() // sa stiu ce manager a cerut asta 
        {
            foreach (var angajat in echipa)
            {
                angajat.VizualizareRezervari();  
            }
        }
        public void ModificareRezervariEchipa(int numarLoc, string utilizator,Loc locNou)
        {
            foreach (var angajat in echipa)
            {
                if (angajat.Nume == utilizator)
                {
                    angajat.ModifRezervare(numarLoc, locNou);
                    break;
                }
            }
        }

        public void StergereRezervareEchipa(int numarLoc)
        {
            foreach (var angajat in echipa)
            {
                angajat.StergereRezervare(numarLoc);
            }
        }
    }
}
