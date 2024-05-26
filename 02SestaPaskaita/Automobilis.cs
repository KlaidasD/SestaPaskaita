using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SestaPaskaita
{
    public class Automobilis
    {

        public string VIN;
        public string Marke;
        public string Modelis;
        public int Metai;
        public bool ArIsnuomotas;
        public int KlientoID;
        public int PrieinamasKiekis;
        public int BendrasKiekis;
        

        public Automobilis(string aVIN, string aMarke, string aModelis, int aMetai, bool aArIsnuomotas) 
        {
            VIN = aVIN;
            Marke = aMarke;
            Modelis = aModelis;
            Metai = aMetai;
            ArIsnuomotas = aArIsnuomotas;
            KlientoID = 0;
            PrieinamasKiekis = 0;
            BendrasKiekis = 0;
        }

        public Automobilis()
        {

        }

        public override string ToString()
        {
            return $"VIN: {VIN} Marke: {Marke} Modelis: {Modelis} Metai: {Metai}" +
                $"\nBendras kiekis : {BendrasKiekis} Prieinamas kiekis: {PrieinamasKiekis}" +
                $"\n Isnuomotas: {ArIsnuomotas} Kliento Id (jeigu isnuomotas): {KlientoID}";
        }
    }
}
