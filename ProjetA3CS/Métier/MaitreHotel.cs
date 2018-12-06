using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    class MaitreHotel : Personnel
    {
        Restaurant RestaurantAssos;
        List<Carre> ListCarres;
        public List<GroupeClient> FileAttente { get; set; }
        


        public MaitreHotel(Restaurant resto, List<Carre> Carres)
        {
            ListCarres = Carres;
            RestaurantAssos = resto;
        }

        public override void Tick()
        {
        }

        public void Welcomegroup(GroupeClient groupeClient, List<GroupeClient> Attente, List<GroupeClient> Installed)
        {
            foreach(var carre in ListCarres)
            {
                if(carre.ChefRang.IsFree)
                {
                    if(carre.ChefRang.IsTablesFree(groupeClient))
                    {
                        carre.ChefRang.AssignTable(groupeClient);
                        Attente.Add
                    }
                }
            }
        }
    }
}
