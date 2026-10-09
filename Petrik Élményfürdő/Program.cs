using System;

namespace PetrikElmenyfurdo
{
    internal class Program
    {
        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK ÉLMÉNYFÜRDŐ ===");
            Console.WriteLine();
            Console.WriteLine("1.) Belépőjegy vásárlása");
            Console.WriteLine("2.) Csúszdapark ellenőrzés");
            Console.WriteLine("3.) Éttermi kedvezmény kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");
            Console.WriteLine();
            Console.Write("Választás: ");
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor <= 5)
                return "Baba jegy";
            else if (eletkor <= 13)
                return "Gyerekjegy";
            else if (eletkor <= 17)
                return "Diákjegy";
            else if (eletkor <= 64)
                return "Felnőttjegy";
            else
                return "Nyugdíjas jegy";
        }

        static int JegyAr(int eletkor)
        {
            if (eletkor <= 5)
                return 0;
            else if (eletkor <= 13)
                return 1800;
            else if (eletkor <= 17)
                return 2400;
            else if (eletkor <= 64)
                return 3900;
            else
                return 2000;
        }

        static void CsuszdaEllenorzes()
        {
            Console.Clear();
            Console.WriteLine("=== CSÚSZDAPARK ===");
            Console.WriteLine();
            Console.WriteLine("1.) Mini Csúszda");
            Console.WriteLine("2.) Kamikaze");
            Console.WriteLine("3.) Black Hole");
            Console.WriteLine();
            Console.Write("Melyik csúszdát választod? ");
            int csuszda = Convert.ToInt32(Console.ReadLine());

            // Nem létező csúszdához nem kell magasságot megadni.
            if (csuszda < 1 || csuszda > 3)
            {
                Console.WriteLine("Nincs ilyen csúszda!");
                return;
            }

            Console.Write("Magasság: ");
            int magassag = Convert.ToInt32(Console.ReadLine());

            switch (csuszda)
            {
                case 1:
                    if (magassag >= 100)
                        Console.WriteLine("Használhatod a Mini Csúszdát!");
                    else
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    break;
                case 2:
                    if (magassag >= 140)
                        Console.WriteLine("Használhatod a Kamikazét!");
                    else
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    break;
                case 3:
                    if (magassag >= 120)
                        Console.WriteLine("Használhatod a Black Hole-t!");
                    else
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    break;
                default:
                    Console.WriteLine("Nincs ilyen csúszda!");
                    break;
            }
        }

        static int KedvezmenyesAr(int osszeg, int kedvezmeny)
        {
            switch (kedvezmeny)
            {
                case 1:
                    return osszeg;
                case 2:
                    return osszeg - osszeg * 15 / 100;
                case 3:
                    return osszeg - osszeg * 20 / 100;
                default:
                    return osszeg;
            }
        }

        static void EttermiKalkulator()
        {
            Console.Clear();
            Console.WriteLine("=== ÉTTERMI KEDVEZMÉNY ===");
            Console.WriteLine();
            Console.WriteLine("1.) Nincs kedvezmény");
            Console.WriteLine("2.) Diákkedvezmény - 15%");
            Console.WriteLine("3.) Családi kedvezmény - 20%");
            Console.WriteLine();
            Console.Write("Eredeti összeg: ");
            int osszeg = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kedvezmény: ");
            int kedvezmeny = Convert.ToInt32(Console.ReadLine());

            if (kedvezmeny >= 1 && kedvezmeny <= 3)
            {
                int fizetendo = KedvezmenyesAr(osszeg, kedvezmeny);
                Console.WriteLine($"Fizetendő: {fizetendo} Ft");
            }
            else
            {
                Console.WriteLine("Nincs ilyen kedvezménytípus!");
            }
        }

        static void Main(string[] args)
        {
            int bevetel = 0;
            int valasztas = 0;

            do
            {
                Console.Clear();
                MenuKiir();

                try
                {
                    valasztas = Convert.ToInt32(Console.ReadLine());

                    switch (valasztas)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== BELÉPŐJEGY VÁSÁRLÁSA ===");
                            Console.WriteLine();
                            Console.Write("Név: ");
                            string nev = Console.ReadLine();
                            Console.Write("Életkor: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor < 0 || eletkor > 120)
                            {
                                Console.WriteLine("Hibás életkor!");
                            }
                            else
                            {
                                string jegyTipus = JegyTipus(eletkor);
                                int ar = JegyAr(eletkor);
                                Console.WriteLine($"Szia {nev}!");
                                Console.WriteLine($"Jegytípus: {jegyTipus}");
                                Console.WriteLine($"Fizetendő: {ar} Ft");
                                bevetel += ar;
                            }
                            break;

                        case 2:
                            CsuszdaEllenorzes();
                            break;

                        case 3:
                            EttermiKalkulator();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("=== NAPI BEVÉTEL ===");
                            Console.WriteLine($"A fürdő mai bevétele: {bevetel} Ft");
                            break;

                        case 5:
                            Console.WriteLine("Viszlát!");
                            break;

                        default:
                            Console.WriteLine("Válassz az 1-5 lehetőség közül!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hiba! Számot kell megadni!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Hiba! Számot kell megadni!");
                }

                if (valasztas != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nyomj Entert a főmenühöz!");
                    Console.ReadLine();
                }
            } while (valasztas != 5);
        }
    }
}
