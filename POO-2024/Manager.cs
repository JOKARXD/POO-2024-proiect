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
        public void afisareEchipa()
        {
            Console.WriteLine($" * {Nume}");
            foreach (Angajat ang in echipa)
            {
                Console.WriteLine($"- {ang.Nume}");
            }
        }
        public  void VizualizareRezervariEchipa() // sa stiu ce manager a cerut asta 
        {
            Console.WriteLine($" * {Nume}");
            foreach (var angajat in echipa)
            {
                angajat.VizualizareRezervari();  
            }
        }
        public void ModificareRezervariEchipa( string utilizator,int index,int numar)
        {
            foreach (var angajat in echipa)
            {
                if (angajat.Nume == utilizator)
                {
                  
                    angajat.ModifRezervare(index, numar);

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
