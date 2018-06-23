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
            int starttime = DateTime.Now.Millisecond;
            var t1 = new Thread(new ThreadStart(AddToList));
            t1.Start();

            var t2 = new Thread(new ThreadStart(AddToList));
            t2.Start();

            var t3 = new Thread(new ThreadStart(AddToList));
            t3.Start();
            
            Console.WriteLine("Threads started");

            t1.Join();
            t2.Join();
            t3.Join();

            int stoptime = DateTime.Now.Millisecond;

            Console.WriteLine("End of Main, execution took {0}ms to add {1} items to the list", stoptime - starttime, numList.Count);
        }

        private static Random rnd = new Random();
        private static object myLock = new object();
        private static List<int> numList = new List<int>();
        private static void AddToList()
        {
            // Much fast to lock here, about 9ms execution time
            //lock (myLock) {
            for(int ix = 0; ix < 100; ix++) {
                // Much slower to lock here, about 28ms execution time
                Thread.Sleep(rnd.Next(1, 500));
                lock (myLock) {
                    numList.Add(ix);
                }
            }
        }

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
