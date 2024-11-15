using System;

namespace AirWar
{
    public class Airplane
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
        public int Fuel { get; set; }
        public int MaxFuel { get; set; }
        public int HangarCapacity { get; set; }

        public Airplane(string name, int maxFuel, int hangarCapacity)
        {
            ID = Guid.NewGuid();
            Name = name;
            MaxFuel = maxFuel;
            Fuel = maxFuel;
            HangarCapacity = hangarCapacity;
        }

        public void Refuel(int amount)
        {
            Fuel = Math.Min(Fuel + amount, MaxFuel);
        }

        public void ConsumeFuel(int amount)
        {
            Fuel = Math.Max(Fuel - amount, 0);
        }
    }
}
