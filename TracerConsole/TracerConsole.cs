using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Writer;
using Tracer.Serialization;

namespace TracerConsole
{
    class TracerConsole
    {
        private static readonly Tracer.Tracer tracer = Tracer.Tracer.GetInstance();

        static void Main(string[] args)
        {
            ExampleMethods exampleMethods = new ExampleMethods(tracer);
            exampleMethods.MultiThread();
            IWriter writer = new ConsoleDataWriter();
            writer.Write(tracer.GetTraceResult(), new XmlDataSerializer());
            Console.WriteLine();
            writer.Write(tracer.GetTraceResult(), new JsonSerializer());
            writer = new FileDataWriter("serializeData.xml");
            writer.Write(tracer.GetTraceResult(), new XmlDataSerializer());
            writer = new FileDataWriter("serializeData.json");
            writer.Write(tracer.GetTraceResult(), new JsonSerializer());
            Console.ReadKey();
        }
    }
}
