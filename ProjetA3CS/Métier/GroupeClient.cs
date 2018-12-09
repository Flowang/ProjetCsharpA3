using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class GroupeClient : RestaurantElement
    {
        public int TimeSpend { get; private set; }
        public List<Client> clients { get; set; }
        public Table TableSelected { get; set; }
        public bool WaitAssignment { get; set; }
        public bool HaveMenu { get; set; }
        public int ID { get; set; }
        public EtatGroupeClient Etat { get; set; }


        public GroupeClient(int id)
        {
            int random = new Random().Next(1, 10);
            clients = new List<Client>();
            for (int i = 0; i < random; i++)
            {
                clients.Add(new Client(this));
            }
            WaitAssignment = true;
        }

        public override void Tick()
        {
            TimeSpend++;
            if (TimeSpend == 5 && Etat == EtatGroupeClient.ChoosingMeal)
            {
                Etat = EtatGroupeClient.MealChoose;
            }
            foreach(var client in clients)
            {
                client.Tick();
            }
            if(Etat == EtatGroupeClient.MealChoose)
            {
                foreach (var client in clients)
                {
                    client.ChooseRecettes();
                    Etat = EtatGroupeClient.WaitForOrder;
                }
            }
        }
    }
}
