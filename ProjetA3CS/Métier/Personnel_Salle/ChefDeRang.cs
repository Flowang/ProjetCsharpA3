using Métier.Mobilier_Salle;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public enum EtatChefRang
    {
        Free = 0, 
        LeadingGroupe = 1,
        TakingOrder = 3,
    }
    public class ChefDeRang : RestaurantElement
    {
        private Compteur compteur;
        private Menu menu; 
        public Carre CarreAttribue { get; set; }
        GroupeClient groupeSelected;
        public List<GroupeClient> ResponsableClients { get; set; } = new List<GroupeClient>();
        Restaurant restaurant;

        public EtatChefRang Etat { get; set; }

        //ChefCuisine ChefCuisine


        public ChefDeRang(Menu Menu, Restaurant resto/*ChefCuisine chefcuisine*/)
        {
            Etat = EtatChefRang.Free;
            restaurant = resto; 
            menu = Menu;
            /*ChefCuisine = chefCuisine;*/
        }

        Table TableSelect;
        public override void Tick()
        {
            if(Etat != EtatChefRang.Free)
            {
                compteur.Tick();
                if(compteur.IsOver)
                {
                    Etat = EtatChefRang.Free;
                    Debug.WriteLine("Le chef de rang est libre !");
                    return; 
                }
                return;
            }

            if (CheckReadyGroupClient())
            {
                return;
            }
        }

        public void AssignTable(GroupeClient groupeClient)
        {
            TableSelect.grpClient = groupeClient;
            groupeClient.TableSelected = TableSelect;
            groupeClient.WaitAssignment = false;
            groupeSelected = groupeClient;
            GiveMenu();
            NewTask(EtatChefRang.LeadingGroupe);
        }

        public bool IsTablesFree(GroupeClient groupeClient)
        {
            bool outpute = false;
            foreach (var rang in CarreAttribue.Rangs)
            {
                foreach (var table in rang.tables)
                {
                    if (table.IsFree && table.NbrPlace >= groupeClient.clients.Count)
                    {
                        if (TableSelect == null)
                        {
                            TableSelect = table;
                        }
                        if (table.NbrPlace < TableSelect.NbrPlace)
                            TableSelect = table;
                        outpute = true;
                    }
                }
            }
            return outpute;
        }

        public bool CheckReadyGroupClient()
        {
            foreach(var client in ResponsableClients)
            {
                if (client.Etat == EtatGroupeClient.WaitForOrder)
                {
                    NewTask(EtatChefRang.TakingOrder);
                    TakeOrders(client);
                    return true;
                }
            }
            return false;
        }

        public void GiveCommmandCuisine(Commande commande)
        {
            restaurant.Comptoir.AddCommande(commande);
        }

        private void TakeOrders(GroupeClient groupeClient)
        {
            Commande commande = new Commande(); 
            foreach(var client in groupeClient.clients)
            {
                for(int i = 0; i < client.Orders.Length; i ++)
                {
                    commande.recettes.Add(client.Orders[i]); 
                }
            }
            commande.AssociateGroupe = groupeClient;
            GiveCommmandCuisine(commande);
            groupeClient.Etat = EtatGroupeClient.WaitForMeal;
        }

        public void GiveMenu()
        {
            groupeSelected.HaveMenu = true;
            ResponsableClients.Add(groupeSelected);
            groupeSelected = null; 
        }

        private void NewTask(EtatChefRang task)
        {
            Etat = task;
            compteur = new Compteur() { Time = Convert.ToInt32(task) };
            Debug.WriteLine("Le chef de rang fait " + Etat.ToString());
        }

    }
}
