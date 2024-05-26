using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;

namespace SestaPaskaita
{
    public class Program
    {

        /*Užduotis: Sukurti programą, kuri leis vartotojui įvesti filmų sąrašą ir jų reitingus, o po to atliks įvairias operacijas su šiais duomenimis.
         * 
        Užduoties Aprašymas:
        Sukurkite konsolinę programą, kuri leis vartotojui įvesti n filmų pavadinimus ir jų reitingus (nuo 1 iki 10).
        Duomenis saugokite sąraše ar masyve.
        Leiskite vartotojui pasirinkti iš meniu, ką jis nori atlikti su įvestais duomenimis:
        a. Rodyti visus filmus ir jų reitingus.
        b. Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
        c. Rasti filmą pagal pavadinimą ir parodyti jo reitingą.
        d. Atnaujinti filmo reitingą.
        e. Ištrinti filmą iš sąrašo.
        f. Išeiti iš programos.*/

        public static List<Filmas> sarasas = new List<Filmas>();
        
        public static Filmas SukurtiFilma()

        {
            int eilesNr = sarasas.Count + 1;
            Console.WriteLine("Iveskite filmo pavadinima.");

            string pavadinimas = Console.ReadLine();

            double reitingas;

            Console.WriteLine("Iveskite filmo reitinga");
            if(!double.TryParse(Console.ReadLine(), out reitingas))
            {
                Console.WriteLine("Neteisingai ivestas reitingas.");
            }

            Filmas filmas = new Filmas(eilesNr, pavadinimas, reitingas);
            return filmas;
        }
        
        static void AtspausdintiSarasa()
        {
            foreach(Filmas filmas in sarasas)
            {
                Console.WriteLine(filmas);
            }
        }

        static void RodytiSuDidesniu(double reitingas)
        {
            foreach (Filmas filmas in sarasas)
            {
                if (reitingas >= filmas.Reitingas)
                {
                    Console.WriteLine(filmas);
                }
            }
        }

        static void RodytiPagalPav(string pavadinimas)
        {
            foreach (Filmas filmas in sarasas)
            {
                if (filmas.Pavadinimas.Contains(pavadinimas))
                {
                    Console.WriteLine(filmas);
                }
            }
        }

        static void IstrintiFilma(int eilesNr)
        {
            Filmas filmasTrinamas = new Filmas();

            foreach(Filmas filmas in sarasas)
            {
                if (eilesNr == filmas.EilNr)
                {
                    filmasTrinamas = filmas;
                }
            }

            sarasas.Remove(filmasTrinamas);
            Console.WriteLine("Filmas sekmingai istrintas."); 
        }

        static void AtnaujintiReitinga(int eilesNr, double reitingas)
        {
            foreach(Filmas filmas in sarasas)
            {
                if(eilesNr == filmas.EilNr)
                {
                    filmas.Reitingas = reitingas;
                }
            }
            Console.WriteLine("Sekmingai atnaujintas filmo reitingas.");
        }

        public static void Main(string[] args)
        {
           

            while (true)
            {
                Console.WriteLine("Sveiki, pasirinkite programos funkcija.." +
                    "\n0. Ivesti nauja filma." +
                    "\n1.Rodyti visus filmus ir reitingus is saraso." +
                    "\n2.Rodyti filmus tik su didesniu, nei bus nurodytas reitingu." +
                    "\n3.Rasti filma pagal pavadinima ir suzinoti jo reitinga." +
                    "\n4.Atnaujinti filmo is saraso reitinga." +
                    "\n5.Istrinti filma is saraso." +
                    "\n6.Iseiti is programos.");

                int ivestis;

                if(!int.TryParse(Console.ReadLine(), out ivestis))
                {
                    Console.WriteLine("Netinkamas pasirinkimas.");
                }

                if (ivestis == 0)
                {
                    Console.WriteLine("Iveskite filmo duomenis kai ju paprasys..");
                    sarasas.Add(SukurtiFilma());
                }

                if (ivestis == 1)
                {
                    Console.WriteLine("Atspausdinimas filmu sarasas.");
                    AtspausdintiSarasa();
                }

                if (ivestis == 2)
                {
                    Console.WriteLine("Iveskite reitinga.");

                    double reitingas;

                    if(!double.TryParse(Console.ReadLine(), out reitingas))
                    {
                        Console.WriteLine("Netinkamai pasirinkta funkcija");
                    }

                    Console.WriteLine($"Spausdinami filmai su didesniu arba lygiu jusu nurodytam reitingui.\nJusu pasirinkimas {reitingas}");
                    RodytiSuDidesniu(reitingas);
                }

                if (ivestis == 3)
                {
                    Console.WriteLine("Iveskite filmo pavadinima arba pavadinimo dali.");

                    string pavadinimas = Console.ReadLine();

                    Console.WriteLine("Spausdinami filmai atitinkantys jusu nurodyta pavadinima.");
                    RodytiPagalPav(pavadinimas);
                }

                if (ivestis == 4)
                {
                    Console.WriteLine($"Spausdinamas filmu sarasas...");
                    AtspausdintiSarasa();

                    Console.WriteLine("Iveskite filmo (Eil.Nr) kurio reitinga norite atnaujinti.");
                    int eilesNr;

                    if (!int.TryParse(Console.ReadLine(), out eilesNr))
                    {
                        Console.WriteLine("Netinkamai ivestas eilesNr");
                    }

                    if (sarasas.Count() <= 0)
                    {
                        Console.WriteLine("Sarase nera filmu.");
                    }

                    Console.WriteLine("Iveskite atnaujinta reitinga.");

                    double reitingas;

                    if(!double.TryParse(Console.ReadLine(), out reitingas))
                        {
                            Console.WriteLine("Netinkamai ivestas reitingas.");
                        }

                    AtnaujintiReitinga(eilesNr, reitingas);
                }

                if (ivestis == 5)
                {
                    Console.WriteLine($"Spausdinamas filmu sarasas...");
                    AtspausdintiSarasa();

                    Console.WriteLine("Iveskite filmo (Eil.Nr) kuri norite pasalinti.");

                    int eilesNr;

                    if (!int.TryParse(Console.ReadLine(), out eilesNr))
                    {
                        Console.WriteLine("Netinkamai ivestas eilesNr");
                    }

                    if (sarasas.Count() <= 0)
                    {
                        Console.WriteLine("Sarase nera filmu.");
                    }

                    IstrintiFilma(eilesNr);
                }

                if (ivestis == 6)
                {
                    Console.WriteLine("Uzdaroma programa..");
                    Environment.Exit(0);
                }
            }

        }
    }
}