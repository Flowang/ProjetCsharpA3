using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class BlackBoxCuisine : RestaurantElement
    {
        Restaurant restaurant;
        Compteur compteur;

        public BlackBoxCuisine(Restaurant resto)
        {
            restaurant = resto;
        }

        public override void Tick()
        {
            if(restaurant.Comptoir.CommandeCount > 0)
            {
                Commande commande = restaurant.Comptoir.TakeCommande();

                Plat Entree = new Plat (commande.recettes.Where(recette => recette.typeRecette == TypeRecette.Entree).ToList(), commande.AssociateGroupe, new Compteur());
                Plat Plat = new Plat(commande.recettes.Where(recette => recette.typeRecette == TypeRecette.Plat).ToList(), commande.AssociateGroupe, new Compteur());
                Plat Dessert = new Plat(commande.recettes.Where(recette => recette.typeRecette == TypeRecette.Dessert).ToList(), commande.AssociateGroupe, new Compteur());

                restaurant.Comptoir.AddPlat(Entree);
                restaurant.Comptoir.AddPlat(Plat);
                restaurant.Comptoir.AddPlat(Dessert);

            }
        }
    }
}
