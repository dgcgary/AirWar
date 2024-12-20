﻿using System;
using System.Collections.Generic;

namespace AirWar
{
    public class Airport
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
        public int FuelSupply { get; set; }
        public int HangarCapacity { get; set; }
        public List<Airplane> Airplanes { get; private set; }

        public Airport(string name, int fuelSupply, int hangarCapacity)
        {
            ID = Guid.NewGuid();
            Name = name;
            FuelSupply = fuelSupply;
            HangarCapacity = hangarCapacity;
            Airplanes = new List<Airplane>();
        }

        public void AddAirplane(Airplane airplane)
        {
            if (Airplanes.Count < HangarCapacity)
            {
                Airplanes.Add(airplane);
            }
        }

        public void RefuelAirplanes()
        {
            foreach (var airplane in Airplanes)
            {
                int fuelNeeded = airplane.MaxFuel - airplane.Fuel;
                int fuelToGive = Math.Min(fuelNeeded / 3, FuelSupply); // Recargar una tercera parte del combustible faltante
                airplane.Refuel(fuelToGive);
                FuelSupply -= fuelToGive;
            }
        }

        public void CreateAirplane(string name)
        {
            if (Airplanes.Count < HangarCapacity)
            {
                Airplane newAirplane = new Airplane(name, 100, HangarCapacity); // Crear un avión con 100 de combustible inicial
                Airplanes.Add(newAirplane);
            }
        }

        public void RemoveAirplane(Guid airplaneId)
        {
            Airplanes.RemoveAll(a => a.ID == airplaneId);
        }
    }
}
