using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Angajat
    {
        public string Nume { get; set; }
        public List<Rezervare> Rezervari;

        public Angajat(string Nume)
        {
            this.Nume = Nume;
            Rezervari = new List<Rezervare>();
        }

        public void RezervareLoc(Loc loc)
        {
            Rezervare rez = new Rezervare(loc, Nume);
            Rezervari.Add(rez);
        }
        public void VizualizareRezervari()
        {
            int i = 1;
            foreach(var rez in Rezervari)
            {
                Console.WriteLine($"{i} "+ rez);
                i++;
            }
        }
        public void ModifRezervare(int indexLista,int newNumber)
        {
            Rezervari[indexLista-1].LocRez.numar = newNumber;
        }
        public void StergereRezervare(int indexLista)  
        {
            Rezervari[indexLista-1].LocRez.Elibereaza();
            Rezervari.RemoveAt(indexLista - 1);

        }
    }
}
