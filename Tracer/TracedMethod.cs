using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class TracedMethod
    {
        private List<TracedMethod> nestedMethods;
        private Stopwatch stopwatch;

        internal TracedMethod()
        {
            nestedMethods = new List<TracedMethod>();
            stopwatch = new Stopwatch();
        }

        public string MethodName
        {
            get;
            internal set;
        }

        public string MethodClassName
        {
            get;
            internal set;
        }

        public ulong LeadTime
        {
            get => (ulong)stopwatch.ElapsedMilliseconds;
            private set { }
        }

        public string LeadTimeToString
        {
            get => String.Format("{0} ms.", LeadTime);
            private set { }
        }

        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(nestedMethods);
            private set { }
        }

        internal void StartTrace() => stopwatch.Start();

        internal void StopTrace() => stopwatch.Stop();

        internal void AddNestedMethodToList(TracedMethod tracedMethod) => nestedMethods.Add(tracedMethod);
    }
}
