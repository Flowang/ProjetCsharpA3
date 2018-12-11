using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    static public class Menu
    {
        static public List<Recette> Entrees { get; set; }

        static public List<Recette> Plat { get; set; }

        static public List<Recette> Desserts { get; set; }

        public Menu()
        {
            Entrees = new List<Recette>();
            {

            }
            Desserts = new List<Recette>()
            {
                new Recette("Boule de glace au chocolat") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la vanille") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la pistache") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au caramel") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la fraise") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la framboise") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au nougat") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la pêche") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la banane") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace aux oreos") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au kitkat") {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au bounty") {typeRecette = TypeRecette.Dessert }
            };
        }
    }
}


