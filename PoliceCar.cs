using System;
using System.Collections.Generic;

namespace P2_Arquitectura_Software
{
    public class PoliceCar : VehicleWithPlate, IMessageWritter
    {
        private const string typeOfVehicle = "Police";
        private bool isPatrolling;
        private SpeedRadar? speedRadar; // Podria ser null el radar
        private PoliceStation policeStation;
        private bool isChasing;
        private bool hasRadar;

        public PoliceCar(string plate, PoliceStation policeStation, bool hasRadar) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = hasRadar ? new SpeedRadar(): null;
            this.policeStation = policeStation;
            isChasing = false;
            this.hasRadar = hasRadar;
        }

        public bool IsPatrolling()
            { if (isPatrolling)
                return true;
            return false;
        }

        public void StartPatrol()
        {
            if (isPatrolling)
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
            else
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
        }

        public void StopPatrol()
        {
            isPatrolling = false;
            Console.WriteLine(WriteMessage("stopped patrolling."));
        }

        public void UseRadar(VehicleWithPlate vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);
                    (string meassurement, bool isSpeeding) = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (isSpeeding) { policeStation.ActivateAlert(vehicle.GetPlate()); };
                }
                else { Console.WriteLine(WriteMessage($"has no radar to trigger.")); }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else { Console.WriteLine(WriteMessage($"has no radar to print its history.")); }
        }

        public void ChaseCar(string plate)
        {
            isChasing = true;
            Console.WriteLine(WriteMessage($"chasing infractor car with plate {plate}."));
        }

        public void ReceiveAlert(string plate)
        {
            if (isPatrolling)
                ChaseCar(plate);
        }
    }
}
