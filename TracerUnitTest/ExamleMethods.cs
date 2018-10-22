using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer;

namespace TracerUnitTest
{
    public class ExamleMethods
    {
        private readonly ITracer _tracer;

        public ExamleMethods(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void SimpleMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(10);
            _tracer.StopTrace();
        }

        public void WithNestedMethods()
        {
            _tracer.StartTrace();
            SimpleMethod();
            Thread.Sleep(10);
            _tracer.StopTrace();
        }
    }
}
