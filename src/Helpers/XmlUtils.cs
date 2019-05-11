#region Using directives

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Helpers
{
    internal class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

    public static class XmlUtils
    {
        public static void ToXmlFile(this object serializableObject, string xmlFilePath, bool backup = false)
        {
            if (serializableObject == null)
                throw new ArgumentNullException(nameof(serializableObject));

            if (string.IsNullOrWhiteSpace(xmlFilePath))
                throw new ArgumentNullException(nameof(xmlFilePath));

            var xml = SerializeToXml(serializableObject);

            if (File.Exists(xmlFilePath))
            {
                if (backup)
                {
                    var backupFile = $"{xmlFilePath}.bak";

                    if (File.Exists(backupFile))
                        File.Delete(backupFile);

                    File.Move(xmlFilePath, backupFile);
                }

                File.Delete(xmlFilePath);
            }

            File.WriteAllText(xmlFilePath, xml, Encoding.UTF8);
        }

        public static string SerializeToXml(this object serializableObject)
        {
            if (serializableObject == null)
                throw new ArgumentNullException(nameof(serializableObject));

            string output;
            var serializer = new XmlSerializer(serializableObject.GetType());
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true,
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

                output = stringWriter.ToString();
            }
            return output;
        }

        public static T FromXmlFile<T>(string xmlFilePath) where T : class
        {
            if (string.IsNullOrWhiteSpace(xmlFilePath))
                throw new ArgumentNullException(nameof(xmlFilePath));

            return !File.Exists(xmlFilePath)
                ? throw new FileNotFoundException()
                : DeserializeFromXml<T>(File.ReadAllText(xmlFilePath, Encoding.UTF8));
        }

        public static T DeserializeFromXml<T>(string xml) where T : class
        {
            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentNullException(nameof(xml));

            T output;
            var xmls = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                output = (T)xmls.Deserialize(ms);
            }
            return output;
        }

        public static string PrettyXml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentNullException(nameof(xml));

            string output;
            var xmlDoc = XDocument.Parse(xml);
            using (var stringWriter = new Utf8StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    OmitXmlDeclaration = false,
                    NewLineHandling = NewLineHandling.None
                }))
                {
                    xmlDoc.Save(xmlWriter);
                }
                output = stringWriter.ToString();
            }
            return output;
        }
    }
}