using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using Serializers.Extensions;

namespace Serializers.Types
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        DataContractJsonSerializer _jsonSerializer = new DataContractJsonSerializer(typeof(T)); 

        public string Serialize(T value)
        {
            MemoryStream ms = new MemoryStream();
            _jsonSerializer.WriteObject(ms, value);
            string retVal = ms.ToArray().ToStringValue(); 
            ms.Dispose();
            return retVal;
        }

        public T Deserialize(string value)
        {
            MemoryStream ms = new MemoryStream(value.ToByteArray());
            T obj = (T)_jsonSerializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
    }
}
