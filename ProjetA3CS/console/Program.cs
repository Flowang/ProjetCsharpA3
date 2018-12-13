using Métier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static Restaurant r = new Restaurant();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Pour combien de temps voulez vous faire fonctionner le Restaurant ?");
            while (true)
            {
                string cmd = Console.ReadLine();
                if(cmd.ToUpper() == "EXIT")
                { break; continue; }
                if (cmd.ToUpper() == "STAT")
                { ShowStats(); continue; }
                if (cmd.ToUpper() == "CLEAR")
                { Console.Clear(); continue; }
                int nbr = 0;
                try { nbr = Convert.ToInt32(cmd); }
                catch { Console.WriteLine("Commande inconnu"); continue; }
                r.TickFor(nbr);
            }
        }

        static void ShowStats()
        {StreamReader sr = new StreamReader("Stat.log");
            float Serveur = convert(sr.ReadLine());
            float Cuisine = convert(sr.ReadLine());
            float ChefRang = convert(sr.ReadLine());
            float MaitreHotel = convert(sr.ReadLine());
            float NombreClient = convert(sr.ReadLine());
            float Total = convert(sr.ReadLine());
            Console.WriteLine("================================");
            Console.WriteLine("");

            Console.WriteLine("Temps Serveur : " + ((Serveur / Total) * 100) + "%");
            Console.WriteLine("Temps Cuisine : " + (Cuisine / Total * 100) + "%");
            Console.WriteLine("Temps ChefRang : " + (ChefRang / Total * 100) + "%");
            Console.WriteLine("Temps MaitreHotel : " + (MaitreHotel / Total * 100) + "%");
            Console.WriteLine("Nombre de client : " + NombreClient);
            Console.WriteLine("Nombre de Tick : " + Total);




            Console.WriteLine("");

            Console.WriteLine("================================");

        }

        static int convert(string input)
        {
           return Convert.ToInt32(input.Split(':')[1]);
        }
    }
}
