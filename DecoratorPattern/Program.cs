using System;
using System.Text;
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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            //Decorator pattern
            IMilktea milktea = new Milktea();
            IMilktea tranChauDecorator = new tranChauDecorator(milktea);
            IMilktea puddingDecorator = new puddingDecorator(tranChauDecorator);
            IMilktea rauCauDecorator = new rauCauDecorator(puddingDecorator);

            var milktea2 = new rauCauDecorator(
                              new tranChauDecorator(
                                 new Milktea()));
            // Kết quả
            Console.WriteLine(rauCauDecorator.GetMilkteaType());
            Console.WriteLine("Giá tiền : " + rauCauDecorator.GetPrice());

            Console.WriteLine(milktea2.GetMilkteaType());
            Console.WriteLine("Giá tiền : " + milktea2.GetPrice());
            Console.ReadLine();
        }
    }
    // Base Interface
    interface IMilktea
    {
        string GetMilkteaType();
        int GetPrice();
    }
    // Conrete Implementation
    class Milktea : IMilktea
    {
        public string GetMilkteaType()
        {
            return "Đây là trà sữa ô ki na wa";
        }
        public int GetPrice()
        {
            return 23000;
        }
    }
    // base decorator
    class MilkteaDecorator : IMilktea
    {
        private IMilktea __milktea;

        public MilkteaDecorator(IMilktea pizza)
        {
            __milktea = pizza;
        }
        public virtual string GetMilkteaType()
        {
            return __milktea.GetMilkteaType();
        }
        public virtual int GetPrice()
        {
            return __milktea.GetPrice();
        }
    }
    
    // concrete decorator
    class tranChauDecorator : MilkteaDecorator
    {
        public tranChauDecorator(IMilktea pizza) : base(pizza) { }
        public override string GetMilkteaType()
        {
            string type = base.GetMilkteaType();
            type += "\r\n với trân châu";
            return type;
        }
        public override int GetPrice()
        {
            int price = base.GetPrice();
            price += 10000;
            return price;
        }
    }
    class puddingDecorator : MilkteaDecorator
    {
        public puddingDecorator(IMilktea pizza) : base(pizza) { }
        public override string GetMilkteaType()
        {
            string type = base.GetMilkteaType();
            type += "\r\n với pudding";
            return type;
        }
        public override int GetPrice()
        {
            int price = base.GetPrice();
            price += 12000;
            return price;
        }
    }
    class rauCauDecorator : MilkteaDecorator
    {
        public rauCauDecorator(IMilktea pizza) : base(pizza) { }
        public override string GetMilkteaType()
        {
            string type = base.GetMilkteaType();
            type += "\r\n với rau câu";
            return type;
        }
        public override int GetPrice()
        {
            int price = base.GetPrice();
            price += 15000;
            return price;
        }
    }
}

