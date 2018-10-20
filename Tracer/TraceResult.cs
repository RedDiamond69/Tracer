using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, TracedThread> traceResults;

        public List<TracedThread> TraceResults
        {
            get => new List<TracedThread>(new SortedDictionary<int, TracedThread>(traceResults).Values);
            private set { }
        }

        internal TracedThread AddOrGetTraceResult(int id)
        {
            TracedThread tracedThread;
            if (!traceResults.TryGetValue(id, out tracedThread))
            {
                tracedThread = new TracedThread(id);
                traceResults[id] = tracedThread;
            }
            return tracedThread;
        }

        internal TracedThread GetThreadResult(int id) => traceResults[id];

        internal TraceResult() => traceResults = new ConcurrentDictionary<int, TracedThread>();
    }
}
