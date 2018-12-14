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
                new Recette("Salade niçoise", 5) {typeRecette = TypeRecette.Entree },
                new Recette("Salade de pâtes", 6) {typeRecette = TypeRecette.Entree },
                new Recette("Salade César", 5) {typeRecette = TypeRecette.Entree },
                new Recette("Salade de riz", 8) {typeRecette = TypeRecette.Entree },
                new Recette("Feuilletés au jambon", 5) {typeRecette = TypeRecette.Entree },
                new Recette("Soupe au potiron", 6) {typeRecette = TypeRecette.Entree },
                new Recette("Soupe à l'oignon", 7) {typeRecette = TypeRecette.Entree },
                new Recette("Soupe à la tomate", 6) {typeRecette = TypeRecette.Entree },
                new Recette("Tarte à la tomate", 4) {typeRecette = TypeRecette.Entree },
                new Recette("Tartines gratinées", 6) {typeRecette = TypeRecette.Entree },
                new Recette("Tarte au thon", 4) {typeRecette = TypeRecette.Entree },
                new Recette("Quiche aux poireaux", 5) {typeRecette = TypeRecette.Entree }
        };

        static public List<Recette> Plat { get; set; } = new List<Recette>()
        {
                new Recette("Lasagne de boeuf", 12) {typeRecette = TypeRecette.Plat },
                new Recette("Lasagne savoyarde", 9) {typeRecette = TypeRecette.Plat },
                new Recette("Bavette de boeuf", 8) {typeRecette = TypeRecette.Plat },
                new Recette("Tagliatelles sauce au noix", 8) {typeRecette = TypeRecette.Plat },
                new Recette("Parmentier de cabillaud", 10) {typeRecette = TypeRecette.Plat },
                new Recette("Filet mignon pané", 11) {typeRecette = TypeRecette.Plat },
                new Recette("Fricassée de poulet flambée", 7) {typeRecette = TypeRecette.Plat },
                new Recette("Magret de canard aux pêches", 12) {typeRecette = TypeRecette.Plat },
                new Recette("Filet de maquereau", 10) {typeRecette = TypeRecette.Plat },
                new Recette("Côte de porc au cumin", 10) {typeRecette = TypeRecette.Plat },
                new Recette("Crépinettes de poulet au bacon", 10) {typeRecette = TypeRecette.Plat },
                new Recette("Tagliatelles aux poireaux et foie gras", 10) {typeRecette = TypeRecette.Plat }
        };

        static public List<Recette> Desserts { get; set; } = new List<Recette>()
        {
                new Recette("Boule de glace au chocolat", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la vanille", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la pistache", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au caramel", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la fraise", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la framboise", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au nougat",5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la pêche", 5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace a la banane",5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace aux oreos",5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au kitkat",5) {typeRecette = TypeRecette.Dessert },
                new Recette("Boule de glace au bounty",5) {typeRecette = TypeRecette.Dessert }
        };
    }
}


