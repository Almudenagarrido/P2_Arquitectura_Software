using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P2_Arquitectura_Software
{
    public class City
    {
        public List<PoliceStation> policeStations { get; private set; }
        public List<Taxi> taxiCars { get; private set; }

        public City()
        {
            this.policeStations = new List<PoliceStation> { };
            this.taxiCars = new List<Taxi> {};
        }

        public void AddPoliceStation(PoliceStation policeStation)
        {
            policeStations.Add(policeStation);
        }

        public void RegisterTaxi(string plate)
        {
            Taxi taxiCar = new Taxi(plate);
            taxiCars.Add(taxiCar);
            Console.WriteLine(taxiCar.WriteMessage(("created.")));
        }

        public void RemoveTaxi(string plate)
        {
            Taxi taxiToRemove = null;

            foreach (Taxi taxi in taxiCars)
            {
                if (taxi.GetPlate() == plate)
                {
                    taxiToRemove = taxi;
                    break;
                }
            }

            if (taxiToRemove != null)
            {
                Console.WriteLine(taxiToRemove.WriteMessage("was removed from city."));
                taxiCars.Remove(taxiToRemove);
            }
            else
            {
                Console.WriteLine($"Taxi with plate {plate}: was not found and could not be removed from city.");
            }
        }
    }
}
