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
