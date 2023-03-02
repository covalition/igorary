// ObjectExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Igorary.Utils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the value of the <paramref name="propName"/> property.
        /// </summary>
        /// <param name="source">The source object</param>
        /// <param name="propName">Property name</param>
        /// <returns></returns>
        public static object GetPropValue(this object source, string propName)
        {
            return source.GetType().GetProperty(propName).GetValue(source, null);
        }

        public static string SerializeXml<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        /*
        public static string ToXmlString(this object o)
        {
            if (o == null)
                return null;

            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);

            XmlSerializer serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(writer, o);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
        */
    }
}
