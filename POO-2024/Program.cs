

using POO_2024;

public class Program
{
    public static void Main() // testarea UI pentru clase                                
    {
        List<Angajat> angajats = User.GetAngajati();
        List<Manager> manageri = User.GetManageri();


        while (true)
        {
            Console.WriteLine("Logare:");
            Console.WriteLine("1.Angajat");
            Console.WriteLine("2.Manager");
            Console.WriteLine("3.Admin");
            Console.WriteLine("0.Exit");

            int optiune;
            do
            {
                optiune = Convert.ToInt32(Console.ReadLine());
                if (optiune>4)
                {
                    Console.WriteLine("Alegeti o optiune valida!");
                }   

            } while (optiune > 4);

            switch (optiune)
            {
                case 1:
                    bool ExistaAngajat;
                    Console.WriteLine("Numele angajatului: ");
                    string nume=Console.ReadLine();
                    int rez = User.LogAngajat(angajats, nume);
                    if ( rez !=-1)
                    {
                        ExistaAngajat = false;
                        Console.WriteLine("Loggat cu succes!");
                    }
                    else
                    {
                        ExistaAngajat = true;
                        Console.WriteLine("Loggare fara succes!");
                    }
                    while (!ExistaAngajat)
                    {
                        Console.Write("\n");
                        Console.WriteLine("1.Vizualizare locuri de parcare si a locurilor la birou");
                        Console.WriteLine("2.Rezervare loc de parcare si/sau loc de birou");
                        Console.WriteLine("3.Vizualizare rezervari facute");
                        Console.WriteLine("4.Modificare rezervari facute");
                        Console.WriteLine("5.Stergere rezervari facute");
                        Console.WriteLine("6.Console Clear");
                        Console.WriteLine("0.Back to login");
                        int optiuneAngajat = Convert.ToInt32(Console.ReadLine());
                        switch (optiuneAngajat) // totu perfect aici doar ca modificariile trebuie facute in fisierul cu parcariile si companie
                        {
                            case 1: 

                                Parcare.ShowAll();
                                Companie.ShowAll();
                                break;
                            case 2: // Gata aici(mai trebe victor)
                                try
                                {
                                    Console.WriteLine("La ce vrei sa faci rezervare? ");
                                    Console.WriteLine("1. Loc de parcare");
                                    Console.WriteLine("2. Loc de birou");
                                    Console.WriteLine("3. Loc de parcare si loc de birou");
                                    int optiuneRez = Convert.ToInt32(Console.ReadLine());
                                    if (optiuneRez == 1)
                                    {
                                        Console.WriteLine("La ce nr doresti sa faci: ");
                                        int nrParc;
                                        do
                                        {
                                            Console.WriteLine("Limita maxima de locuri este: "+Parcare.GetNrLocuri());
                                            nrParc = Convert.ToInt32(Console.ReadLine());
                                        } while (nrParc > Parcare.GetNrLocuri());

                                        if (!Parcare.LocOcupat(nrParc))
                                        {
                                            Loc loc = new LocParcare(nrParc);
                                            angajats[rez].RezervareLoc(loc);
                                            Parcare.Update(nrParc);
                                        }
                                        else
                                        {
                                            throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                        }
                                    }
                                    else if(optiuneRez == 2)
                                    {
                                        Console.WriteLine("La ce nr doresti sa faci: ");
                                        int nrBirou;
                                        do // Aici parcarea trebuie inlocuita cu compania , cand o sa existe acele metode in companie
                                        {
                                            Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuri());
                                            nrBirou = Convert.ToInt32(Console.ReadLine());

                                        } while (nrBirou > Parcare.GetNrLocuri());
                                        Loc loc = new LocBirou(nrBirou);
                                        // si aici trebe sa lucreze victor
                                        angajats[rez].RezervareLoc(loc);
                                        Companie.Update(nrBirou);
                                    
                                    }
                                    else if(optiuneRez == 3)
                                    {
                                        Console.WriteLine("La ce nr de parcare doresti sa faci: ");
                                        int nrParc;
                                        do
                                        {
                                            Console.WriteLine("Limita maxila de locuri este: " + Parcare.GetNrLocuri());
                                            nrParc = Convert.ToInt32(Console.ReadLine());
                                        } while (nrParc > Parcare.GetNrLocuri());
                                        if (!Parcare.LocOcupat(nrParc))
                                        {
                                            Loc locP = new LocParcare(nrParc);
                                            angajats[rez].RezervareLoc(locP);
                                            Parcare.Update(nrParc);
                                        }
                                        else
                                        {
                                            throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                        }
                                            // aici trebuie sa lucreze victor


                                        Console.WriteLine("La ce nr de birou doresti sa faci: ");
                                        int nrBirou = Convert.ToInt32(Console.ReadLine());
                                        Loc locB = new LocBirou(nrBirou);
                                        angajats[rez].RezervareLoc(locB);
                                        Companie.Update(nrBirou);
                                    }
                                    else
                                    {
                                        throw new Exception("Undefined option!");
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 3:

                                angajats[rez].VizualizareRezervari();
                    
       
                                break;
                            case 4:
                                try
                                {
                                    int nrModf;
                                    angajats[rez].VizualizareRezervari();
                                    Console.WriteLine("Ce rezervare vrei sa modifici  ? ");
                               
                                    int indexRez=Convert.ToInt32(Console.ReadLine());
                               
                                    if (indexRez!=0 && indexRez <= angajats[rez].Rezervari.Count)
                                    {
                                        nrModf = angajats[rez].GetNumberFromRezervare(indexRez);
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid Rezervare");
                                    }

                                    if(angajats[rez].GetLocTypeFromRezervare(indexRez) is LocParcare) 
                                    {
                                        Parcare.Delete(nrModf);

                                        int nrModNew;
                                        Console.WriteLine("Noul loc de parcare rezervat este:");

                                        do
                                        {
                                            nrModNew = Convert.ToInt32(Console.ReadLine());
                                            if (Parcare.LocOcupat(nrModNew))
                                            {
                                                Console.WriteLine("Acel loc este ocupat!");
                                            }
                                        } while (Parcare.LocOcupat(nrModNew));
                                         
                                        angajats[rez].ModifRezervare(indexRez, nrModNew);

                                        Parcare.Update(nrModNew);

                                        angajats[rez].VizualizareRezervari();
                                    }
                                    else if(angajats[rez].GetLocTypeFromRezervare(indexRez) is LocBirou)
                                    {
                                        Companie.Delete(nrModf);

                                        Console.WriteLine("Noul loc de birou rezervat este:");

                                        int nrModNew = Convert.ToInt32(Console.ReadLine());

                                        angajats[rez].ModifRezervare(indexRez, nrModNew);

                                        Companie.Update(nrModNew);

                                        angajats[rez].VizualizareRezervari();
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid loc");
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);   
                                }
                                break;
                            case 5:
                                try
                                {
                                    int nrSters;
                                    angajats[rez].VizualizareRezervari();
                                    Console.WriteLine("Ce rezervare vrei sa stergi  ? ");
                                    int indexStergere = Convert.ToInt32(Console.ReadLine());

                                    if (indexStergere != 0 && indexStergere <= angajats[rez].Rezervari.Count)
                                    {
                                         nrSters = angajats[rez].GetNumberFromRezervare(indexStergere);
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid Rezervare");
                                    }

                                    if (angajats[rez].GetLocTypeFromRezervare(indexStergere) is LocParcare)
                                    { 
                                        Parcare.Delete(nrSters);

                                        angajats[rez].StergereRezervare(indexStergere);

                                        angajats[rez].VizualizareRezervari();
                                    }
                                    else if(angajats[rez].GetLocTypeFromRezervare(indexStergere) is LocBirou)
                                    {
                                        Companie.Delete(nrSters);

                                        angajats[rez].StergereRezervare(indexStergere);

                                        angajats[rez].VizualizareRezervari();
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid loc");
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                break;

                            case 6:
                                Console.Clear();
                                break;
                            case 0:
                                ExistaAngajat = true;
                                break;
                        }
                    }
                    break;
                case 2:
                    bool ExistaManager;
                    Console.WriteLine("Numele angajatului: ");
                    string numeMan = Console.ReadLine();
                    int rezMan = User.LogManager(manageri, numeMan);
                    if (rezMan != -1)
                    {
                        ExistaManager = false;
                        Console.WriteLine("Loggat cu succes!");
                    }
                    else
                    {
                        ExistaManager = true;
                        Console.WriteLine("Loggare fara succes!");
                    }
                    while (!ExistaManager)
                    {
                        Console.Write("\n");
                        Console.WriteLine("1.Vizualizare locuri de parcare si a locurilor la birou");
                        Console.WriteLine("2.Rezervare loc de parcare si/sau loc de birou");
                        Console.WriteLine("3.Vizualizare rezervari facute");
                        Console.WriteLine("4.Modificare rezervari facute");
                        Console.WriteLine("5.Stergere rezervari facute");
                        Console.WriteLine("6.Afisare echipa");
                        Console.WriteLine("7.Vizualizare rezervari facute de catre echipa");
                        Console.WriteLine("8.Modificare rezervari facute de catre echipa");
                        Console.WriteLine("9.Stergere rezervari facute de catre echipa");
                        Console.WriteLine("10.Console Clear");
                        Console.WriteLine("0.Back to login");
                        int optiuneManager = Convert.ToInt32(Console.ReadLine());
                        switch (optiuneManager)
                        {
                            case 1:
                                Console.WriteLine("Vizualizare locuri de parcare si a locurilor la birou");
                                break;
                            case 2:
                                Console.WriteLine("La ce vrei sa faci rezervare? ");
                                Console.WriteLine("1. Loc de parcare");
                                Console.WriteLine("2. Loc de birou");
                                Console.WriteLine("3. Loc de parcare si loc de birou");
                                int optiuneL= Convert.ToInt32(Console.ReadLine());

                                if (optiuneL == 1)
                                {
                                    Console.WriteLine("La ce nr doresti sa faci: ");
                                    int nrParc = Convert.ToInt32(Console.ReadLine());
                                    Loc loc = new LocParcare(nrParc);


                                }
                                else if (optiuneL == 2)
                                {
                                    Console.WriteLine("La ce nr doresti sa faci: ");
                                    int nrBirou = Convert.ToInt32(Console.ReadLine());
                                    Loc loc = new LocBirou(nrBirou);

              
                                }
                                else if (optiuneL == 3)
                                {
                                    Console.WriteLine("La ce nr de parcare doresti sa faci: ");
                                    int nrParc = Convert.ToInt32(Console.ReadLine());
                                    Loc locP = new LocParcare(nrParc);

                        

                                    Console.WriteLine("La ce nr de birou doresti sa faci: ");
                                    int nrBirou = Convert.ToInt32(Console.ReadLine());
                                    Loc locB = new LocBirou(nrBirou);

                       
                                }

                                break;
                            case 3:

                                Console.WriteLine("Manager rezervari: ");
                 

                                break;
                            case 4:

                   
                                Console.WriteLine("Ce rezervare vrei sa modifici  ? ");

                                int indexRez = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Noul loc rezervat este:");

                                int nrMod = Convert.ToInt32(Console.ReadLine());

                       


                   

                                break;
                            case 5:

                   
                                Console.WriteLine("Ce rezervare vrei sa stergi  ? ");

                                int indexStergere = Convert.ToInt32(Console.ReadLine());

                          





                                break;
                            case 6:
                                manageri[rezMan].echipa = angajats;
                                manageri[rezMan].afisareEchipa();

                                
                                    

                                break;
                            case 7:
                                
                                manageri[rezMan].VizualizareRezervariEchipa();

                                break;
                            case 8:
                                Console.WriteLine("La ce angajat modificam ?");

                                string numeAngajat=Console.ReadLine();

                                manageri[rezMan].ModificareRezervariEchipa(numeAngajat);

                                

                                break;
                            case 9:
                                Console.WriteLine("Stergere rezervari facute de catre echipa");
                                break;
                            case 10:
                                Console.Clear();
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