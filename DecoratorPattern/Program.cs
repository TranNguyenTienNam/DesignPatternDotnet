using System;
// 1- Base Interface
// 2- Concrete Class
// 3- Base Decorator Class
// 4- Drived Decorator Classes
namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Decorator pattern
            IPizza pizza = new Pizza();
            IPizza cheeseDecorator = new CheeseDecorator(pizza);
            IPizza tomatoDecorator = new TomatoDecorator(cheeseDecorator);
            IPizza onionDecorator = new OnionDecorator(tomatoDecorator);
            Console.WriteLine(onionDecorator.GetPizzaType());
            Console.ReadLine();
        }
    }
    // Base Interface
    interface IPizza
    {
        string GetPizzaType();
    }
    // Conrete Implementation
    class Pizza : IPizza
    {
        public string GetPizzaType()
        {
            return "Đây là pizza bình thường";
        }
    }
    // base decorator
    class PizzaDecorator : IPizza
    {
        private IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }
        public virtual string GetPizzaType()
        {
            return _pizza.GetPizzaType();
        }
    }
    
    // concrete decorator
    class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra cheese";
            return type;
        }
    }
    class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza) { }
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra tomato";
            return type;
        }
    }
    class OnionDecorator : PizzaDecorator
    {
        public OnionDecorator(IPizza pizza) : base(pizza) { }
        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra onion";
            return type;
        }
    }
}

