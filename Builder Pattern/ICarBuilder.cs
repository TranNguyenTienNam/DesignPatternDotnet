

namespace BuilderPattern
{
    interface ICarBuilder
    {
        CarBuilder AddWheels(int numberOfWheels);
        CarBuilder AddSeatBelts(string seatBelt);
        CarBuilder Paint(string color);
        CarBuilder AddWindscreen(string windscreen);
        CarBuilder AddEngine(string engine);
        Car Build();
    }
}