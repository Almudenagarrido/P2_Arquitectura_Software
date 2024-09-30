using System;
using System.Collections.Generic;

namespace P2_Arquitectura_Software
{
    public class PoliceCar : Vehicle, IMessageWritter
    {
        private const string typeOfVehicle = "Police";
        private bool isPatrolling;
        private SpeedRadar? speedRadar; // Podria ser null el radar
        private PoliceStation policeStation;
        private bool isChasing;
        private bool hasRadar;

        public PoliceCar(string plate, PoliceStation policeStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = hasRadar ? new SpeedRadar(): null;
            this.policeStation = policeStation;
            isChasing = false;
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

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                }
                else { Console.WriteLine(WriteMessage($"has no radar.")); }
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
            else { Console.WriteLine(WriteMessage($"has no radar.")); }
        }

        public void ChaseCar(string plate)
            { isChasing = true; }

        public void ReceiveAlert(string plate)
        {
            if (!isPatrolling)
                ChaseCar(plate);
                Console.WriteLine(WriteMessage($"chasing infractor car with plate {plate}"));
        }
    }
}
