using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Arquitectura_Software
{
    public abstract class VehicleWithPlate : Vehicle
    {
        private string plate;

        public VehicleWithPlate(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
        }

        public string GetPlate()
        { return plate; }

        public override string WriteMessage(string customMessage)
        {
            return $"{base.GetTypeOfVehicle()} with plate {GetPlate()}: {customMessage}";
        }
    }
}
