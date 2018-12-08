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
        public List<GroupeClient> ClientWithMenu { get; set; } = new List<GroupeClient>();

        //ChefCuisine ChefCuisine


        public ChefDeRang(/*ChefCuisine chefcuisine*/)
        {
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

        public void CheckReadyGroupClient()
        {
            foreach(var client in ClientWithMenu)
            {
                if(client.WaitForOrder)
                {
                    TakeOrders(client);
                    break;
                }
            }
        }

        public void GiveCommmandCuisine()
        {

        }

        private void TakeOrders(GroupeClient groupeClient)
        {
            Commande commande = new Commande(); 
        }

        public void GiveMenu()
        {
            groupeSelected.HaveMenu = true;
            ClientWithMenu.Add(groupeSelected);
            groupeSelected = null; 
        }
    }
}
