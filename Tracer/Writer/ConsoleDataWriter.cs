using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
