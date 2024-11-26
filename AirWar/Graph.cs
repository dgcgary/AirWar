using System;
using System.Collections.Generic;
using System.Linq;

namespace AirWar
{
    public class Graph
    {
        public List<Airport> Airports { get; private set; }
        public List<AircraftCarrier> AircraftCarriers { get; private set; }
        public List<Route> Routes { get; private set; }
        private Random random;

        public Graph(int numAirports, int numAircraftCarriers)
        {
            Airports = new List<Airport>();
            AircraftCarriers = new List<AircraftCarrier>();
            Routes = new List<Route>();
            random = new Random();

            GenerateAirports(numAirports);
            GenerateAircraftCarriers(numAircraftCarriers);
            GenerateRoutes();
        }

        private void GenerateAirports(int numAirports)
        {
            for (int i = 0; i < numAirports; i++)
            {
                var airport = new Airport($"Airport {i + 1}", random.Next(1000, 5000), random.Next(5, 20));
                Airports.Add(airport);
            }
        }

        private void GenerateAircraftCarriers(int numAircraftCarriers)
        {
            for (int i = 0; i < numAircraftCarriers; i++)
            {
                var carrier = new AircraftCarrier($"Carrier {i + 1}", random.Next(1000, 5000), random.Next(5, 20));
                AircraftCarriers.Add(carrier);
            }
        }

        private void GenerateRoutes()
        {
            var allLocations = new List<Airport>(Airports);
            allLocations.AddRange(AircraftCarriers);

            foreach (var start in allLocations)
            {
                foreach (var end in allLocations)
                {
                    if (start != end)
                    {
                        var distance = random.Next(100, 1000);
                        var isInteroceanic = random.Next(0, 2) == 1;
                        var route = new Route(start, end, distance, isInteroceanic);
                        Routes.Add(route);
                    }
                }
            }
        }

        public List<Route> Dijkstra(Airport start, Airport end)
        {
            var distances = new Dictionary<Airport, int>();
            var previous = new Dictionary<Airport, Airport>();
            var nodes = new List<Airport>();

            foreach (var airport in Airports)
            {
                if (airport == start)
                {
                    distances[airport] = 0;
                }
                else
                {
                    distances[airport] = int.MaxValue;
                }
                nodes.Add(airport);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == end)
                {
                    var path = new List<Route>();
                    while (previous.ContainsKey(smallest))
                    {
                        var prev = previous[smallest];
                        var route = Routes.First(r => r.Start == prev && r.End == smallest);
                        path.Add(route);
                        smallest = prev;
                    }
                    path.Reverse();
                    return path;
                }

                foreach (var neighbor in Routes.Where(r => r.Start == smallest))
                {
                    var alt = distances[smallest] + neighbor.GetWeight();
                    if (alt < distances[neighbor.End])
                    {
                        distances[neighbor.End] = alt;
                        previous[neighbor.End] = smallest;
                    }
                }
            }

            return new List<Route>(); // No se encontró ruta
        }
    }
}
