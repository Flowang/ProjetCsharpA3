using Métier.Mobilier_Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Restaurant
    {
        public int count { get; set; }
        MaitreHotel maitrehotel;

        public Comptoir Comptoir { get; set; }

        public List<ChefDeRang> ListChefsRang { get; set; }

        public List<Carre> ListCarres; // Liste de carré

        public List<GroupeClient> WaitingLine { get; set; } = new List<GroupeClient>();

       // public  List<GroupeClient> InstalledClient { get; set; } = new List<GroupeClient>();


        public Restaurant()
        {
            Comptoir = new Comptoir(); 
            ChefDeRang chefRang1 = new ChefDeRang(new Menu(), this);
            ChefDeRang chefRang2 = new ChefDeRang(new Menu(), this);

            Carre carre1 = new Carre(chefRang1);
            chefRang1.CarreAttribue = carre1;

            Carre carre2 = new Carre(chefRang2);
            chefRang2.CarreAttribue = carre2;

            ListChefsRang = new List<ChefDeRang>() { chefRang1, chefRang2 };
            ListCarres = new List<Carre>() { carre1, carre2 };

            maitrehotel = new MaitreHotel(this, ListCarres);
        }

        public void Tick()
        {
            maitrehotel.Tick();

            foreach (var chefrang in ListChefsRang)
            {
                chefrang.Tick();
                foreach (var group in chefrang.ResponsableClients)
                {
                    group.Tick();
                }
            }
        }

        public void TickFor(int xTemps) //Appel x time en seconde
        {
            for(int i = 0; i < xTemps; i++)
            {
                Tick();
            }
        }


        public void GrpClientArrive()
        {
            GroupeClient groupeClient = new GroupeClient(count++);
            maitrehotel.Welcomegroup(groupeClient, WaitingLine);
        }

        public void GetCommande(Commande commande)
        {
            Comptoir.AddCommande(commande);
        }

        // Table avec nbr de place et Une liste de Client


        //ToutOk
        //groupeClientArrive
        //AssertAreEquals gctable !=null   



        //Plus de place carré 1
        //Chef de rang plus dispo
        //Resto Complet
        //

    }
}
