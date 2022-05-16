using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
       

/*           var thread1 = new Thread(() => LazyInitializedSingleton.GetInstance());
            var thread2 = new Thread(() => LazyInitializedSingleton.GetInstance());
            thread1.Start();
            thread2.Start();*/

            var thread3 = new Thread(() => ThreadSafeSingleton.GetInstance());
             var thread4 = new Thread(() => ThreadSafeSingleton.GetInstance());
             thread3.Start();
             thread4.Start();
        }
    }
}
