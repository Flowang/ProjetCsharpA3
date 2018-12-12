using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class Plat
    {
        public Compteur compteur { get; set; }
        public List<Recette> recette { get; set; }
        public GroupeClient GroupeClient;
        public Plat(List<Recette> re, GroupeClient groupeClient, Compteur time)
        {
            GroupeClient = groupeClient;
            compteur = time; 
            recette = re; 
        }
    }
}
