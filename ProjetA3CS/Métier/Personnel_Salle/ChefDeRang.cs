using Métier.Mobilier_Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class ChefDeRang : RestaurantElement
    {
        public Carre CarreAttribue { get; set; }
        GroupeClient groupeSelected;
        public List<GroupeClient> ResponsableClients { get; set; } = new List<GroupeClient>();
        Restaurant restaurant;

        //ChefCuisine ChefCuisine


        public ChefDeRang(Restaurant resto/*ChefCuisine chefcuisine*/)
        {
            restaurant = resto; 
            /*ChefCuisine = chefCuisine;*/
        }

        Table TableSelect;
        public bool IsFree
        {
            get
            {
                return (groupeSelected == null);
            }
        }
        public override void Tick()
        {
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


    }
}
