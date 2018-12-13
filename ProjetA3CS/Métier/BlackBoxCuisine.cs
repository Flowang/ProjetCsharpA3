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
                restaurant.Comptoir.TakePlat();
            }
        }
    }
}
