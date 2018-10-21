using System;
using System.IO;
using Tracer.Serialization;

namespace Tracer.Writer
{
    public class ConsoleDataWriter : IWriter
    {
        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            using(Stream outputStream = Console.OpenStandardOutput())
            {
                serializer.Serialize(traceResult, outputStream);
            }
        }
    }
}
