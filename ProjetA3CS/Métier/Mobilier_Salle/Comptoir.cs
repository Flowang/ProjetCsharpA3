using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier.Mobilier_Salle
{
    public class Comptoir
    {
        private List<Commande> Commandes; //Bout de papier
        private List<Recette> Plats; //Assiette avec le plat pref de Emilien 

        public int CommandeCount { get { return Commandes.Count; } } 

        public Comptoir()
        {
            Plats = new List<Recette>();
            Commandes = new List<Commande>(); 
        }

        public void AddPlat(Recette plat)
        {
            Plats.Add(plat); 
        }
        public void AddCommande(Commande commande)
        {
            Commandes.Add(commande);
        }

        public Commande TakeCommande()
        {
            Commande commande = Commandes[0];
            Commandes.RemoveAt(0);
            return commande; 
        }

        public Recette TakePlat()
        {
            Recette plat = Plats[0];
            Plats.RemoveAt(0);
            return plat;
        }
    }
}
