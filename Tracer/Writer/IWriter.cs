using Tracer.Serialization;

namespace Tracer.Writer
{
    public interface IWriter
    {
        void Write(TraceResult traceResult, ISerializer serializer);
    }
}
