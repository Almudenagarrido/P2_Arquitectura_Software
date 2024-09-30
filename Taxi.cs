using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Arquitectura_Software
{
    public class Taxi : Vehicle
    {
        private bool isCarryingPassangers;

        public Taxi(string plate) : base("Taxi", plate)
        {
            isCarryingPassangers = false;
        }
        
        public void StartRide()
        {
            if (isCarryingPassangers)
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
            else
            {
                isCarryingPassangers = true;
                SetSpeed(100);
                Console.WriteLine(WriteMessage("starts a ride."));
            }
        }

        public void StopRide()
        {
            if (!isCarryingPassangers)
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
            else
            {
                isCarryingPassangers = false;
                SetSpeed(45);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
        }
    }
}
