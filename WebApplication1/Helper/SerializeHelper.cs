using System.IO;
using System.Xml.Serialization;

namespace CouchbaseWebService.Web.Helper
{
    public static class SerializeHelper
    {
        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toDeserialize">To deserialize.</param>
        /// <returns></returns>
        public static object DeserializeObject<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return xmlSerializer.Deserialize(textReader);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize">To serialize.</param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
    }
}