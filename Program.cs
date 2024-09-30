using System;
using static System.Net.Mime.MediaTypeNames;

namespace P2_Arquitectura_Software
{
    class Program
    {
        static void Main(string[] args)
        {

            PoliceStation policeStation = new PoliceStation();
            City city = new City();

            policeStation.RegisterCar("0001 CNP");
            policeStation.RegisterCar("0002 CNP");
            PoliceCar policeOne = policeStation.policeCars.First();
            PoliceCar policeTwo = policeStation.policeCars.Last();
            city.AddPoliceStation(policeStation);

            city.RegisterTaxi("0001 AAA");
            city.RegisterTaxi("0002 BBB");
            Taxi taxiOne = city.taxiCars.First();
            Taxi taxiTwo = city.taxiCars.Last();

            policeOne.StartPatrol();
            policeOne.UseRadar(taxiOne);
            taxiTwo.StartRide();
            policeTwo.UseRadar(taxiTwo);
            policeTwo.StartPatrol();
            policeTwo.UseRadar(taxiTwo);
            taxiTwo.StopRide();
            policeTwo.StopPatrol();
            taxiOne.StartRide();
            taxiOne.StartRide();
            policeOne.StartPatrol();
            policeOne.UseRadar(taxiOne);
            taxiOne.StopRide();
            taxiOne.StopRide();
            policeOne.StopPatrol();
            policeOne.PrintRadarHistory();
            policeTwo.PrintRadarHistory();
        }
    }
}