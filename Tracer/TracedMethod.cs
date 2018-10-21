using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Tracer
{
    [Serializable, DataContract(Name = "method")]
    public class TracedMethod
    {
        private List<TracedMethod> nestedMethods;
        private Stopwatch stopwatch;

        public TracedMethod()
        {
            nestedMethods = new List<TracedMethod>();
            stopwatch = new Stopwatch();
        }

        [DataMember(Name = "name", Order = 0)]
        public string MethodName
        {
            get;
            set;
        }

        [DataMember(Name = "class", Order = 1)]
        public string MethodClassName
        {
            get;
            set;
        }

        internal ulong LeadTime
        {
            get => (ulong)stopwatch.ElapsedMilliseconds;
            private set { }
        }

        [DataMember(Name = "time", Order = 2)]
        public string LeadTimeToString
        {
            get => String.Format("{0} ms.", LeadTime);
            set { }
        }

        [DataMember(Name = "methods", Order = 3)]
        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(nestedMethods);
            set { }
        }

        internal void StartTrace() => stopwatch.Start();

        internal void StopTrace() => stopwatch.Stop();

        internal void AddNestedMethodToList(TracedMethod tracedMethod) => nestedMethods.Add(tracedMethod);
    }
}
