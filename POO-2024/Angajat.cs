using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Angajat: User // totul la angajat merge
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
                if(rez.LocRez is LocParcare)
                {
                    Console.WriteLine($"Loc parcare:{rez.LocRez.numar}- Rezervat de {rez.Utilizator}");
                }
                else
                {
                    Console.WriteLine($"Loc birou:{rez.LocRez.numar}- Rezervat de {rez.Utilizator}");
                }
            }
        }
        public void ModifRezervare(int numarLoc,Loc locNou)
        {
            for(int i = 0; i < Rezervari.Count; i++) 
            {
                if (Rezervari[i].LocRez.numar == numarLoc)
                {
                    Rezervari[i] = new Rezervare(locNou, Nume);
                    break;
                }
            }
        }
        public void StergereRezervare(int numarLoc) // undeva pe aici trebuie sa eliberezi locul 
        {
            for(int i = 0;i < Rezervari.Count; i++)
            {
                if(Rezervari[i].LocRez.numar == numarLoc)
                {
                    Rezervari.RemoveAt(i);

                }
            }
        }
    }
}
