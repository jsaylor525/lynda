using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingDelgates
{
    [TestClass]
    public class UnitTest1
    {
        private void DoWork()
        {
            Debug.WriteLine("Hello World");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        delegate void DoWorkDelegate();

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            DoWorkDelegate m = new DoWorkDelegate(DoWork);
            IAsyncResult ar = m.BeginInvoke(null, null);
            // do more
            m.EndInvoke(ar);
        }
    }
}
