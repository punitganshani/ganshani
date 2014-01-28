using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Serializers.Extensions;

namespace Serializers.Types
{
    public class XmlSerializer<T> : ISerializer<T>
    {
        System.Xml.Serialization.XmlSerializer _xmlSerializer = 
            new System.Xml.Serialization.XmlSerializer(typeof(T)); 

        public string Serialize(T value)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            _xmlSerializer.Serialize(xmlTextWriter, value);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            return memoryStream.ToArray().ToStringValue();
        }

        public T Deserialize(string value)
        {
            MemoryStream memoryStream = new MemoryStream(value.ToByteArray());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)_xmlSerializer.Deserialize(memoryStream);
        }
    }
}