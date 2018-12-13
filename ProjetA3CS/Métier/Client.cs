using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Métier
{
    public class Client : RestaurantElement
    {
        public int id;

        public GroupeClient AssociateGroupe { get; private set; }
        public Recette[] Orders { get; set; } = new Recette[3];


        public override void Tick()
        {

        }

        public Client(GroupeClient nomGroupe)
        {
            this.AssociateGroupe = nomGroupe;
        }

        public void ChooseRecettes()
        {
            //Orders[0] = new Recette() { Nom = "Melon", typeRecette = TypeRecette.Entree };
            //Orders[1] = new Recette() { Nom = "Marguerita", typeRecette = TypeRecette.Plat };
            //Orders[2] = new Recette() { Nom = "Boule_Vanille", typeRecette = TypeRecette.Dessert };

            Random rnd = new Random();
            Recette entre = Menu.Entrees[rnd.Next(1, 11)];
            Recette plat = Menu.Entrees[rnd.Next(1, 11)];
            Recette dessert = Menu.Entrees[rnd.Next(1, 11)];

            Orders[0] = entre;
            Orders[1] = plat;
            Orders[2] = dessert;

        }

        public Recette[] Order()
        {
            return Orders; 
        }

    }
}
