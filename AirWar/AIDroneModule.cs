using System;

namespace AirWar
{
    public class AIDroneModule
    {
        public string ID { get; private set; }
        public string Role { get; set; }
        public int FlightHours { get; set; }

        public AIDroneModule(string role)
        {
            ID = GenerateID();
            Role = role;
            FlightHours = 0;
        }

        private string GenerateID()
        {
            Random random = new Random();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            return new string(new char[] { letters[random.Next(26)], letters[random.Next(26)], letters[random.Next(26)] });
        }
    }
}
