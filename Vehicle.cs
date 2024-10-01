using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Arquitectura_Software
{
    public abstract class Vehicle: IMessageWritter
    {
        private string typeOfVehicle;
        private float speed;

        public Vehicle(string typeOfVehicle)
        {   
            this.typeOfVehicle = typeOfVehicle;
            this.speed = 45;
            WriteMessage("Created.");
        }

        public string GetTypeOfVehicle()
            { return typeOfVehicle; }

        public float GetSpeed()
            { return speed; }

        public void SetSpeed(float speed)
            { this.speed = speed; }

        public virtual string WriteMessage(string customMessage)
        {
            return $"{typeOfVehicle}: {customMessage}";
        }
    }
}