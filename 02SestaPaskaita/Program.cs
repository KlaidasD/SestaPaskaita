using System;

namespace SestaPaskaita
{
    public class Program
    {
        /*Užduotis: Sukurti programą, kuri leis vartotojams valdyti automobilių nuomos sistemą, įskaitant automobilių pridėjimą, nuomą, grąžinimą ir paiešką.
        Užduoties Aprašymas:

        Sukurkite konsolinę programą, kurioje bus naudojami sąrašai ir masyvai automobiliams ir klientams saugoti.

        Programa turėtų leisti:
        Pridėti naują automobilį į nuomos sistemą su unikaliu automobilio identifikaciniu numeriu (VIN), marke, modeliu, metais ir bendru egzempliorių skaičiumi.
        Redaguoti automobilio informaciją (markę, modelį, metus, bendrą egzempliorių skaičių).
        Paieškoti automobilių pagal VIN, markę ar modelį.
        Rodyti visą automobilių nuomos katalogą su informacija apie kiekvieną automobilį (VIN, markė, modelis, metai, prieinamas egzempliorių skaičius).
        Nuomoti automobilį klientui (klientas turi turėti ID ir vardą).
        Grąžinti automobilį į nuomos sistemą.
        Rodyti visus nuomotus automobilius ir informaciją apie juos (kliento ID, vardą, automobilio VIN, nuomos pradžios datą).
        Ištrinti automobilį iš sistemos (tik jei automobilis nėra nuomojamas).

        Reikalavimai:
        Automobilių sąrašas turėtų būti dinamiškas (naudoti sąrašus).
        Kiekvienas automobilis turi turėti unikalų VIN.
        Nuomos metu patikrinti, ar automobilis yra prieinamas.
        Naudoti ciklus ir sąlygas duomenų tikrinimui ir operacijoms atlikti.
        Naudoti switch teiginį meniu veiksmams pasirinkti.
        Papildomi reikalavimai:
        Užtikrinti, kad vienas automobilis negali būti nuomojamas daugiau nei vienam klientui vienu metu.
        Leisti vartotojui ieškoti automobilių pagal įvairius kriterijus (VIN, markę, modelį, metus).
        Leisti atnaujinti automobilio informaciją (markę, modelį, metus, bendrą egzempliorių skaičių).
        Registruoti nuomos pradžios ir pabaigos datas.

        Meniu pavyzdys:
        Pridėti automobilį
        Prideti klienta
        Redaguoti automobilio informaciją
        Ieskoti automobilio (VIN, marke, modelis, metai)
        Rodyti visus automobilius
        Nuomoti automobilį
        Grąžinti automobilį
        Rodyti visus nuomotus automobilius
        Ištrinti automobilį
        Išeiti iš programos*/

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.Prideti automobili.");
                Console.WriteLine("2.Prideti klienta");
                Console.WriteLine("3.Redaguoti automobilio informacija");
                Console.WriteLine("4.Ieskoti automobilio");
                Console.WriteLine("5.Rodyti visus automobilius");
                Console.WriteLine("6.Nuomoti automobili");
                Console.WriteLine("7.Grazinti automobili");
                Console.WriteLine("8.Rodyti visus nuomotus automobilius");
                Console.WriteLine("9.Istrinti automobili");
                Console.WriteLine("0.Iseiti is programos");

                int ivestis;

                if (!int.TryParse(Console.ReadLine(), out ivestis))
                {
                    Console.WriteLine("Neteisingas veiksmo numeris.");
                    continue;
                }

                switch (ivestis)
                {
                    case 1:
                        Funkcijos.PridetiAutomobili();
                        break;
                    case 2:
                        Funkcijos.PridetiKlienta();
                        break;
                    case 3:
                        Funkcijos.RedaguotiAuto();
                        break;
                    case 4:
                        Funkcijos.IeskotiAutomobilio();
                        break;
                    case 5:
                        Funkcijos.RodytiVisusAuto();
                        break;
                    case 6:
                        Funkcijos.NuomotiAutomobili();
                        break;
                    case 7:
                        Funkcijos.GrazintiAutomobili();
                        break;
                    case 8:
                        Funkcijos.RodytiVisusNuomotus();
                        break;
                    case 9:
                        Funkcijos.IstrintiAuto();
                        break;
                    case 0:
                        Console.WriteLine("Programa isjungiama.");
                        Environment.Exit(0);
                        break; ;
                    default:
                        Console.WriteLine("Neteisingas veiksmo numeris.");
                        return;
                }
            }
        }
    }
}