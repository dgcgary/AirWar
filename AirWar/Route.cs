namespace AirWar
{
    public class Route
    {
        public Airport Start { get; set; }
        public Airport End { get; set; }
        public int Distance { get; set; }
        public bool IsInteroceanic { get; set; }

        public Route(Airport start, Airport end, int distance, bool isInteroceanic)
        {
            Start = start;
            End = end;
            Distance = distance;
            IsInteroceanic = isInteroceanic;
        }

        public int GetWeight()
        {
            int weight = Distance;
            if (End is AircraftCarrier)
            {
                weight += 50; // Peso adicional por aterrizar en portaaviones
            }
            if (IsInteroceanic)
            {
                weight += 100; // Peso adicional por ruta interoceánica
            }
            return weight;
        }
    }
}
