using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer;

namespace TracerUnitTest
{
    [TestClass]
    public class TracerUnitTest
    {
        private readonly ITracer _tracer = Tracer.Tracer.GetInstance();
        private readonly int waitTime = 100;

        private void SimpleMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(waitTime);
            _tracer.StopTrace();
        }

        [TestMethod]
        public void TimeTest()
        {
            SimpleMethod();
            long actualTime = (long)_tracer.GetTraceResult().TraceResults[0].NestedMethods[0].LeadTime;
            Assert.IsTrue(actualTime >= waitTime);
        }

        [TestMethod]
        public void NameTest()
        {
            SimpleMethod();
            string actualClassName = _tracer.GetTraceResult().TraceResults[0].NestedMethods[0].MethodClassName;
            string actualMethodName = _tracer.GetTraceResult().TraceResults[0].NestedMethods[0].MethodName;
            Assert.AreEqual(actualMethodName, nameof(SimpleMethod));
            Assert.AreEqual(actualClassName, nameof(TracerUnitTest));
        }

        [TestMethod]
        public void ThreadCountTest()
        {
            _tracer.StartTrace();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 4; ++i)
            {
                var thread = new Thread(SimpleMethod);
                threads.Add(thread);
                thread.Start();
            }
            foreach (Thread thread in threads) thread.Join();
            _tracer.StopTrace();
            int actualCountOfThreads = _tracer.GetTraceResult().TraceResults.Count;
            Assert.AreEqual(actualCountOfThreads, 5);
        }

        [TestMethod]
        public void MethodCountTest()
        {
            _tracer.StartTrace();
            for(int i = 0; i < 4; i++) SimpleMethod();
            _tracer.StopTrace();
            int actualCountOfMethods = _tracer.GetTraceResult().TraceResults[0].NestedMethods[3].NestedMethods.Count;
            Assert.AreEqual(actualCountOfMethods, 4);
        }
    }
}
