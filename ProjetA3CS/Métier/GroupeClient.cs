using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class GroupeClient
    {
        public List<Client> clients { get; set; }
        public Table TableSelected { get; set; }

        public GroupeClient()
        {
            clients = new List<Client>() { new Client(this) };
        }
    }
}
