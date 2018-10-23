using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Tracer
{
    public sealed class Tracer : ITracer
    {
        private readonly TraceResult traceResult;

        private static volatile Tracer instance = null;
        private static readonly object syncRoot = new object();

        private Tracer()
        {
            traceResult = new TraceResult();
        }

        public void StartTrace()
        {
            MethodBase method = new StackTrace().GetFrame(1).GetMethod();
            TracedMethod tracedMethod = new TracedMethod();
            tracedMethod.MethodClassName = method.ReflectedType.Name;
            tracedMethod.MethodName = method.Name;
            TracedThread tracedThread = traceResult.AddOrGetTraceResult(Thread.CurrentThread.ManagedThreadId);
            tracedThread.StartTrace(tracedMethod);
        }

        public void StopTrace()
        {
            int threadID = Thread.CurrentThread.ManagedThreadId;
            traceResult.GetTraceResult(threadID).StopTrace();
        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public static Tracer GetInstance()
        {
            if(instance == null)
            {
                lock (syncRoot)
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
