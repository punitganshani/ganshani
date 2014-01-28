using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serializers.Types;

namespace Serializers
{
    public static class SerializerFactory
    {
        private static Dictionary<Type, Dictionary<SerializerType, object>> _knownObjects;

        static SerializerFactory()
        {
            _knownObjects = new Dictionary<Type, Dictionary<SerializerType, object>>();
        }

        internal static ISerializer<T1> Create<T1>(SerializerType serializerType)
        {
            Type type = typeof(T1);

            if (_knownObjects.ContainsKey(type))
            {
                if (_knownObjects[type].ContainsKey(serializerType))
                    return ((ISerializer<T1>)_knownObjects[type][serializerType]);
            }

            ISerializer<T1> returnValue = null;

            switch (serializerType)
            {
                case SerializerType.Xml:
                    returnValue = new XmlSerializer<T1>();
                    break;
                case SerializerType.JSON:
                    returnValue = new JsonSerializer<T1>();
                    break;
                case SerializerType.WCF:
                    returnValue = new WcfSerializer<T1>();
                    break;
                case SerializerType.CLR:
                    returnValue = new ClrSerializer<T1>();
                    break;
                default:
                    throw new NotSupportedException("Unknown serializer type");
                    break;
            }

            if (_knownObjects.ContainsKey(type) == false)
                _knownObjects.Add(type, new Dictionary<SerializerType, object>());

            _knownObjects[type].Add(serializerType, returnValue);


            return returnValue;
        }
    }
}
