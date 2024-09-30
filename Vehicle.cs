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
        private string? plate;  //Podria no tener matricula
        private float speed;

        public Vehicle(string typeOfVehicle, string? plate = null)
        {   
            this.typeOfVehicle = typeOfVehicle; 
            this.plate = plate; 
            this.speed = 45;
            WriteMessage("Created.");
        }

        public string GetTypeOfVehicle()
            { return typeOfVehicle; }

        public float GetSpeed()
            { return speed; }

        public void SetSpeed(float speed)
            { this.speed = speed; }

        public string? GetPlate()
            { return plate;   }

        public virtual string WriteMessage(string customMessage)
        {
            if (plate != null)
            {
                return $"{typeOfVehicle} with plate {GetPlate()}: {customMessage}";
            }
            else
            {
                return $"{typeOfVehicle}: {customMessage}";
            }
        }
    }
}