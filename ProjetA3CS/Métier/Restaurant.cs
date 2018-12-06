using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Restaurant
    {
        MaitreHotel maitrehotel;

        List<ChefDeRang> ListChefsRang; 

        List<Carre> ListCarres; // Liste de carré

        List<GroupeClient> GroupeClients = new List<GroupeClient>(); // Liste de Groupe Client

        List<GroupeClient> InstalledClient = new List<GroupeClient>();


        public Restaurant()
        {
            ChefDeRang chefRang1 = new ChefDeRang();
            ChefDeRang chefRang2 = new ChefDeRang();

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

        }

        public void TickFor(int xTemps) //Appel x time en seconde
        {

        }
        

        public void GrpClientArrive(GroupeClient groupeClient)
        {
            maitrehotel.Welcomegroup(groupeClient);
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
