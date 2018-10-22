using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tracer
{
    [Serializable, XmlRoot(ElementName = "method"), DataContract(Name = "method")]
    public class TracedMethod
    {
        private List<TracedMethod> nestedMethods;
        private Stopwatch stopwatch;

        public TracedMethod()
        {
            nestedMethods = new List<TracedMethod>();
            stopwatch = new Stopwatch();
        }

        [XmlAttribute(AttributeName = "name"), DataMember(Name = "name", Order = 0)]
        public string MethodName
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "class"), DataMember(Name = "class", Order = 1)]
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

        [XmlAttribute(AttributeName = "time"), DataMember(Name = "time", Order = 2)]
        public string LeadTimeToString
        {
            get => String.Format("{0} ms.", LeadTime);
            set { }
        }

        [XmlElement(ElementName = "method"), DataMember(Name = "methods", Order = 3)]
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
