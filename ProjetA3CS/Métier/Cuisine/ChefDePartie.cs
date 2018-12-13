using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Métier;
using Métier.Mobilier_Salle;

namespace Métier.Cuisine
{
    public class ChefDePartie : RestaurantElement
    {
        Comptoir Comptoir;
        ChefDeCuisine chefdecuisine;

        public List<Recette> Entrees; // papier avec marqué les entrées à faire
        public List<Recette> Plats;  
        public List<Recette> Desserts;


        public ChefDePartie(Comptoir comptoir)
        {
            this.Comptoir = comptoir;
        }
        public void GetCommand(Commande commande)
        {
            
            for(int i = 0; i <= 3; i++)
            {
               if(commande.recettes[i].typeRecette == TypeRecette.Entree)
                    {
                    Entrees.Add(commande.recettes[i]);// On traite la nouvelle commande en séparant en trois les recettes liées à cette commande                
                    }
               if (commande.recettes[i].typeRecette == TypeRecette.Plat)
                    {
                    Plats.Add(commande.recettes[i]);
                }
               if (commande.recettes[i].typeRecette == TypeRecette.Dessert)
                    {
                     Desserts.Add(commande.recettes[i]);
                    }
            }
            // On prépare les entrées notées sur le papier
             Plat entree = new Plat(Entrees, commande.AssociateGroupe, commande.recettes[i].TempsPreparation);
             Plat plat = new Plat(Plats, commande.AssociateGroupe);
             Plat dessert = new Plat(Desserts, commande.AssociateGroupe);

            Comptoir.AddPlat(entree); // on envoit les entrées préparés au comptoir
            Comptoir.AddPlat(plat);
            Comptoir.AddPlat(dessert);
        }

        public override void Tick()
        {

        }
    }
}
