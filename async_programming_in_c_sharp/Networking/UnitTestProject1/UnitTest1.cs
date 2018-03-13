using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace Networking
{
    [TestClass]
    public class UnitTest1
    {
        string url = "http://www.delsink.com";

        [TestMethod]
        public void Test_Download_DelsinkCOM()
        {
            var httpRequestInfo = HttpWebRequest.CreateHttp(url);
            var callback = new AsyncCallback(HttpResponseAvailable);
            var ar = httpRequestInfo.BeginGetResponse(callback, null);

            ar.AsyncWaitHandle.WaitOne();
        }

        private static void HttpResponseAvailable(IAsyncResult ar)
        {
            var httpRequestInfo = ar.AsyncState as HttpWebRequest;
            var httpResponseInfo = httpRequestInfo.EndGetResponse(ar) as HttpWebResponse;

            var rs = httpResponseInfo.GetResponseStream();
            using (var sr = new StreamReader(rs))
            {
                var webpage = sr.ReadToEnd();
            }
        }
    }
}
