using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Serialization;

namespace Tracer.Writer
{
    public interface IWriter
    {
        void Write(TraceResult traceResult, ISerializer serializer);
    }
}
