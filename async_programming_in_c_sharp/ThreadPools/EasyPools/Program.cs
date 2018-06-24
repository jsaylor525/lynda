using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyPools
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Current Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));

            Console.WriteLine("Is background Thread? {0}", System.Threading.Thread.CurrentThread.IsBackground);

            mre.WaitOne();
        }

        private static void DoWork(object state)
        {
            Console.WriteLine("Current worker Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Is background Thread? {0}", System.Threading.Thread.CurrentThread.IsBackground);

            mre.Set();
        }
    }
}
