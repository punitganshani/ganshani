using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serializers
{
    public interface ISerializer<T>
    {
        string Serialize(T value);
        T Deserialize(string value);
    }
}
