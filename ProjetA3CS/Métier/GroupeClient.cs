﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier
{
    public class GroupeClient : RestaurantElement
    {
        public TypeRecette CurrentPlat { get; set; }
        public Compteur compteur { get; set; }
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
            compteur = new Compteur() { Time = new Random().Next(5, 10) };
        }

        public override void Tick()
        {
            if(Etat == EtatGroupeClient.Leaving)
            {
                try { TableSelected.grpClient = null;
                TableSelected = null;}
                catch { }
                return;
            }
            compteur.Tick();
            if (compteur.Time == 0 && Etat == EtatGroupeClient.ChoosingMeal)
            {
                Etat = EtatGroupeClient.MealChoosed;
                Console.WriteLine("Les clients on choisi !");
            }
            
            if(Etat == EtatGroupeClient.Eating && compteur.Time == 0)
            {
                Etat = EtatGroupeClient.WaitFordishOut;
                Console.WriteLine("Les clients ont fini de manger");
            }

            if(Etat == EtatGroupeClient.MealChoosed)
            {
                foreach (var client in clients)
                {
                    client.ChooseRecettes();
                    Etat = EtatGroupeClient.WaitForOrder;
                }
            }

            foreach (var client in clients)
            {
                client.Tick();
            }
        }
    }
}
