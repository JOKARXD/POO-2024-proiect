

using POO_2024;

public class Program
{
    public static void Main() // testarea UI pentru clase                                
    {
        while (true)
        {

            Console.WriteLine("Logat ca: ");
            Console.WriteLine("1.Angajat");
            Console.WriteLine("2.Manager");
            Console.WriteLine("3.Admin");
            Console.WriteLine("0.Exit");
            int optiune = Convert.ToInt32(Console.ReadLine());
            switch (optiune)
            {
                case 1:
                    Console.WriteLine("Am creat un angajat");
                    // Aici o sa creez un obiect de tip angajat
                    //Si aici sunt lucrurile pe care le poate face un angajat
                    Console.WriteLine("Numele angajatului: ");
                    string nume=Console.ReadLine();
                    Angajat ang1 = new Angajat(nume);
                    bool ExistaAngajat = false;
                    while (!ExistaAngajat)
                    {
                        Console.WriteLine("1.Vizualizare locuri de parcare si a locurilor la birou");
                        Console.WriteLine("2.Rezervare loc de parcare si/sau loc de birou");
                        Console.WriteLine("3.Vizualizare rezervari facute");
                        Console.WriteLine("4.Modificare rezervari facute");
                        Console.WriteLine("5.Stergere rezervari facute");
                        Console.WriteLine("0.Back to login");
                        int optiuneAngajat = Convert.ToInt32(Console.ReadLine());
                        switch (optiuneAngajat)
                        {
                            case 1:
                                Console.WriteLine("Vizualizam toate rezervarile facute de angajat");
                                // adaugare cumva sa vad toate locurilee din parcare si companie
                                break;
                            case 2:
                                Console.WriteLine("La ce vrei sa faci rezervare? ");
                                Console.WriteLine("1. Loc de parcare");
                                Console.WriteLine("2. Loc de birou");
                                Console.WriteLine("3. Loc de parcare si loc de birou");
                                int optiuneRez = Convert.ToInt32(Console.ReadLine());

                                if (optiuneRez == 1)
                                {
                                    Console.WriteLine("La ce nr doresti sa faci: ");
                                    int nrParc=Convert.ToInt32(Console.ReadLine());
                                    Loc loc = new LocParcare(nrParc);
                                   
                                    ang1.RezervareLoc(loc);
                                }else if(optiuneRez == 2)
                                {
                                    Console.WriteLine("La ce nr doresti sa faci: ");
                                    int nrBirou = Convert.ToInt32(Console.ReadLine());
                                    Loc loc = new LocBirou(nrBirou);

                                    ang1.RezervareLoc(loc);
                                } // adaugarea optiunea 3

                                break;
                            case 3:
                                Console.WriteLine("Vizualizare rezervari facute de angajat");
                                ang1.VizualizareRezervari();
       
                                break;
                            case 4:
                                Console.WriteLine("Modificare rezervari facute de angajat");
                                break;
                            case 5:
                                Console.WriteLine("Stergere rezervari facute de angajat");
                                break;
                            case 0:
                                ExistaAngajat = true;
                                break;
                        }
                    }
                    break;
                case 2:// Aici o sa creez un obiect de tip manager
                    //Si aici sunt lucrurile pe care le poate face un manager
                    Console.WriteLine("Am creat un manager");
                    bool ExistaManager = false;
                    while (!ExistaManager)
                    {
                        Console.WriteLine("1.Vizualizare locuri de parcare si a locurilor la birou");
                        Console.WriteLine("2.Rezervare loc de parcare si/sau loc de birou");
                        Console.WriteLine("3.Vizualizare rezervari facute");
                        Console.WriteLine("4.Modificare rezervari facute");
                        Console.WriteLine("5.Stergere rezervari facute");
                        Console.WriteLine("6. Adaugare angajat in echipa");
                        Console.WriteLine("7.Vizualizare rezervari facute de catre echipa");
                        Console.WriteLine("8.Modificare rezervari facute de catre echipa");
                        Console.WriteLine("9.Stergere rezervari facute de catre echipa");
                        Console.WriteLine("0.Back to login");
                        int optiuneManager = Convert.ToInt32(Console.ReadLine());
                        switch (optiuneManager)
                        {
                            case 1:
                                Console.WriteLine("Vizualizam toate rezervarile facute de manager");
                                break;
                            case 2:
                                Console.WriteLine("La ce vrei sa faci rezervare? ");
                                Console.WriteLine("1. Loc de parcare");
                                Console.WriteLine("2. Loc de birou");
                                Console.WriteLine("3. Loc de parcare si loc de birou");
                                break;
                            case 3:
                                Console.WriteLine("Vizualizare rezervari facute de manager");
                                break;
                            case 4:
                                Console.WriteLine("Modificare rezervari facute de manager");
                                break;
                            case 5:
                                Console.WriteLine("Stergere rezervari facute de manager");
                                break;
                            case 6:
                                Console.WriteLine("Adauga angajati in echipa");
                                break;
                            case 7:
                                Console.WriteLine("Vizualizare rezervari facute de catre echipa");
                                break;
                            case 8:
                                Console.WriteLine("Modificari rezervari facute de catre echipa");
                                break;
                            case 9:
                                Console.WriteLine("Stergere rezervari facute de catre echipa");
                                break;
                            case 0:
                                ExistaManager = true;
                                break;
                        }
                    }
                    break;

                case 3:// Aici o sa creez un obiect de tip admin
                    //Si aici sunt lucrurile pe care le poate face un admin
                    Console.WriteLine("Am creat admin");
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nu poti alegere altceva!");
                    break;

            }

        }
    }
}