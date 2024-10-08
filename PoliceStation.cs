﻿using System;
using System.Collections.Generic;

namespace P2_Arquitectura_Software
{
    public class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> policeCars { get; private set; }
        private bool alertActive;
       
        public PoliceStation()
        {
            policeCars = new List<PoliceCar> { };
            alertActive = false;
            Console.WriteLine(WriteMessage("created."));        
        }

        public void RegisterCar(string plate, bool hasRadar)
        {
            PoliceCar policeCar = new PoliceCar(plate, this, hasRadar);
            policeCars.Add(policeCar);
            string messageRadar = hasRadar ? "with radar" : "without radar";
            Console.WriteLine(WriteMessage(policeCar.WriteMessage(($"created and registered {messageRadar} in police station."))));
        }

        public void ActivateAlert(string plate)
        {
            Console.WriteLine(WriteMessage($"Alert activated for vehicle with plate: {plate}."));
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
        public string WriteMessage(string customMessage)
        {
            return $"Police station: {customMessage}";
        }
    }
}

