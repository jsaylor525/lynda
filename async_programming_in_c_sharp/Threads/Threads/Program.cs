using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Main");

            var t1 = new Thread(new ThreadStart(DoWork));
            t1.Start();

            var t2 = new Thread(new ThreadStart(DoWork));
            t2.Start();

            var t3 = new Thread(new ThreadStart(DoWork));
            t3.Start();

            Console.WriteLine("End of Main");
        }

        private static Random rnd = new Random();
        private static int total = 10;

        private static void DoWork()
        {
            int myTotal = total;
            Thread.Sleep(rnd.Next(1, 500));
            total = myTotal + 1;
            Console.WriteLine("Current Thread ID: {0} says {1}", Thread.CurrentThread.ManagedThreadId, total);
            //Thread.Sleep(1000);
        }
    }
}
