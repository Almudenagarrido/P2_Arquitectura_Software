using System;
using System.Collections.Generic;

namespace P2_Arquitectura_Software
{
    public class PoliceCar : Vehicle, IMessageWritter
    {
        private const string typeOfVehicle = "Police";
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private PoliceStation policeStation;
        private bool isChasing;

        public PoliceCar(string plate, PoliceStation policeStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
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
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
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
