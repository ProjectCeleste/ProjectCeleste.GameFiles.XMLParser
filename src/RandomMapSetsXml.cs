#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GamesFiles.XMLParser.Container;
using ProjectCeleste.GamesFiles.XMLParser.Container.Interface;
using ProjectCeleste.GamesFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser
{
    [JsonObject(Title = "map", Description = "")]
    [XmlRoot(ElementName = "map")]
    public class RandomMapSetXmlMap
    {
        public RandomMapSetXmlMap()
        {
        }

        [JsonConstructor]
        public RandomMapSetXmlMap(
            [JsonProperty(PropertyName = "displayNameID", Required = Required.Always, Order = 1)] int displayNameId,
            [JsonProperty(PropertyName = "path", Required = Required.Always, Order = 2)] string path)
        {
            DisplayNameId = displayNameId;
            Path = !string.IsNullOrWhiteSpace(path) ? path : throw new ArgumentNullException(nameof(path));
        }

        [DefaultValue(0)]
        [XmlAttribute(AttributeName = "displayNameID")]
        [JsonProperty(PropertyName = "displayNameID", Required = Required.Always, Order = 1)]
        public int DisplayNameId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlText]
        [JsonProperty(PropertyName = "path", Required = Required.Always, Order = 2)]
        public string Path { get; set; }
    }

    [JsonObject(Title = "randomMaps", Description = "")]
    [XmlRoot(ElementName = "randomMaps")]
    public class RandomMapSetXml
    {
        public RandomMapSetXml()
        {
            Map = new DictionaryContainer<string, RandomMapSetXmlMap>(key => key.Path, StringComparer.OrdinalIgnoreCase);
        }
        
        [JsonConstructor]
        public RandomMapSetXml([JsonProperty(PropertyName = "id", Required = Required.Always, Order = 1)] string id,
            [JsonProperty(PropertyName = "displayNameID", Required = Required.Always, Order = 1)] int displayNameId,
            [JsonProperty(PropertyName = "imagepath", Required = Required.Always, Order = 3)] string imagepath,
            [JsonProperty(PropertyName = "helpTextID", Required = Required.Always, Order = 4)] int helpTextId,
            [JsonProperty(PropertyName = "cannotReplace", Required = Required.Always, Order = 5)] bool isCannotReplace,
            [JsonProperty(PropertyName = "map", Required = Required.Always, Order = 6)]
            IEnumerable<RandomMapSetXmlMap> map)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id));
            DisplayNameId = displayNameId;
            ImagePath = !string.IsNullOrWhiteSpace(imagepath)
                ? imagepath
                : throw new ArgumentNullException(nameof(imagepath));
            HelpTextId = helpTextId;
            IsCannotReplace = isCannotReplace;
            Map = new DictionaryContainer<string, RandomMapSetXmlMap>(map, key => key.Path, StringComparer.OrdinalIgnoreCase);
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always, Order = 1)]
        [XmlIgnore]
        public string Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displayNameID", Required = Required.Always, Order = 2)]
        [XmlAttribute(AttributeName = "displayNameID")]
        public int DisplayNameId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "imagepath", Required = Required.Always, Order = 3)]
        [XmlAttribute(AttributeName = "imagepath")]
        public string ImagePath { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "helpTextID", Required = Required.Always, Order = 4)]
        [XmlAttribute(AttributeName = "helpTextID")]
        public int HelpTextId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "cannotReplace", Required = Required.Always, Order = 5)]
        [XmlAttribute(AttributeName = "cannotReplace")]
        public bool IsCannotReplace { get; set; }
        
        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, RandomMapSetXmlMap> Map { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "map", Required = Required.Always, Order = 6)]
        [XmlElement(ElementName = "map")]
        public RandomMapSetXmlMap[] MapArray
        {
            get => Map.Gets().ToArray();
            set
            {
                Map.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Map.Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Path}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static RandomMapSetXml FromXmlFile(string file)
        {
            var randomMapSetXml = XmlUtils.FromXmlFile<RandomMapSetXml>(file);

            if (string.IsNullOrWhiteSpace(randomMapSetXml.Id))
                randomMapSetXml.Id = Path.GetFileNameWithoutExtension(file);

            return randomMapSetXml;
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    [JsonObject(Title = "RandomMapSet", Description = "")]
    [XmlRoot(ElementName = "RandomMapSet")]
    public class RandomMapSetsXml : DictionaryContainer<string, RandomMapSetXml>
    {
        public RandomMapSetsXml() : base(key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public RandomMapSetsXml(
            [JsonProperty(PropertyName = "randomMaps", Required = Required.Always, Order = 1)]
            IEnumerable<RandomMapSetXml> randomMaps) : base(randomMaps, key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }
        
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "randomMaps", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "randomMaps")]
        public RandomMapSetXml[] RmArrayDoNotUse
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Add(item);
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
            var randomMapSets = new RandomMapSetsXml();
            var excs = new List<Exception>();
            foreach (var file in Directory.GetFiles(folder, "*.set", SearchOption.TopDirectoryOnly))
                try
                {
                    var newClass = RandomMapSetXml.FromXmlFile(file);
                    randomMapSets.Add(newClass);
                }
                catch (Exception e)
                {
                    excs.Add(new Exception($"Item '{file}'", e));
                }

            if (excs.Count > 0)
                throw new AggregateException(excs);

            return randomMapSets;
        }
    }
}