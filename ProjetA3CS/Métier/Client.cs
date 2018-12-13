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
            Orders[0] = new Recette() { Nom = Menu.Entrees[rnd.Next(1,11)].Nom, typeRecette = TypeRecette.Entree };
            Orders[1] = new Recette() { Nom = Menu.Plat[rnd.Next(1, 11)].Nom , typeRecette = TypeRecette.Plat };
            Orders[2] = new Recette() { Nom = Menu.Desserts[rnd.Next(1, 11)].Nom, typeRecette = TypeRecette.Dessert };

        }

        public Recette[] Order()
        {
            return Orders; 
        }

    }
}
