using System;
using static System.Console;

namespace SingletonPattern
{
    public class EagerInitializedSingleton
    {
        private static EagerInitializedSingleton instance = new EagerInitializedSingleton();

        private EagerInitializedSingleton() {
            WriteLine("Instances created!!");
        }

        public static EagerInitializedSingleton GetInstance()
        {
            return instance;
        }   
    }
    public class LazyInitializedSingleton
    {
        static int Couter = 0;
        private static LazyInitializedSingleton instance;

        private LazyInitializedSingleton() {
            Couter++;
            WriteLine("Instances created " + Couter);
        }

        public static LazyInitializedSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new LazyInitializedSingleton();
            }
            return instance;
        }      
    }
    public class ThreadSafeSingleton
    {
        static int Couter = 0;
        private static readonly object lockObject = new object();
        private static ThreadSafeSingleton instance;


        private ThreadSafeSingleton()
        {
            Couter++;
            WriteLine("Instances created " + Couter);
        }

        public static ThreadSafeSingleton GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new ThreadSafeSingleton();
                }
                return instance;
            }
        }
    }
    public class ThreadSafeUgradeSingleton
    {
        static int Couter = 0;
        private static readonly object lockObject = new object();
        private static volatile ThreadSafeUgradeSingleton instance;

        private ThreadSafeUgradeSingleton() {
            Couter++;
            WriteLine("Instances created " + Couter);
        }

        public static ThreadSafeUgradeSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeUgradeSingleton();
                    }
                }
            }
            return instance;

        }
    }
}
