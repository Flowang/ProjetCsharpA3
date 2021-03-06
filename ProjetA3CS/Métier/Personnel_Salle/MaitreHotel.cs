﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    class MaitreHotel : RestaurantElement
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

        public void Welcomegroup(GroupeClient groupeClient, List<GroupeClient> WaitingLine)
        {
            bool PlaceFinded = false;
            foreach (var carre in ListCarres)
            {
                if (carre.ChefRang.Etat == EtatChefRang.Free && !PlaceFinded)
                {
                    if (carre.ChefRang.IsTablesFree(groupeClient))
                    {
                        carre.ChefRang.AssignTable(groupeClient);
                        PlaceFinded = true;
                        Console.WriteLine("Une place a été trouvée pour les clients qui viennent d'arriver");
                    }
                }
            }
            if (!PlaceFinded)
                WaitingLine.Add(groupeClient);
        }
    }
}
