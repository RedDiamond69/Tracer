using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tracer
{
    [Serializable, XmlRoot(ElementName = "thread"), DataContract(Name = "thread")]
    public class TracedThread
    {
        private Stack<TracedMethod> threadMethods;
        private List<TracedMethod> threadTraceMethods;

        public TracedThread() { }

        internal TracedThread(int id)
        {
            threadMethods = new Stack<TracedMethod>();
            threadTraceMethods = new List<TracedMethod>();
            ThreadID = id;
        }

        [XmlAttribute(AttributeName = "id"), DataMember(Name = "id", Order = 0)]
        public int ThreadID { get; set; }

        [XmlAttribute(AttributeName = "time"), DataMember(Name = "time", Order = 1)]
        public string LeadTimeToString
        {
            get => String.Format("{0} ms.", LeadTime);
            set { }
        }

        [XmlElement(ElementName = "method"), DataMember(Name = "methods", Order = 2)]
        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(threadTraceMethods);
            set { }
        }

        private ulong LeadTime
        {
            get => GetLeadTime();
        }

        private ulong GetLeadTime()
        {
            ulong time = 0;
            foreach (TracedMethod tracedMethod in threadTraceMethods)
            {
                time += tracedMethod.LeadTime;
            }
            return time;
        }

        internal void AddThreadTraceMethod(TracedMethod tracedMethod)
        {
            if (threadMethods.Count > 0) threadMethods.Peek().AddNestedMethodToList(tracedMethod);
            else threadTraceMethods.Add(tracedMethod);
            threadMethods.Push(tracedMethod);
        }

        internal void StartTrace(TracedMethod tracedMethod)
        {
            AddThreadTraceMethod(tracedMethod);
            tracedMethod.StartTrace();
        }

        internal void StopTrace() => threadMethods.Pop().StopTrace();
    }
}
