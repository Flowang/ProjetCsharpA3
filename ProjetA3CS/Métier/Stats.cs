using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Stats
    {
        public int Serveur { get; set; }
        public int MaitreHotel { get; set; }
        public int ChefRang { get; set; }
        public int Cuisinier { get; set; }
        public int Total { get; set; }
        public int NombreClient { get; set; }

        public Stats()
        {
            Serveur = 0;
            MaitreHotel = 5;
            ChefRang = 0;
            Cuisinier = 0;
            Total = 0;
            NombreClient = 0;
        }
    }
}
