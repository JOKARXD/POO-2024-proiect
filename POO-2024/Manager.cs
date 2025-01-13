using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            int i = 1;
            Console.WriteLine($" * {Nume}");
            foreach (Angajat ang in echipa)
            {
                Console.WriteLine($"{i}. {ang.Nume}");
                i++;
            }
        }
        public  void VizualizareRezervariEchipa() 
        {
            Console.WriteLine($" * {Nume}");
            foreach (var angajat in echipa)
            {
                angajat.VizualizareRezervari();  
            }
        }
        public void ModificareRezervariEchipa( Angajat angajat,int index,int numar)
        {
            foreach (var ang in echipa)
            {
                if (ang==angajat)
                {
                    angajat.ModifRezervare(index, numar);
                }
            }
        }

        public void StergereRezervareEchipa(Angajat angajat, int index)
        {
            foreach (var ang in echipa)
            {
                if (ang == angajat)
                {
                    angajat.StergereRezervare(index);
                }
            }
        }

        public bool VerificareAngajat(Angajat angajat)
        {
            foreach(var ang in echipa)
            {
                if (ang == angajat)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
