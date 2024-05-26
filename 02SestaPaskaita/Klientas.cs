using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SestaPaskaita
{
    public class Klientas
    {
        public int ID;
        public string Vardas;

        public Klientas(int aID, string aVardas)
        {
            ID = aID;
            Vardas = aVardas;
        }

        public Klientas()
        {

        }

        public override string ToString()
        {
            return $"Kliento ID: {ID} Kliento Vardas: {Vardas}";

        }
    }

   
}
