using System;
using System.Collections.Generic;

namespace Observer_Example
{
    public interface ISubject
    {
        public void RegisterObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObservers();
    }

    public class HotGirl : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void NeedAttention()
        {
            Console.WriteLine("\nCough");
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver ob in observers)
            {
                ob.Update();
            }
        }
    }

    public interface IObserver
    {
        public void Update();
    }

    public class StupidGuy : IObserver
    {
        private string name;

        public StupidGuy(string name)
        {
            this.name = name;
        }

        public void Update()
        {
            Console.WriteLine("{0}: Are you OK?", name);
        }
    }

    public class Neighbor : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Call ambulance!!!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HotGirl hotGirl = new HotGirl();

            IObserver simp = new StupidGuy("Ngoc Thinh");
            IObserver simpLord = new StupidGuy("Chi Dat");
            IObserver notMe = new StupidGuy("Tien Nam");

            // Add to friend zone
            hotGirl.RegisterObserver(simp);
            hotGirl.RegisterObserver(simpLord);
            hotGirl.RegisterObserver(notMe);

            //hotGirl.NeedAttention();

            //hotGirl.RemoveObserver(simp);

            //hotGirl.NeedAttention();

            IObserver unknown = new Neighbor();
            hotGirl.RegisterObserver(unknown);
            hotGirl.NeedAttention();

        }
    }
}
