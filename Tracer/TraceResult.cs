﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tracer
{
    [Serializable, XmlRoot(ElementName = "root"), DataContract(Name = "result")]
    public class TraceResult
    {
        private ConcurrentDictionary<int, TracedThread> traceResults;

        [XmlArray(ElementName = "threads"), XmlArrayItem(ElementName = "thread"), DataMember(Name = "threads")]
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

        internal TracedThread GetTraceResult(int id) => traceResults[id];

        public TraceResult() => traceResults = new ConcurrentDictionary<int, TracedThread>();
    }
}
