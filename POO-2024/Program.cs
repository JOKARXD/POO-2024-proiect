

using POO_2024;

public class Program
{
    public static void Main() // testarea UI pentru clase                                
    {
        List<Angajat> angajats = User.GetAngajati();
        List<Manager> manageri = User.GetManageri();
        Admin administrator = User.GetAdmin();



        while (true)
        {
            Console.WriteLine("Logare:");
            Console.WriteLine("1.Angajat");
            Console.WriteLine("2.Manager");
            Console.WriteLine("3.Admin");
            Console.WriteLine("0.Exit");
            int optiune=-1;
            try // aici trebuie sa gasesc o rezolvare
            {
                string input = Console.ReadLine();

                if(int.TryParse(input, out optiune))
                {
                    if(optiune > 4)
                    {
                        throw new Exception("Optiune gresita!");
                    }
                }
                else
                {
                    throw new Exception("Eroare la citirea de optiune!Try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
                        try
                        {
                            Console.WriteLine("Introduceti o optiune:");
                            string input=Console.ReadLine();
                            int optiuneAngajat;
                            if(int.TryParse(input, out optiuneAngajat))
                            {
                                switch (optiuneAngajat) 
                                {
                                    case 1:
                                        Console.WriteLine("------------------------PARCAREA----------------------------");
                                        Parcare.ShowAll();
                                        Console.Write("\n");
                                        Console.WriteLine("------------------------COMPANIA----------------------------");
                                        Companie.ShowAll();
                                        Console.Write("\n");
                                        break;
                                    case 2: 
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
                                                    Console.WriteLine("Limita maxima de locuri este: "+Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());

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
                                                do 
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Companie.GetNrLocuriBirou());
                                                    nrBirou = Convert.ToInt32(Console.ReadLine());

                                                } while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc loc_birou = new LocBirou(nrBirou);
                                                    angajats[rez].RezervareLoc(loc_birou);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este ocupat, te rugam sa alegi altceva!");
                                                }
                                    
                                            }
                                            else if(optiuneRez == 3)
                                            {
                                                Console.WriteLine("La ce nr de parcare doresti sa faci rezervarea: ");
                                                int nrParc;
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());
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
                                                int nrBirou;
                                                Console.WriteLine("La ce nr de birou doresti sa faci rezervarea: ");
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este "+ Companie.GetNrLocuriBirou());
                                                     nrBirou = Convert.ToInt32(Console.ReadLine());
                                                }while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc locB = new LocBirou(nrBirou);
                                                    angajats[rez].RezervareLoc(locB);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este rezervat, te rugam sa alegi altceva!");
                                                }
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
                                            if (!User.AcceptareModificare())
                                            {
                                                throw new Exception("Administratorul nu este de acord cu aceasta modificare");
                                            }
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

                                                int nrModNew;

                                                do
                                                {
                                                    nrModNew = Convert.ToInt32(Console.ReadLine());
                                                    if (Companie.LocOcupat(nrModNew))
                                                    {
                                                        Console.WriteLine("Acel loc este ocupat!");
                                                    }
                                                } while (Companie.LocOcupat(nrModNew));

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
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception("Eroarea la citirea de optiune! Try again");
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 2:
                    bool ExistaManager;
                    Console.WriteLine("Numele angajatului: ");
                    string numeMan = Console.ReadLine();
                    int rezMan = User.LogManager(manageri, numeMan);
                    manageri[rezMan].echipa = angajats;
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
                        try
                        {
                            Console.WriteLine("Introduceti o optiune:");
                            string input=Console.ReadLine();
                            int optiuneManager;
                            if(int.TryParse(input, out optiuneManager))
                            {
                                switch (optiuneManager)
                                {
                                    case 1:
                                        Console.WriteLine("------------------------PARCAREA----------------------------");
                                        Parcare.ShowAll();
                                        Console.Write("\n");
                                        Console.WriteLine("------------------------COMPANIA----------------------------");
                                        Companie.ShowAll();
                                        Console.Write("\n");

                                        break;
                                    case 2:
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
                                                    Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());

                                                if (!Parcare.LocOcupat(nrParc))
                                                {
                                                    Loc loc = new LocParcare(nrParc);
                                                    manageri[rezMan].RezervareLoc(loc);
                                                    Parcare.Update(nrParc);
                                                }
                                                else
                                                {
                                                    throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                                }
                                            }
                                            else if (optiuneRez == 2)
                                            {
                                                Console.WriteLine("La ce nr doresti sa faci: ");
                                                int nrBirou;
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Companie.GetNrLocuriBirou());
                                                    nrBirou = Convert.ToInt32(Console.ReadLine());

                                                } while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc loc_birou = new LocParcare(nrBirou);
                                                    manageri[rezMan].RezervareLoc(loc_birou);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este ocupat, te rugam sa alegi altceva!");
                                                }

                                            }
                                            else if (optiuneRez == 3)
                                            {
                                                Console.WriteLine("La ce nr de parcare doresti sa faci rezervarea: ");
                                                int nrParc;
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());
                                                if (!Parcare.LocOcupat(nrParc))
                                                {
                                                    Loc locP = new LocParcare(nrParc);
                                                    manageri[rezMan].RezervareLoc(locP);
                                                    Parcare.Update(nrParc);
                                                }
                                                else
                                                {
                                                    throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                                }
                                                int nrBirou;
                                                Console.WriteLine("La ce nr de birou doresti sa faci rezervarea: ");
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este " + Companie.GetNrLocuriBirou());
                                                    nrBirou = Convert.ToInt32(Console.ReadLine());
                                                } while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc locB = new LocBirou(nrBirou);
                                                    manageri[rezMan].RezervareLoc(locB);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este rezervat, te rugam sa alegi altceva!");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Undefined option!");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;
                                    case 3:

                                        manageri[rezMan].VizualizareRezervari();

                                        break;
                                    case 4:
                                        try
                                        {
                                            if (!User.AcceptareModificare())
                                            {
                                                throw new Exception("Administratorul nu este de acord cu aceasta modificare");
                                            }
                                            int nrModf;
                                            manageri[rezMan].VizualizareRezervari();
                                            Console.WriteLine("Ce rezervare vrei sa modifici  ? ");

                                            int indexRez = Convert.ToInt32(Console.ReadLine());

                                            if (indexRez != 0 && indexRez <= manageri[rezMan].Rezervari.Count)
                                            {
                                                nrModf = manageri[rezMan].GetNumberFromRezervare(indexRez);
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid Rezervare");
                                            }

                                            if (manageri[rezMan].GetLocTypeFromRezervare(indexRez) is LocParcare)
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

                                                manageri[rezMan].ModifRezervare(indexRez, nrModNew);

                                                Parcare.Update(nrModNew);

                                                manageri[rezMan].VizualizareRezervari();
                                            }
                                            else if (manageri[rezMan].GetLocTypeFromRezervare(indexRez) is LocBirou)
                                            {
                                                Companie.Delete(nrModf);

                                                int nrModNew;
                                                Console.WriteLine("Noul loc de birou rezervat este:");

                                                do
                                                {
                                                    nrModNew = Convert.ToInt32(Console.ReadLine());
                                                    if (Companie.LocOcupat(nrModNew))
                                                    {
                                                        Console.WriteLine("Acel loc este ocupat!");
                                                    }
                                                } while (Companie.LocOcupat(nrModNew));

                                                manageri[rezMan].ModifRezervare(indexRez, nrModNew);

                                                Companie.Update(nrModNew);

                                                manageri[rezMan].VizualizareRezervari();
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid loc");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;
                                    case 5:
                                        try
                                        {
                                            int nrSters;
                                            manageri[rezMan].VizualizareRezervari();
                                            Console.WriteLine("Ce rezervare vrei sa stergi  ? ");
                                            int indexStergere = Convert.ToInt32(Console.ReadLine());

                                            if (indexStergere != 0 && indexStergere <= manageri[rezMan].Rezervari.Count)
                                            {
                                                nrSters = manageri[rezMan].GetNumberFromRezervare(indexStergere);
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid Rezervare");
                                            }

                                            if (manageri[rezMan].GetLocTypeFromRezervare(indexStergere) is LocParcare)
                                            {
                                                Parcare.Delete(nrSters);

                                                manageri[rezMan].StergereRezervare(indexStergere);

                                                manageri[rezMan].VizualizareRezervari();
                                            }
                                            else if (manageri[rezMan].GetLocTypeFromRezervare(indexStergere) is LocBirou)
                                            {
                                                Companie.Delete(nrSters);

                                                manageri[rezMan].StergereRezervare(indexStergere);

                                                manageri[rezMan].VizualizareRezervari();
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid loc");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }

                                        break;
                                    case 6:
                                        manageri[rezMan].afisareEchipa();
                                        break;
                                    case 7:
                                
                                        manageri[rezMan].VizualizareRezervariEchipa();

                                        break;
                                    case 8:
                                        try
                                        {
                                            Console.WriteLine("La ce angajat modificam ?");

                                            if (!User.AcceptareModificare())
                                            {
                                                throw new Exception("Administratorul nu este de accord cu aceasta modificare");
                                            }

                                            manageri[rezMan].afisareEchipa();

                                            int indexAngajat=Convert.ToInt32(Console.ReadLine());

                                            if(indexAngajat>0 && indexAngajat <= angajats.Count)
                                            {
                                                Angajat angajat = angajats[indexAngajat - 1];

                                                if(angajat.Rezervari.Count == 0)
                                                {
                                                    throw new Exception("Acest angajat nu are nici o rezervare facuta momentan!");
                                                }
                                                if (manageri[rezMan].VerificareAngajat(angajat))
                                                {
                                                    angajat.VizualizareRezervari();
                                                    int nrModf;
                                                    Console.WriteLine("Ce rezervare vrei sa modifici  ? ");

                                                    int indexRez = Convert.ToInt32(Console.ReadLine());

                                                    if (indexRez != 0 && indexRez <= angajat.Rezervari.Count)
                                                    {
                                                        nrModf = angajat.GetNumberFromRezervare(indexRez);
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Invalid Rezervare");
                                                    }

                                                    if (angajat.GetLocTypeFromRezervare(indexRez) is LocParcare)
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

                                                        manageri[rezMan].ModificareRezervariEchipa(angajat, indexRez, nrModNew);

                                                        Parcare.Update(nrModNew);

                                                        angajat.VizualizareRezervari();
                                                    }
                                                    else if (angajat.GetLocTypeFromRezervare(indexRez) is LocBirou)
                                                    {
                                                        Companie.Delete(nrModf);

                                                        int nrModNew;
                                                        Console.WriteLine("Noul loc de birou rezervat este:");

                                                        do
                                                        {
                                                            nrModNew = Convert.ToInt32(Console.ReadLine());
                                                            if (Parcare.LocOcupat(nrModNew))
                                                            {
                                                                Console.WriteLine("Acel loc este ocupat!");
                                                            }
                                                        } while (Parcare.LocOcupat(nrModNew));

                                                        manageri[rezMan].ModificareRezervariEchipa(angajat,indexRez, nrModNew);

                                                        Companie.Update(nrModNew);

                                                        angajat.VizualizareRezervari();
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Invalid loc");
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("Angajatul nu se afla in echipa!");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Numar al angajatului invalid!");
                                            }
                                        }catch(Exception e) 
                                        {
                                            Console.WriteLine(e.Message);
                                        }


                                        break;
                                    case 9:
                                        try
                                        {
                                            Console.WriteLine("La ce angajat stergem ?");

                                            manageri[rezMan].afisareEchipa();

                                            int indexAngajat = Convert.ToInt32(Console.ReadLine());

                                            if (indexAngajat > 0 && indexAngajat <= angajats.Count)
                                            {
                                                Angajat angajat = angajats[indexAngajat - 1];

                                                if (angajat.Rezervari.Count == 0)
                                                {
                                                    throw new Exception("Acest angajat nu are nici o rezervare facuta momentan!");
                                                }
                                                if (manageri[rezMan].VerificareAngajat(angajat)) 
                                                {
                                                    angajat.VizualizareRezervari();
                                                    int nrSters;
                                                    Console.WriteLine("Ce rezervare vrei sa stergi  ? ");
                                                    int indexStergere = Convert.ToInt32(Console.ReadLine());

                                                    if (indexStergere != 0 && indexStergere <= angajat.Rezervari.Count)
                                                    {
                                                        nrSters = angajat.GetNumberFromRezervare(indexStergere);
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Invalid Rezervare");
                                                    }
                                                    if (angajat.GetLocTypeFromRezervare(indexStergere) is LocParcare)
                                                    {
                                                        Parcare.Delete(nrSters);

                                                        manageri[rezMan].StergereRezervareEchipa(angajat,indexStergere);

                                                        angajat.VizualizareRezervari();
                                                    }
                                                    else if(angajat.GetLocTypeFromRezervare(indexStergere) is LocBirou)
                                                    {
                                                        Companie.Delete(nrSters);

                                                        manageri[rezMan].StergereRezervareEchipa(angajat, indexStergere);

                                                        angajat.VizualizareRezervari();
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Invalid loc");
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("Angajatul nu se afla in echipa!");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Numar al angajatului invalid!");
                                            }
                                        }
                                        catch(Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;
                                    case 10:
                                        Console.Clear();
                                        break;
                                    case 0:
                                        ExistaManager = true;
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception("Eroarea la citirea de optiune! Try again");
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;

                case 3:
                    bool ExistaAdmin;
                    Console.WriteLine("Nume  admin: ");
                    string numeAdmin = Console.ReadLine();
                    if (User.LogAdmin(administrator, numeAdmin))
                    {
                        ExistaAdmin = false;
                        Console.WriteLine("Logat cu succes!");
                    }
                    else
                    {
                        ExistaAdmin= true;
                        Console.WriteLine("Logare fara succes!");
                    }
                    while (!ExistaAdmin)
                    {
                        Console.Write("\n");
                        Console.WriteLine("1.Vizualizare locuri de parcare si a locurilor la birou");
                        Console.WriteLine("2.Rezervare loc de parcare si/sau loc de birou");
                        Console.WriteLine("3.Vizualizare rezervari facute");
                        Console.WriteLine("4.Modificare rezervari facute");
                        Console.WriteLine("5.Stergere rezervari facute");
                        Console.WriteLine("6.Vizualizarea tuturor rezervariilor");
                        Console.WriteLine("7.Modificare orice rezervare");
                        Console.WriteLine("8.Console Clear");
                        Console.WriteLine("0.Back to login");
                        try
                        {
                            Console.WriteLine("Introduceti o optiune:");
                            string input = Console.ReadLine();
                            int optiuneAdm;
                            if(int.TryParse(input, out optiuneAdm)) // si aici posibil
                            {
                                switch (optiuneAdm)
                                {
                                    case 1:
                                        Console.WriteLine("------------------------PARCAREA----------------------------");
                                        Parcare.ShowAll();
                                        Console.Write("\n");
                                        Console.WriteLine("------------------------COMPANIA----------------------------");
                                        Companie.ShowAll();
                                        Console.Write("\n");
                                        break;
                                    case 2:
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
                                                    Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());

                                                if (!Parcare.LocOcupat(nrParc))
                                                {
                                                    Loc loc = new LocParcare(nrParc);
                                                    administrator.RezervareLoc(loc);
                                                    Parcare.Update(nrParc);
                                                }
                                                else
                                                {
                                                    throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                                }
                                            }
                                            else if (optiuneRez == 2)
                                            {
                                                Console.WriteLine("La ce nr doresti sa faci: ");
                                                int nrBirou;
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Companie.GetNrLocuriBirou());
                                                    nrBirou = Convert.ToInt32(Console.ReadLine());

                                                } while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc loc_birou = new LocParcare(nrBirou);
                                                    administrator.RezervareLoc(loc_birou);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este ocupat, te rugam sa alegi altceva!");
                                                }

                                            }
                                            else if (optiuneRez == 3)
                                            {
                                                Console.WriteLine("La ce nr de parcare doresti sa faci rezervarea: ");
                                                int nrParc;
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este: " + Parcare.GetNrLocuriParcare());
                                                    nrParc = Convert.ToInt32(Console.ReadLine());
                                                } while (nrParc > Parcare.GetNrLocuriParcare());
                                                if (!Parcare.LocOcupat(nrParc))
                                                {
                                                    Loc locP = new LocParcare(nrParc);
                                                    administrator.RezervareLoc(locP);
                                                    Parcare.Update(nrParc);
                                                }
                                                else
                                                {
                                                    throw new Exception("Loc de parcare rezervat, te rugam sa alegi altceva!");
                                                }
                                                int nrBirou;
                                                Console.WriteLine("La ce nr de birou doresti sa faci rezervarea: ");
                                                do
                                                {
                                                    Console.WriteLine("Limita maxima de locuri este " + Companie.GetNrLocuriBirou());
                                                    nrBirou = Convert.ToInt32(Console.ReadLine());
                                                } while (nrBirou > Companie.GetNrLocuriBirou());
                                                if (!Companie.LocOcupat(nrBirou))
                                                {
                                                    Loc locB = new LocBirou(nrBirou);
                                                    administrator.RezervareLoc(locB);
                                                    Companie.Update(nrBirou);
                                                }
                                                else
                                                {
                                                    throw new Exception("Locul la birou este rezervat, te rugam sa alegi altceva!");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Undefined option!");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                    case 3:
                                        administrator.VizualizareRezervari();
                                        break;
                                    case 4:
                                        try
                                        {
                                            int nrModf;
                                            administrator.VizualizareRezervari();
                                            Console.WriteLine("Ce rezervare vrei sa modifici  ? ");

                                            int indexRez = Convert.ToInt32(Console.ReadLine());

                                            if (indexRez != 0 && indexRez <= administrator.Rezervari.Count)
                                            {
                                                nrModf = administrator.GetNumberFromRezervare(indexRez);
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid Rezervare");
                                            }

                                            if (administrator.GetLocTypeFromRezervare(indexRez) is LocParcare)
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

                                                administrator.ModifRezervare(indexRez, nrModNew);

                                                Parcare.Update(nrModNew);

                                                administrator.VizualizareRezervari();
                                            }
                                            else if (administrator.GetLocTypeFromRezervare(indexRez) is LocBirou)
                                            {
                                                Companie.Delete(nrModf);

                                                Console.WriteLine("Noul loc de birou rezervat este:");

                                                int nrModNew = Convert.ToInt32(Console.ReadLine());

                                                administrator.ModifRezervare(indexRez, nrModNew);

                                                Companie.Update(nrModNew);

                                                administrator.VizualizareRezervari();
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid loc");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                    case 5:
                                        try
                                        {
                                            int nrSters;
                                            administrator.VizualizareRezervari();
                                            Console.WriteLine("Ce rezervare vrei sa stergi  ? ");
                                            int indexStergere = Convert.ToInt32(Console.ReadLine());

                                            if (indexStergere != 0 && indexStergere <= administrator.Rezervari.Count)
                                            {
                                                nrSters = administrator.GetNumberFromRezervare(indexStergere);
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid Rezervare");
                                            }

                                            if (administrator.GetLocTypeFromRezervare(indexStergere) is LocParcare)
                                            {
                                                Parcare.Delete(nrSters);

                                                administrator.StergereRezervare(indexStergere);

                                                administrator.VizualizareRezervari();
                                            }
                                            else if (administrator.GetLocTypeFromRezervare(indexStergere) is LocBirou)
                                            {
                                                Companie.Delete(nrSters);

                                                administrator.StergereRezervare(indexStergere);

                                                administrator.VizualizareRezervari();
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid loc");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }

                                        break;
                                    case 6: administrator.VizualizareToateRezervari(manageri,angajats);
                                        break;
                                    case 7:
                                        try
                                        {
                                            int nrModf;
                                            List<Rezervare> RezervariTotale = Admin.GetAllRezervari(manageri, angajats);
                                            administrator.ShowAllRezervari(manageri,angajats);
                                            Console.WriteLine("Ce rezervare vrei sa modifici  ? ");

                                            int indexRez = Convert.ToInt32(Console.ReadLine());

                                            if (indexRez != 0 && indexRez <= RezervariTotale.Count)
                                            {
                                                nrModf = administrator.GetRezNumber(RezervariTotale, indexRez);
                                            }
                                            else
                                            {
                                                throw new Exception("Invalid Rezervare");
                                            }

                                            if (administrator.GetLocType(RezervariTotale,indexRez) is LocParcare)
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

                                                administrator.Modificare(RezervariTotale,indexRez, nrModNew);


                                                Parcare.Update(nrModNew);

                                            }
                                            else if (administrator.GetLocTypeFromRezervare(indexRez) is LocBirou)
                                            {
                                                Companie.Delete(nrModf);

                                                Console.WriteLine("Noul loc de birou rezervat este:");

                                                int nrModNew;
                                                do
                                                {
                                                    nrModNew = Convert.ToInt32(Console.ReadLine());
                                                    if (Companie.LocOcupat(nrModNew))
                                                    {
                                                        Console.WriteLine("Acel loc este ocupat!");
                                                    }
                                                } while (Companie.LocOcupat(nrModNew));

                                                administrator.Modificare(RezervariTotale, indexRez, nrModNew);

                                                Companie.Update(nrModNew);

                                            }
                                            else
                                            {
                                                throw new Exception("Invalid loc");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;
                                    case 8:
                                        Console.Clear();
                                        break;
                                    case 0:
                                        ExistaAdmin=true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                throw new Exception("Eroarea la citirea de optiune! Try again");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
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