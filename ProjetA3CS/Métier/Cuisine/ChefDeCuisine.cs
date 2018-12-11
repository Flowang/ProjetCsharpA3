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

        public override void Tick()
        {
            Comptoir c = new Comptoir();
            var CommandeActuelle = c.TakeCommande();
            
        }
    }
}
