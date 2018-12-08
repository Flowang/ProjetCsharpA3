using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Commande
    {
        public List<Recette> recettes { get; set; }

        public Commande(Recette[] commande)
        {
            recettes = new List<Recette>(commande); 
        }
    }
}
