using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SestaPaskaita
{
    public static class Funkcijos
    {
        public static List<Automobilis> automobiliai = new List<Automobilis>();
        public static List<Klientas> klientai = new List<Klientas>();

        public static void PridetiAutomobili()
        {
            Console.WriteLine("Iveskite VIN koda: ");
            string vin = Console.ReadLine();

            foreach (Automobilis x in automobiliai)
            {
                if (x.VIN == vin)
                {
                    Console.WriteLine("Automobilis su tokiu VIN jau yra sarase.");
                }
            }

            Console.WriteLine("Iveskite automobilio marke: ");
            string marke = Console.ReadLine();
            Console.WriteLine("Iveskite automobilio modeli: ");
            string modelis = Console.ReadLine();

            Console.WriteLine("Iveskite automobilio pagaminimo metus: ");
            int metai;

            if (!int.TryParse(Console.ReadLine(), out metai))
            {
                Console.WriteLine("Netinkamai ivesti automobilio metai..");
                return;
            }

            bool ArIsnuomotas = false;

            Automobilis automobilis = new Automobilis(vin, marke, modelis, metai, ArIsnuomotas);
            automobiliai.Add(automobilis);
            automobilis.BendrasKiekis++;
            automobilis.PrieinamasKiekis++;
            Console.WriteLine($"Sekmingai pridetas automobilis su siais duomenimis: {automobilis}");
        }

        public static void PridetiKlienta()
        {
            Console.WriteLine("Iveskite naujo kliento varda: ");
            string vardas = Console.ReadLine();
            int id = klientai.Count + 1;
            Klientas klientas = new Klientas(id, vardas);
            klientai.Add(klientas);
            Console.WriteLine("Klientas sekmingai pridetas.");
        }

        public static void NuomotiAutomobili()
        {
            Console.WriteLine("Pasirinkite klienta is saraso: ");
            foreach (Klientas klientas in klientai)
            {
                Console.WriteLine(klientas);
            }

            Console.WriteLine("Iveskite kliento ID:");
            int klientoId;
            if (!int.TryParse(Console.ReadLine(), out klientoId))
            {
                Console.WriteLine("Neteisingai ivestas kliento ID.");
                return;
            }

            Klientas pasirinktas = null;

            foreach (Klientas klientas in klientai)
            {
                if (klientas.ID == klientoId)
                {
                    pasirinktas = klientas;
                }
            }

            if (pasirinktas == null)
            {
                Console.WriteLine("Klientas nerastas.");
                return;
            }

            Console.WriteLine("Atspausdinamas automobiliu sarasas..");
            RodytiVisusAuto();

            Console.WriteLine("Iveskite automobilio VIN: ");
            string vin = Console.ReadLine();

            Automobilis isnuomotas = null;

            foreach (Automobilis automobilis in automobiliai)
            {
                if (automobilis.VIN == vin && automobilis.PrieinamasKiekis > 0)
                {
                    isnuomotas = automobilis;
                    isnuomotas.PrieinamasKiekis--;
                    isnuomotas.KlientoID = klientoId;
                    isnuomotas.ArIsnuomotas = true;
                    Console.WriteLine("Automobilis sekmingai isnuomotas.");
                    return;
                }
            }
            Console.WriteLine("Automobilis nera prieinamas nuomai arba jau isnuomotas.");
        }

        public static void GrazintiAutomobili()
        {
            Console.WriteLine("Iveskite kliento ID: ");
            int klientoId;
            if (!int.TryParse(Console.ReadLine(), out klientoId))
            {
                Console.WriteLine("Neteisingai ivestas kliento ID");
                return;
            }

            Console.WriteLine("Iveskite automobilio VIN:");
            string vin = Console.ReadLine();
            Automobilis grazinamas = null;

            foreach (Automobilis automobilis in automobiliai)
            {
                if (automobilis.VIN == vin && automobilis.KlientoID == klientoId)
                {
                    grazinamas = automobilis;
                    grazinamas.PrieinamasKiekis++;
                    grazinamas.KlientoID = 0;
                    grazinamas.ArIsnuomotas = false;
                    Console.WriteLine("Automobilis sekmingai grazintas.");
                    return;
                }
            }
            Console.WriteLine("Automobilis nerastas.");
        }

        public static void RodytiVisusAuto()
        {
            Console.WriteLine("Visi automobiliai:");

            foreach (var automobilis in automobiliai)
            {
                Console.WriteLine(automobilis);
            }
        }

        public static void RodytiVisusNuomotus()
        {
            Console.WriteLine("Isnuomotu automobiliu sarasas: ");

            foreach (Automobilis automobilis in automobiliai)
            {
                if (automobilis.KlientoID != 0)
                {
                    Console.WriteLine($"Automobilis: {automobilis}.");
                }
            }
        }

        public static void IstrintiAuto()
        {
            Console.WriteLine("Spausdinamas automobiliu sarasas..");
            RodytiVisusAuto();
            Console.WriteLine("Iveskite automobilio VIN, kuri norite pasalinti: ");
            string vin = Console.ReadLine();

            Automobilis istrinamas = null;

            foreach (Automobilis automobilis in automobiliai)
            {
                if (automobilis.VIN == vin)
                {
                    istrinamas = automobilis;
                    break;
                }
            }

            if (istrinamas != null)
            {
                if (istrinamas.KlientoID == 0)
                {
                    automobiliai.Remove(istrinamas);
                    Console.WriteLine("Automobilis sekmingai istrintas.");
                }
                else
                {
                    Console.WriteLine("Automobilis siuo metu yra isnuomotas ir negali buti istrintas.");
                }
            }
            else
            {
                Console.WriteLine("Automobilis nerastas.");
                return;
            }
        }

        public static void IeskotiAutomobilio()
        {
            Console.WriteLine("Iveskite ieskomo automobilio VIN, marke, modelio arba metus: ");
            string ivestis = Console.ReadLine().ToLower();
            List<Automobilis> rasti = new List<Automobilis>();

            foreach (Automobilis automobilis in automobiliai)
            {
                if (automobilis.VIN.ToLower().Contains(ivestis) ||
                    automobilis.Marke.ToLower().Contains(ivestis) ||
                    automobilis.Modelis.ToLower().Contains(ivestis) ||
                    automobilis.Metai.ToString().Contains(ivestis))
                {
                    rasti.Add(automobilis);
                }
            }
            if(rasti.Count > 0 )
            {
                Console.WriteLine("Rasti automobiliai.");
                foreach(Automobilis automobilis in rasti)
                {
                    Console.WriteLine(automobilis);
                }
            }
            else
            {
                Console.WriteLine("Automobilio pagal jusu nurodytus duomenis neradome.");
            }
        }

        public static void RedaguotiAuto()
        {
            Console.Write("Iveskite automobilio VIN, kurio informacija norite pakeisti: ");
            string vin = Console.ReadLine();

            Automobilis redaguojamas = null;

            foreach (var automobilis in automobiliai)
            {
                if (automobilis.VIN == vin)
                {
                    redaguojamas = automobilis;
                    break;
                }
            }

            if (redaguojamas != null)
            {
                Console.Write("Iveskite nauja marke: ");
                redaguojamas.Marke = Console.ReadLine();

                Console.Write("Iveskite nauja modeli: ");
                redaguojamas.Modelis = Console.ReadLine();

                Console.Write("Iveskite naujus metus: ");
                if (int.TryParse(Console.ReadLine(), out int metai))
                {
                    redaguojamas.Metai = metai;
                    Console.WriteLine("Automobilio informacija pakeista sekmingai!");
                }
                else
                {
                    Console.WriteLine("Neteisingi metai.");
                }
            }
            else
            {
                Console.WriteLine("Automobilis nerastas.");
            }
        }
    }
}
