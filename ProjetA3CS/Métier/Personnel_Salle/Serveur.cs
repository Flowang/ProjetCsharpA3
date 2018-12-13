using Métier.Mobilier_Salle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier.Personnel_Salle
{
    public enum EtatServeur : int
    {
        Free,
        TakingPlat = 1,
        GivingPlat = 2, 
        DishOut = 3,
    }
    public class Serveur : RestaurantElement
    {
        delegate void Task();
        Task ToDo; 
        public EtatServeur Etat { get; set; } 
        List<GroupeClient> groupeClients;
        GroupeClient GpcToDishOut;
        GroupeClient GpcToServe;
        Comptoir comptoir;
        Compteur compteur;
        Plat PlatEnMain;

        public Serveur(Comptoir Comptoir, List<GroupeClient> Clients)
        {
            Etat = EtatServeur.Free;
            groupeClients = Clients;
            comptoir = Comptoir; 
        }

        public override void Tick()
        {
            base.Tick();
            if(Etat == EtatServeur.Free)
            {
                foreach (var gpc in groupeClients)
                {
                    if(gpc.Etat == EtatGroupeClient.WaitFordishOut)
                    {
                        GpcToDishOut = gpc;
                        NewTask(EtatServeur.DishOut);
                        ToDo = Dishout;
                        return;
                    }
                }

                if (PlatEnMain != null && GpcToServe != null)
                {
                    NewTask(EtatServeur.GivingPlat);
                    ToDo = GivePlat;
                    return;
                }
                if (comptoir.Plats.Count > 0 && PlatEnMain == null)
                {
                    foreach(var plat in comptoir.Plats)
                    {
                        if(plat.GroupeClient.Etat == EtatGroupeClient.Eating)
                        {
                            continue;
                        }
                        if (plat.GroupeClient.Etat != EtatGroupeClient.WaitFordishOut)
                        {
                            NewTask(EtatServeur.TakingPlat);
                            ToDo = GetPlat;
                            return;
                        }
                    }
                }
            }

            if (compteur != null)
            {
                compteur.Tick();
                if (compteur.IsOver)
                {
                    ToDo?.Invoke();
                    Etat = EtatServeur.Free;
                }
            }

        }

        public void GetPlat()
        {
            Plat plat = comptoir.TakePlat();
            if(plat == null)
            {
                return; 
            }
            GroupeClient groupeclient = plat.GroupeClient;
            GpcToServe = groupeclient;
            PlatEnMain = plat;
            ToDo = null;
            Console.WriteLine("Le serveur va chercher des plats au contoir");
        }

        public void GivePlat()
        {
            Console.WriteLine("Le serveur sert des plats a des clients"); 
             if(GpcToServe.Etat != EtatGroupeClient.WaitForMeal)
            {
                return; 
            }
            GpcToServe.Etat = EtatGroupeClient.Eating;
            GpcToServe = PlatEnMain.GroupeClient;
            GpcToServe.compteur = new Compteur() { Time = 5 };
            PlatEnMain = null;
            GpcToServe = null;
            ToDo = null;
        }

        private void NewTask(EtatServeur task)
        {
            Etat = task;
            compteur = new Compteur() { Time = Convert.ToInt32(task) };
            //Console.WriteLine("Le chef de rang fait " + Etat.ToString());
        }

        public void Dishout()
        {
            Console.WriteLine("Le serveur dish out");
            if(GpcToDishOut.Etat != EtatGroupeClient.WaitFordishOut)
            {
                return;
            }
            GpcToDishOut.Etat = EtatGroupeClient.WaitForMeal;
            if(GpcToDishOut.CurrentPlat == TypeRecette.Dessert)
            {
                Console.WriteLine("Dit au revoir au client");
                GpcToDishOut.Etat = EtatGroupeClient.Leaving;
                GpcToDishOut.TableSelected = null;
            }
            GpcToDishOut.CurrentPlat++;
            GpcToDishOut = null;
            ToDo = null;
        }
    }
}
