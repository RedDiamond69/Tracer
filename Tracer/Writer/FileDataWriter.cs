using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Serialization;

namespace Tracer.Writer
{
    public class FileDataWriter : IWriter
    {
        private readonly string _filename;

        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            using(FileStream fileStream = new FileStream(_filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(traceResult, fileStream);
            }
        }

        public FileDataWriter(string filename)
        {
            _filename = filename;
        }
    }
}
