using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal class Admin : Angajat
    { 

        public Admin(string Nume) : base(Nume)
        {

        }

        public void VizualizareToateRezervari(List<Manager> manageri,List<Angajat> angajats)
        {
            foreach (Manager manager in manageri)
            {
                Console.WriteLine($"*{manager.Nume}");
                if (manager.Rezervari.Count == 0)
                {
                    Console.WriteLine("Acest manager nu a facut nici o rezervare inca!");
                }
                else
                {
                    manager.VizualizareRezervari();
                }
            }
            foreach (Angajat angajat in angajats)
            {
                Console.WriteLine($"-{angajat.Nume}");
                if (angajat.Rezervari.Count == 0)
                {
                    Console.WriteLine("Acest angajat nu a facut nici o rezervare inca!");
                }
                else
                {
                    angajat.VizualizareRezervari();
                }
            }
        }
        public static List<Rezervare> GetAllRezervari(List<Manager> manageri, List<Angajat> angajats)
        {
            List<Rezervare>AllRezervari = new List<Rezervare>();

            foreach (Manager manager in manageri)
            {
                foreach(var rezervare in manager.Rezervari)
                {
                    AllRezervari.Add(rezervare);
                }
            }
            foreach(Angajat angajat in angajats)
            {
                foreach(var rezervare in angajat.Rezervari)
                {
                    AllRezervari.Add(rezervare);
                }
            }
            return AllRezervari;
        }

        public void ShowAllRezervari(List<Manager> manageri, List<Angajat> angajats)
        {
            List<Rezervare>Rezervari = GetAllRezervari(manageri, angajats);
            int i = 1;
            foreach(var Rezervare in Rezervari)
            {
                Console.WriteLine($"{i}."+Rezervare);
                i++;
            }
        }
        public int GetNrRezervari(List<Manager> manageri, List<Angajat> angajats)
        {
            return GetAllRezervari(manageri,angajats).Count;
        }

        public void Modificare(List<Rezervare>RezervariTotale,int indexLista, int newNumber)
        {
            RezervariTotale[indexLista - 1].LocRez.numar = newNumber;
        }
        public int GetRezNumber(List<Rezervare> RezervariTotale,int indexRezervare)
        {
            return RezervariTotale[indexRezervare - 1].LocRez.numar;
        }
        public Loc GetLocType(List<Rezervare> RezervariTotale, int indexRezervare)
        {
            return RezervariTotale[indexRezervare - 1].LocRez;
        }
    }
}
