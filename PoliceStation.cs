using System;
using System.Collections.Generic;

namespace P2_Arquitectura_Software
{
    public class PoliceStation
    {
        public List<PoliceCar> policeCars { get; private set; }
        private bool alertActive;
       
        public PoliceStation()
        {
            policeCars = new List<PoliceCar> { };
            alertActive = false;
        }

        public void RegisterCar(string plate)
        {
            PoliceCar policeCar = new PoliceCar(plate, this);
            policeCars.Add(policeCar);
            Console.WriteLine(policeCar.WriteMessage(("created.")));
        }

        public void ActivateAlert(string plate)
        {
            Console.WriteLine($"Alert activated for vehicle with plate: {plate}");
            alertActive = true;
            
            NotifyCars(plate);
        }

        public void NotifyCars(string plate)
        {
            foreach (var police in policeCars)
            {
                if (police.IsPatrolling())
                {
                    police.ReceiveAlert(plate);
                }
            }
        }
    }
}

