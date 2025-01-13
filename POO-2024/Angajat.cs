using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Angajat
    {
        private string nume;
        private List<Rezervare> rezervari;

        public Angajat(string Nume)
        {
            this.nume = Nume;
            rezervari = new List<Rezervare>();
        }

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public List<Rezervare> Rezervari
        {
            get { return rezervari; }
        }


        public int GetNumberFromRezervare(int indexRezervare)
        {
            return Rezervari[indexRezervare-1].LocRez.numar;
        }

        public Loc GetLocTypeFromRezervare(int indexRezervare)
        {
            return Rezervari[indexRezervare-1].LocRez;
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
                Console.WriteLine($"{i}. "+ rez);
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
