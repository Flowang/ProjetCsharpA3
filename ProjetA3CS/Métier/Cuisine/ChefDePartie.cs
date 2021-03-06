﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Métier;
using Métier.Mobilier_Salle;

namespace Métier.Cuisine
{
    public enum EtatChePartie
    {
        Free, 
        NotFree,
    }

    public  class ChefDePartie : RestaurantElement
    {
        Comptoir Comptoir;
        ChefDeCuisine chefdecuisine;
        

        public List<Recette> Entrees; // papier avec marqué les entrées à faire
        public List<Recette> Plats;  
        public List<Recette> Desserts;

        List<Plat> PlataCuisiner;

        public EtatChePartie Etat { get; set; }
      
        public ChefDePartie(Comptoir comptoir)
        {
            PlataCuisiner = new List<Plat>();

            Entrees = new List<Recette>();
            Plats = new List<Recette>();
            Desserts = new List<Recette>();

            this.Comptoir = comptoir;
        }
        public void GetCommand(Commande commande)
        {
            
            for(int i = 0; i <= 3; i++)
            {
               if(commande.recettes[i].typeRecette == TypeRecette.Entree)
                {
                    Entrees.Add(commande.recettes[i]);// On traite la nouvelle commande en séparant en trois les recettes liées à cette commande
                    Plat entree = new Plat(Entrees, commande.AssociateGroupe, new Compteur() { Time = commande.recettes[i].TempsPreparation });
                    PlataCuisiner.Add(entree);
                }
               if (commande.recettes[i].typeRecette == TypeRecette.Plat)
                    {
                    Plat plat = new Plat(Plats, commande.AssociateGroupe, new Compteur() { Time = commande.recettes[i].TempsPreparation });
                    Plats.Add(commande.recettes[i]);
                    PlataCuisiner.Add(plat);
                }
                if (commande.recettes[i].typeRecette == TypeRecette.Dessert)
                    {
                    Plat dessert = new Plat(Desserts, commande.AssociateGroupe, new Compteur() { Time = commande.recettes[i].TempsPreparation });
                    Desserts.Add(commande.recettes[i]);
                    PlataCuisiner.Add(dessert);
                }
            }
            // On prépare les entrées notées sur le papier
             

             // on envoit les entrées préparés au comptoir
        }

        public override void Tick()
        {
            if(PlataCuisiner.Count == 0)
            {
                Etat = EtatChePartie.Free;
                return;
            }
            foreach(var plat in PlataCuisiner)
            {
                if (plat.compteur.IsOver)
                {
                    Comptoir.AddPlat(plat);
                }
                plat.compteur.Tick();
                Etat = EtatChePartie.NotFree;
                return;
                
            }
        }
    }
}
