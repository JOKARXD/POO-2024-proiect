using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_2024
{
    internal abstract class User
    {
        public string Nume {  get; set; }
        public List<Rezervare> Rezervari;

        public User(string Nume)
        {
            this.Nume = Nume;
            Rezervari = new List<Rezervare>();
        }

    }
}
