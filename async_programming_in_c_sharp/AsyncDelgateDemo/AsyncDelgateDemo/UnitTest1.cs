using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingDelegates
{
    [TestClass]
    public class UnitTest1
    {
        private void DoWork()
        {
            Debug.WriteLine("DoWork");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        delegate void DoWorkDelegate();

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("TestMethod1");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            DoWorkDelegate m = new DoWorkDelegate(DoWork);

            AsyncCallback callback = new AsyncCallback(TheCallback);
            IAsyncResult ar = m.BeginInvoke(callback, m);
            // do more

            System.Threading.Thread.Sleep(400);
        }

        private static void TheCallback(IAsyncResult ar)
        {
            Debug.WriteLine("TheCallback");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

            var m = ar.AsyncState as DoWorkDelegate;
            m.EndInvoke(ar);
        }
    }
}
