using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Recette
    {
        public string Nom { get; set; }
        public TypeRecette typeRecette { get; set; }

        public int TempsPreparation { get; set; }

        public Recette()
        {
                
        }
        public Recette(string nom, int tempspreparation)
        {
            this.Nom = nom;
            this.TempsPreparation = tempspreparation;
        }
            
    }
}
