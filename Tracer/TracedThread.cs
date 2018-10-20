using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class TracedThread
    {
        private Stack<TracedMethod> threadMethods;
        private List<TracedMethod> threadTraceMethods;

        internal TracedThread(int id)
        {
            threadMethods = new Stack<TracedMethod>();
            threadTraceMethods = new List<TracedMethod>();
            ThreadID = id;
        }

        public int ThreadID { get; private set; }

        public string LeadTimeToString
        {
            get => String.Format("{0} ms.", LeadTime);
            private set { }
        }

        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(threadTraceMethods);
            private set { }
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
