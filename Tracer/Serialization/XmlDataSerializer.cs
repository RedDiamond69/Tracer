﻿using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;

namespace Tracer.Serialization
{
    public class XmlDataSerializer : ISerializer
    {
        private readonly XmlSerializer xmlSerializer;
        private readonly XmlWriterSettings writerSettings;

        public void Serialize(TraceResult traceResult, Stream stream)
        {
            using(XmlWriter xmlWriter = XmlWriter.Create(stream, writerSettings))
            {
                xmlSerializer.Serialize(xmlWriter, traceResult);
            }
        }

        public XmlDataSerializer()
        {
            writerSettings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = Encoding.UTF8,
                CloseOutput = true
            };
            xmlSerializer = new XmlSerializer(typeof(TraceResult));
        }
    }
}
