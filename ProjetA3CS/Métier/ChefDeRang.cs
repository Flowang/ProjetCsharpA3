using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class ChefDeRang : Personnel
    {
        public Carre CarreAttribue { get; set; }
        GroupeClient groupeSelected;
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
        }

        public bool IsTablesFree(GroupeClient groupeClient)
        {
            foreach(var rang in CarreAttribue.Rangs)
            {
                foreach(var table in rang.tables)
                {
                    if(table.IsFree && table.NbrPlace >= groupeClient.clients.Count)
                    {
                        TableSelect = table; 
                        return true; 
                    }
                }
            }
            return false; 
        }
    }
}
