using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    
    public class Carre 
    {
        public List<Rang> Rangs;

        public ChefDeRang ChefRang { get; set; }

        public Carre(ChefDeRang chefRang)
        {
            ChefRang = chefRang;
            Rang rang1 = new Rang()
            {
                tables = new List<Table>()
                {
                    new Table(10),
                    new Table(6),
                    new Table(6),
                    new Table(8),
                    new Table(4),
                    new Table(4),
                    new Table(2),
                    new Table(2),
                }
            };
            Rang rang2 = new Rang()
            {
                tables = new List<Table>()
                {
                    new Table(8),
                    new Table(6),
                    new Table(4),
                    new Table(4),
                    new Table(2),
                    new Table(2),
                }
            };

            Rangs = new List<Rang>() { rang1, rang2 };
        }
    }
}
