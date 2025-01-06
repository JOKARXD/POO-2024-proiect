using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Angajat: User // la modificare e dificil
    {
        public Angajat(string Nume): base(Nume) { }

        public void RezervareLoc(Loc loc)
        {
            Rezervare rez = new Rezervare(loc, Nume);
            Rezervari.Add(rez);
        }
        public void VizualizareRezervari()
        {
            foreach(var rez in Rezervari)
            {
                Console.WriteLine(rez);
            }
        }
        public void ModifRezervare(int indexLista,int newNumber)
        {
            Rezervari[indexLista-1].LocRez.numar = newNumber;
        }
        public void StergereRezervare(int indexLista) // undeva pe aici trebuie sa eliberezi locul 
        {
            Rezervari[indexLista-1].LocRez.Elibereaza();
            Rezervari.RemoveAt(indexLista - 1);

        }
    }
}
