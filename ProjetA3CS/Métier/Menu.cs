using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    static public class Menu
    {
        static public List<Recette> Entrees { get; set; } = new List<Recette>()
        {
                new Recette("Salade niçoise") {typeRecette = TypeRecette.Entree },
                new Recette("Salade de pâtes") {typeRecette = TypeRecette.Entree },
                new Recette("Salade César") {typeRecette = TypeRecette.Entree },
                new Recette("Salade de riz") {typeRecette = TypeRecette.Entree },
                new Recette("Feuilletés au jambon") {typeRecette = TypeRecette.Entree },
                new Recette("Soupe au potiron") {typeRecette = TypeRecette.Entree },
                new Recette("Soupe à l'oignon") {typeRecette = TypeRecette.Entree },
                new Recette("Soupe à la tomate") {typeRecette = TypeRecette.Entree },
                new Recette("Tarte à la tomate") {typeRecette = TypeRecette.Entree },
                new Recette("Tartines gratinées") {typeRecette = TypeRecette.Entree },
                new Recette("Tarte au thon") {typeRecette = TypeRecette.Entree },
                new Recette("Quiche aux poireaux") {typeRecette = TypeRecette.Entree }
        };

        static public List<Recette> Plat { get; set; } = new List<Recette>()
        {
                new Recette("Lasagne de boeuf") {typeRecette = TypeRecette.Plat },
                new Recette("Lasagne savoyarde") {typeRecette = TypeRecette.Plat },
                new Recette("Bavette de boeuf") {typeRecette = TypeRecette.Plat },
                new Recette("Tagliatelles sauce au noix") {typeRecette = TypeRecette.Plat },
                new Recette("Parmentier de cabillaud") {typeRecette = TypeRecette.Plat },
                new Recette("Filet mignon pané") {typeRecette = TypeRecette.Plat },
                new Recette("Fricassée de poulet flambée") {typeRecette = TypeRecette.Plat },
                new Recette("Magret de canard aux pêches") {typeRecette = TypeRecette.Plat },
                new Recette("Filet de maquereau") {typeRecette = TypeRecette.Plat },
                new Recette("Côte de porc au cumin") {typeRecette = TypeRecette.Plat },
                new Recette("Crépinettes de poulet au bacon") {typeRecette = TypeRecette.Plat },
                new Recette("Tagliatelles aux poireaux et foie gras") {typeRecette = TypeRecette.Plat }
        };

        static public List<Recette> Desserts { get; set; } = new List<Recette>()
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


