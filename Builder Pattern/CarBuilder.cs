using BuilderPattern;
using System.Collections.Generic;
namespace BuilderPattern
{
    class CarBuilder : ICarBuilder
    {
        public int NumberOfWheels { get; set; }
        public string SeatBelt { get; set; }
        public string Color { get; set; }
        public string Windscreen { get; set; }
        public string Engine { get; set; }

        public CarBuilder AddEngine(string engine)
        {
            Engine = engine;
            return this;
        }

        public CarBuilder AddSeatBelts(string seatBelt)
        {
            SeatBelt = seatBelt;
            return this;
        }

        public CarBuilder AddWheels(int numberOfWheels)
        {
            NumberOfWheels = numberOfWheels;
            return this;
        }

        public CarBuilder AddWindscreen(string windscreen)
        {
            Windscreen = windscreen;
            return this;
        }

        public CarBuilder Paint(string color)
        {
            Color = color;
            return this;
        }

        public Car Build()
        {
            return new Car(NumberOfWheels, SeatBelt, Color, Windscreen, Engine);
        }
    }
}