using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SestaPaskaita
{
    
    public class Filmas
{
        public int EilNr;
        public string Pavadinimas;
        public double Reitingas;

        public static List<Filmas> sarasas = new List<Filmas>();

        public Filmas(int aEilNr,string aPavadinimas, double aReitingas)
        {
            EilNr = aEilNr;
            Pavadinimas = aPavadinimas;
            Reitingas = aReitingas;
        }

        public Filmas()
        {

        }

        public override string ToString()
        {
            return $"Eiles Nr. {EilNr} Pavadinimas: {Pavadinimas} Reitingas: {Reitingas}";
        }
    }
}
