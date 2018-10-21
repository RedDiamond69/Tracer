using System.IO;

namespace Tracer.Serialization
{
    public interface ISerializer
    {
        void Serialize(TraceResult traceResult, Stream stream);
    }
}
