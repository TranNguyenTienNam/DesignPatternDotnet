using System;

//Tạo các product Interfaces, trong đó với từng product đều có 2 methods GetName() và GetModel()
public interface IDress
{
    string GetName();

    string GetModel();
}
public interface IShoe
{
    string GetName();

    string GetModel();
}

//Tạo Abtract Factory class, trong đó các method để tạo ra các dòng product khác nhau
public interface IFashion
{
    IShoe CreateShoe();

    IDress CreateDress();
}
//Tạo ra các biến thể của Product (concrete product) implement product interface:
public class SummerDress : IDress
{
    public string GetName()
    {
        return "Summber dress";
    }

    public string GetModel()
    {
        return "This is summer dress";
    }
}
public class SummerShoe : IShoe
{
    public string GetName()
    {
        return "Summer shoe";
    }

    public string GetModel()
    {
        return "This is summer shoe";
    }
}
public class WinterShoe : IShoe
{
    public string GetName()
    {
        return "Winter shoe";
    }

    public string GetModel()
    {
        return "This is winter shoe";
    }
}
public class WinterDress : IDress
{
    public string GetName()
    {
        return "Winter dress";
    }

    public string GetModel()
    {
        return "This is winter dress";
    }
}
//Tạo biến thể của từng dòng product:
public class SummerFashion : IFashion
{
    public IShoe CreateShoe()
    {
        return new SummerShoe();
    }

    public IDress CreateDress()
    {
        return new SummerDress();
    }
}
public class WinterFashion : IFashion
{
    public IShoe CreateShoe()
    {
        return new WinterShoe();
    }

    public IDress CreateDress()
    {
        return new WinterDress();
    }
}
//Implemnt client code:
public class Client
{
    public void ClientMethod(IFashion factory)
    {
        var shoe = factory.CreateShoe();
        var dress = factory.CreateDress();

        Console.WriteLine(shoe.GetModel());
        Console.WriteLine(shoe.GetName());

        Console.WriteLine(dress.GetModel());
        Console.WriteLine(dress.GetName());

        Console.WriteLine("**********");
    }
}

namespace Abstract_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract factory demo:");
            Console.WriteLine("**********");

            var client = new Client();

            client.ClientMethod(new SummerFashion());

            client.ClientMethod(new WinterFashion());
        }
    }
}
