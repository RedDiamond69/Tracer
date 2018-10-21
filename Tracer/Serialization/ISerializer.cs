using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Serialization
{
    public interface ISerializer
    {
        void Serialize(TraceResult traceResult, Stream stream);
    }
}
