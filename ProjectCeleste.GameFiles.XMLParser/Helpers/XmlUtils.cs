#region Using directives

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Helpers
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

    public static class XmlUtils
    {
        public static void ToXmlFile(this object serializableObject, string xmlFilePath)
        {
            if (serializableObject == null)
                throw new ArgumentNullException(nameof(serializableObject));

            string xml;
            var serializer = new XmlSerializer(serializableObject.GetType());
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = false,
                NewLineHandling = NewLineHandling.None
            };
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            using (var stringWriter = new Utf8StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlWriter, serializableObject, ns);
                }

                xml = stringWriter.ToString();
            }

            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentNullException(nameof(xml));

            if (File.Exists(xmlFilePath))
                File.Delete(xmlFilePath);

            File.WriteAllText(xmlFilePath, xml, Encoding.UTF8);
        }

        public static T FromXmlFile<T>(string xmlFilePath) where T : class
        {
            if (!File.Exists(xmlFilePath))
                throw new FileNotFoundException(nameof(xmlFilePath), xmlFilePath);

            var xml = File.ReadAllText(xmlFilePath, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentNullException(nameof(xml));

            T output;
            var xmls = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                output = (T) xmls.Deserialize(ms);
            }

            return output;
        }
    }
}