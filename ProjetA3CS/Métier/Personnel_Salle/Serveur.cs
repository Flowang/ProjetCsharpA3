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
                if(comptoir.Plats.Count > 0)
                {
                    if (comptoir.GetGroupeFirstPlat().Etat != EtatGroupeClient.WaitFordishOut)
                    {
                        NewTask(EtatServeur.TakingPlat);
                        ToDo = GetPlat;
                        return;
                    }
                }
                foreach(var gpc in groupeClients)
                {
                    if(gpc.Etat == EtatGroupeClient.WaitFordishOut)
                    {
                        GpcToDishOut = gpc;
                        NewTask(EtatServeur.DishOut);
                        ToDo = Dishout;
                        return;
                    }
                }
            }


            compteur.Tick();
            if(compteur.IsOver)
            {
                ToDo.Invoke();
                Etat = EtatServeur.Free;
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
            NewTask(EtatServeur.GivingPlat);
            ToDo = GivePlat;
            PlatEnMain = plat;
        }

        public void GivePlat()
        {
            if(GpcToServe.Etat != EtatGroupeClient.WaitForMeal)
            {
                return; 
            }
            GpcToServe.Etat = EtatGroupeClient.Eating;
            GpcToServe = PlatEnMain.GroupeClient;
        }

        private void NewTask(EtatServeur task)
        {
            Etat = task;
            compteur = new Compteur() { Time = Convert.ToInt32(task) };
            Debug.WriteLine("Le chef de rang fait " + Etat.ToString());
        }

        public void Dishout()
        {
            if(GpcToDishOut.Etat != EtatGroupeClient.WaitFordishOut)
            {
                return;
            }
            GpcToDishOut.Etat = EtatGroupeClient.WaitForMeal;
            if(Convert.ToInt32(GpcToDishOut.CurrentPlat) == 3)
            {
                GpcToDishOut.Etat = EtatGroupeClient.Leaving;
            }
            GpcToDishOut.CurrentPlat++;
        }
    }
}
