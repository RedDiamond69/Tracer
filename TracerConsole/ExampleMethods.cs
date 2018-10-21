using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer;

namespace TracerConsole
{
    public class ExampleMethods
    {
        private readonly ITracer _tracer;

        internal void Simple()
        {
            _tracer.StartTrace();
            Thread.Sleep(new Random().Next(50, 500));
            _tracer.StopTrace();
        }

        internal void WithNestedMethods()
        {
            _tracer.StartTrace();
            Simple();
            Simple();
            Thread.Sleep(new Random().Next(50, 500));
            _tracer.StopTrace();
        }

        internal void WithTwoLevelNestedMethods()
        {
            _tracer.StartTrace();
            Simple();
            WithNestedMethods();
            Thread.Sleep(new Random().Next(50, 500));
            _tracer.StopTrace();
        }

        internal void MultiThread()
        {
            _tracer.StartTrace();
            List<Thread> threads = new List<Thread>();
            threads.Add(new Thread(new ThreadStart(Simple)));
            threads.Add(new Thread(new ThreadStart(WithNestedMethods)));
            foreach(Thread thread in threads)
            {
                thread.Start();
            }
            Thread.Sleep(new Random().Next(50, 500));
            _tracer.StopTrace();
        }

        internal ExampleMethods(ITracer tracer)
        {
            _tracer = tracer;
        }
    }
}
