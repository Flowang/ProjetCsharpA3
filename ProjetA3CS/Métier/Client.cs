using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Client : Personnel
    {

        public GroupeClient NomGroupe { get; private set; }
        

        public override void Tick()
        {

        }

        public Client(GroupeClient nomGroupe)
        {
            this.NomGroupe = nomGroupe;
        }
    }
}
