using System;
using static System.Net.Mime.MediaTypeNames;

namespace P2_Arquitectura_Software
{
    class Program
    {
        static void Main(string[] args)
        {

            City city = new City();
            // Metemos como argumento la ciudad para que pueda notificarla para revocar licencias
            PoliceStation policeStation = new PoliceStation(city);

            city.RegisterTaxi("0001 AAA");
            city.RegisterTaxi("0002 BBB");
            Taxi taxiOne = city.taxiCars.First();
            Taxi taxiTwo = city.taxiCars.Last();

            policeStation.RegisterCar("0001 CNP", hasRadar : true);
            policeStation.RegisterCar("0002 CNP", hasRadar : false);
            policeStation.RegisterCar("0003 CNP", hasRadar: false);
            PoliceCar policeOne = policeStation.policeCars.First();
            PoliceCar policeTwo = policeStation.policeCars[1];
            PoliceCar policeThree = policeStation.policeCars.Last();
            city.AddPoliceStation(policeStation);

            policeOne.StartPatrol();
            policeOne.UseRadar(taxiOne);
            taxiTwo.StartRide();
            policeTwo.UseRadar(taxiTwo);
            policeTwo.StartPatrol();
            policeTwo.UseRadar(taxiTwo);
            taxiTwo.StopRide();
            policeTwo.StopPatrol();
            taxiOne.StartRide();
            policeThree.StartPatrol();
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