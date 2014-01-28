using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serializers.Extensions
{
    public static class BasicExtensions
    {
        public static byte[] ToByteArray(this string value)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(value);
            return byteArray;
        }

        public static string ToStringValue(this byte[] bytes)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(bytes);
            return (constructedString);
        }
    }
}
