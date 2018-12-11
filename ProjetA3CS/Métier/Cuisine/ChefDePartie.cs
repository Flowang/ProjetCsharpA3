using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Métier;
using Métier.Mobilier_Salle;

namespace Métier.Cuisine
{
    public class ChefDePartie
    {
        Comptoir Comptoir;

        public List<Recette> Entrees; //Bout de papier
        public List<Recette> Plats; //Assiette avec le plat pref de Emilien 
        public List<Recette> Desserts;


        public ChefDePartie(Comptoir comptoir)
        {
            this.Comptoir = comptoir;
        }
        public void CommandToPlat(Commande commande)
        {
            for(int i = 0; i <= 3; i++)
            {
               if(commande.recettes[i].typeRecette == TypeRecette.Entree)
                    {
                    Entrees.Add(commande.recettes[i]);
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
            Plat entree   = new Plat(Entrees, commande.AssociateGroupe);
            Plat plat     = new Plat(Plats, commande.AssociateGroupe);
            Plat dessert = new Plat(Desserts, commande.AssociateGroupe);

            Comptoir.AddPlat(entree);
            Comptoir.AddPlat(plat);
            Comptoir.AddPlat(dessert);


        }
    }
}
