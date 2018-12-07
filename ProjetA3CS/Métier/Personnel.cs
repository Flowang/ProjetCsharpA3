using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public abstract class RestaurantElement
    {
        public string nom;
        public void Logc(string LogName)
        {
            Console.WriteLine("Nom: " + nom + "Nom de la méthode" + LogName);
        }
        public RestaurantElement(string Nom)
        {
            this.nom = Nom;
        }

        public RestaurantElement()
        {

        }
        public abstract void Tick();

    }
}
