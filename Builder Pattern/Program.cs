using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(4,
                              new string("ToShiBa"),
                              "red",
                              new string("Yamaha"),
                              new string("Foot"));
            var carByBuilder = new CarBuilder()
                                      .AddWheels(4)
                                      .AddSeatBelts(new string("ToShiBa Seat Belt"))
                                      .AddWindscreen(new string("Yamaha wind screen"))
                                      .AddEngine(new string("BMW Foot"))
                                      .Paint("red")
                                      .Build();
            Console.WriteLine(car.ToString());
            Console.WriteLine("------------------------------------");
            Console.WriteLine(carByBuilder.ToString());
        }
    }
}