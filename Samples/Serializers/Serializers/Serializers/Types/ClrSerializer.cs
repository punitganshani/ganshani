using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using Serializers.Extensions;

namespace Serializers
{
    public class ClrSerializer<T> : ISerializer<T>
    {
        NetDataContractSerializer _serializer = new NetDataContractSerializer();

        public string Serialize(T value)
        {
            MemoryStream ms = new MemoryStream();
            _serializer.WriteObject(ms, value);
            string retVal = ms.ToArray().ToStringValue();
            ms.Dispose();
            return retVal;
        }

        public T Deserialize(string value)
        {
            MemoryStream ms = new MemoryStream(value.ToByteArray());
            T obj = (T)_serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
    }
}
