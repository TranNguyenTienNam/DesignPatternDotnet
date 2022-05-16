using System;
using System.Text;

namespace Prototype
{
    abstract class GirlFriend
    {
        public string name { get; set; }
        public string listen { get; set; }
        public string response { get; set; }

        public GirlFriend(string name, string say, string response)
        {
            this.name = name;
            this.listen = say;
            this.response = response;
        }
    }

    class Uyen : GirlFriend
    {
        public Uyen(string name, string say, string response) : base(name, say, response)
        {
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Uyen uyen = new Uyen("Uyên", "You : Em ăn cơm chưa", "Uyên : Em ăn cơm rồi");
            Console.WriteLine($"{uyen.name}, {uyen.listen}, {uyen.response}");

            Uyen cloneOfUyen = (Uyen)uyen.Clone();
            cloneOfUyen.listen = "You : Anh ghét em lắm";
            cloneOfUyen.response = "Uyên : Chia tay đi";
            Console.WriteLine($"{cloneOfUyen.name}, {cloneOfUyen.listen}, {cloneOfUyen.response}");
            Console.WriteLine($"{uyen.name}, {uyen.listen}, {uyen.response}");

            Console.ReadLine();
        }
    }
};
