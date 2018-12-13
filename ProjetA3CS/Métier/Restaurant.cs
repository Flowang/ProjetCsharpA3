using Métier.Cuisine;
using Métier.Mobilier_Salle;
using Métier.Personnel_Salle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        public BlackBoxCuisine blackbox { get; set; }

        public Serveur serveur { get; set; }

        public List<GroupeClient> InstalledClient { get; set; } = new List<GroupeClient>();

        public ChefDePartie ChefDeparti { get; set; }

        public ChefDeCuisine chefDeCuisine { get; set; }

        public Stats Stat { get; set; }

        public Restaurant()
        {
            Comptoir = new Comptoir();
            ChefDeRang chefRang1 = new ChefDeRang(this);
            ChefDeRang chefRang2 = new ChefDeRang(this);

            Carre carre1 = new Carre(chefRang1);
            chefRang1.CarreAttribue = carre1;

            Carre carre2 = new Carre(chefRang2);
            chefRang2.CarreAttribue = carre2;

            ListChefsRang = new List<ChefDeRang>() { chefRang1, chefRang2 };
            ListCarres = new List<Carre>() { carre1, carre2 };

            maitrehotel = new MaitreHotel(this, ListCarres);

            Stat = new Stats();

            ChefDeparti = new ChefDePartie(Comptoir);
            chefDeCuisine = new ChefDeCuisine(Comptoir, ChefDeparti);
            blackbox = new BlackBoxCuisine(this);
            serveur = new Serveur(Comptoir, InstalledClient);
        }

        public void Tick()
        {
            if(new Random().Next(1,5) == 4)
            {
                GrpClientArrive();
                Stat.NombreClient++;
            }
            maitrehotel.Tick();

            foreach (var chefrang in ListChefsRang)
            {
                chefrang.Tick();
                foreach (var group in chefrang.ResponsableClients)
                {
                    group.Tick();
                }
            }
            chefDeCuisine.Tick();

            ChefDeparti.Tick();

            //blackbox.Tick();
            serveur.Tick();
            Stat.Total++;
            TakeStat(); 
        }

        private void TakeStat()
        {
            if(serveur.Etat != EtatServeur.Free)
            {
                Stat.Serveur++;
            }
            foreach(var chef in ListChefsRang)
            {
                if(chef.Etat != EtatChefRang.Free)
                {
                    Stat.ChefRang++;
                }
            }
            if(ChefDeparti.Etat != EtatChePartie.Free)
            {
                Stat.Cuisinier++;
            }

        }

        public void TickFor(int xTemps) //Appel x time en seconde
        {
            for(int i = 0; i < xTemps; i++)
            {
                Tick();
               
            }
            CommitStat(Stat);
        }


        public void GrpClientArrive()
        {
            GroupeClient groupeClient = new GroupeClient(count++);
            Console.WriteLine("Un groupe de client est arrivé");
            maitrehotel.Welcomegroup(groupeClient, WaitingLine);
            InstalledClient.Add(groupeClient);
        }

        public void GetCommande(Commande commande)
        {
            Comptoir.AddCommande(commande);
        }

        private void CommitStat(Stats stat)
        {
            StreamWriter sw = new StreamWriter("Stat.log", false);
            sw.WriteLine("serveur:" + stat.Serveur);
            sw.WriteLine("cuisier:" + stat.Cuisinier);
            sw.WriteLine("ChefRang:" + stat.ChefRang);
            sw.WriteLine("MaitreHotel:" + stat.NombreClient);
            sw.WriteLine("Nombre Client Total:" + stat.NombreClient);

            sw.WriteLine("Total:" + stat.Total);
            sw.Close();

        }
    }
}
