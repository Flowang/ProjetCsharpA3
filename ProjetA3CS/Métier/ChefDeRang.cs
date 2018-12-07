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
        List<GroupeClient> ClientWithMenu = new List<GroupeClient>();
        /// <summary>
        /// 
        /// xxxxxxx
        /// </summary>
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

        public void GiveMenu()
        {
            groupeSelected.HaveMenu = true;
            ClientWithMenu.Add(groupeSelected);
            
        }
    }
}
