using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Menu
    {
        public List<Recette> Entree { get; set; }

        public List<Recette> Plat { get; set; }

        public List<Recette> Dessert { get; set; }

        public Menu()
        {
            // Remplir les trois listes ici 
            //Pourquoi pas le faire depuis la base de données pour pouvoir modifier le menu si besoin
        }
    }
}
