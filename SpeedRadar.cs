using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_Arquitectura_Software;

namespace P2_Arquitectura_Software
{
    class SpeedRadar : IMessageWritter
    {
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
        }

        public (string message, bool isSpeeding) GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return (WriteMessage("Catched above legal speed."), true);
            }
            else
            {
                return (WriteMessage("Driving legally."), false);
            }
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}
