using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Plat
    {
        public Compteur compteur { get; set; }
        public Recette recette { get; set; }
        public Plat(Recette re, Compteur time)
        {
            compteur = time; 
            recette = re; 
        }
    }
}
