using Métier.Mobilier_Salle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier.Cuisine
{
    public class ChefDeCuisine : RestaurantElement
    {
        ChefDePartie chefparti;
        Comptoir comptoir;
        public ChefDeCuisine(Comptoir Comptoir, ChefDePartie chef )
        {
            chefparti = chef;
            this.comptoir = Comptoir;
        }
        
        public void TransferCommand()
        {
            var CommandeActuelle = comptoir.TakeCommande();
            if (CommandeActuelle == null)
                return;
            chefparti.GetCommand(CommandeActuelle);
        }
        public override void Tick()
        {
             
             TransferCommand();
        }

        
    }
}
