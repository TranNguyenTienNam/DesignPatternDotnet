using System.Collections.Generic;

namespace BuilderPattern
{
    class Car
    {
        public int NumberOfWheels { get; set; }
        public string SeatBelt { get; set; }
        public string Color { get; set; }
        public string Windscreen { get; set; }
        public string Engine { get; set; }

        public Car(int numberOfWheels,
                   string seatBelt,
                   string color,
                   string windscreen,
                   string engine)
        {
            NumberOfWheels = numberOfWheels;
            SeatBelt = seatBelt;
            Color = color;
            Windscreen = windscreen;
            Engine = engine;
        }

        public override string ToString()
        {
            var content = "";
            content += $"Number of wheels:    \t {NumberOfWheels}\n";
            content += $"Brand of seat belts: \t {SeatBelt}\n";
            content += $"Color:               \t {Color}\n";
            content += $"Windscreen brand:    \t {Windscreen}\n";
            content += $"Engine:              \t {Engine}";
            return content;
        }
    }
}