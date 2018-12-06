using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Table
    {
        public int NbrPlace;
        public GroupeClient grpClient;
        public bool IsFree
        {
            get
            {
                return (grpClient == null);
            }
        }

        public Table(int nbrPlace)
        {
            NbrPlace = nbrPlace;
        }
    }
}
