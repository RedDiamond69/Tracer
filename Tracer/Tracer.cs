using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public sealed class Tracer : ITracer
    {
        private readonly TraceResult traceResult;

        private static volatile Tracer instance = null;
        private static readonly object synsRoot = new object();

        public void StartTrace()
        {

        }

        public void StopTrace()
        {

        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public static Tracer GetInstance()
        {
            if(instance == null)
            {
                lock (synsRoot)
                {
                    if(instance == null)
                    {
                        instance = new Tracer();
                    }
                }
            }
            return instance;
        }
    }
}
