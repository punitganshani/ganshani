using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serializers
{
    public enum SerializerType
    {
        /// <summary>
        /// XmlSerializer
        /// </summary>
        Xml,
        /// <summary>
        /// DataContractJsonSerializer
        /// </summary>
        JSON,
        /// <summary>
        /// DataContractSerializer
        /// </summary>
        WCF,
        /// <summary>
        /// NetDataContractSerializer
        /// </summary>
        CLR
    }
}
