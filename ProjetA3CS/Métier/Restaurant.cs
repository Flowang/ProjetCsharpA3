﻿using Métier.Cuisine;
using Métier.Mobilier_Salle;
using Métier.Personnel_Salle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            

            ChefDeparti = new ChefDePartie(Comptoir);
            chefDeCuisine = new ChefDeCuisine(Comptoir, ChefDeparti);
            //blackbox = new BlackBoxCuisine(this);
            serveur = new Serveur(Comptoir, InstalledClient);
        }

        public void Tick()
        {
            Debug.WriteLine("Tick...");
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
            //serveur.Tick();
        }

        public void TickFor(int xTemps) //Appel x time en seconde
        {
            for(int i = 0; i < xTemps; i++)
            {
                Tick();
                Console.ReadLine();
            }
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
