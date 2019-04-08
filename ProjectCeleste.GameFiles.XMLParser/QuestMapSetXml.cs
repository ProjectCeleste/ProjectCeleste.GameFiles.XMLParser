#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "map")]
    public class RandomMapSetXmlMap
    {
        [DefaultValue(0)]
        [XmlAttribute(AttributeName = "displayNameID")]
        [JsonProperty(PropertyName = "displayNameID", Required = Required.Always)]
        public int DisplayNameId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlText]
        [JsonProperty(PropertyName = "Path", Required = Required.Always)]
        public string Path { get; set; }
    }

    [XmlRoot(ElementName = "randomMaps")]
    public class RandomMapSetXml
    {
        [XmlIgnore]
        [JsonProperty(PropertyName = "map", Required = Required.Always)]
        public Dictionary<string, RandomMapSetXmlMap> Map { get; } =
            new Dictionary<string, RandomMapSetXmlMap>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Map Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [JsonIgnore]
        [XmlElement(ElementName = "map")]
        public RandomMapSetXmlMap[] MapArrayDoNotUse
        {
            get => Map.Values.ToArray();
            set
            {
                Map.Clear();
                if (value == null) return;
                foreach (var item in value)
                    Map.Add(item.Path, item);
            }
        }

        [Key]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "Id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displayNameID", Required = Required.Always)]
        [XmlAttribute(AttributeName = "displayNameID")]
        public int DisplayNameId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "imagepath", Required = Required.Always)]
        [XmlAttribute(AttributeName = "imagepath")]
        public string Imagepath { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "helpTextID", Required = Required.Always)]
        [XmlAttribute(AttributeName = "helpTextID")]
        public int HelpTextId { get; set; }

        [XmlIgnore]
        [JsonProperty(PropertyName = "cannotReplace", Required = Required.Always)]
        public bool IsCannotReplace { get; set; }

        /// <summary>
        ///     Use IsSellable Bool Instead! Only only used for xml parsing.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [JsonIgnore]
        [XmlElement(ElementName = "cannotReplace")]
        public string CannotReplaceStrDoNotUse
        {
            get => IsCannotReplace ? "true" : "false";
            set => IsCannotReplace = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        public static RandomMapSetXml FromFile(string file)
        {
            var randomMapSetXml = XmlUtils.FromXmlFile<RandomMapSetXml>(file);

            randomMapSetXml.Id = Path.GetFileNameWithoutExtension(file);

            return randomMapSetXml;
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    [XmlRoot(ElementName = "RandomMapSet")]
    public class RandomMapSetsXml
    {
        public RandomMapSetsXml()
        {
            RandomMaps = new Dictionary<string, RandomMapSetXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public RandomMapSetsXml(
            [JsonProperty(PropertyName = "randomMaps", Required = Required.Always)]
            IDictionary<string, RandomMapSetXml> rm)
        {
            RandomMaps = new Dictionary<string, RandomMapSetXml>(rm, StringComparer.OrdinalIgnoreCase);
        }

        public RandomMapSetsXml(
            [JsonProperty(PropertyName = "randomMaps", Required = Required.Always)] IEnumerable<RandomMapSetXml> rm)
        {
            RandomMaps = rm.ToDictionary(key => key.Id);
        }


        [JsonProperty(PropertyName = "randomMaps", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, RandomMapSetXml> RandomMaps { get; }

        /// <summary>
        ///     Use RandomMaps Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [JsonIgnore]
        [XmlElement(ElementName = "randomMaps")]
        public RandomMapSetXml[] RmArrayDoNotUse
        {
            get => RandomMaps.Values.ToArray();
            set
            {
                RandomMaps.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        RandomMaps.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static RandomMapSetsXml RandomMapSetsFromFolder(string folder)
        {
            return new RandomMapSetsXml(Directory.GetFiles(folder, "*.set", SearchOption.TopDirectoryOnly)
                .Select(RandomMapSetXml.FromFile));
        }
    }
}