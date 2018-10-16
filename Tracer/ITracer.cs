using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public interface ITracer
    {
        // Called to start measurement.
        void StartTrace();

        // Called to stop measurement.
        void StopTrace();

        // Called to get the measurement result.
        TraceResult GetTraceResult();
    }
}
