#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "Tech", Description = "")]
    [XmlRoot(ElementName = "Tech")]
    public class TechTreeOverridesXmlTech : ITechTreeOverridesTech
    {
        public TechTreeOverridesXmlTech()
        {
        }

        [JsonConstructor]
        public TechTreeOverridesXmlTech([JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "override", Required = Required.Always)] string @override)
        {
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentOutOfRangeException(nameof(name), name, null);
            Override = !string.IsNullOrWhiteSpace(@override)
                ? @override
                : throw new ArgumentOutOfRangeException(nameof(@override), @override, null);
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "override", Required = Required.Always)]
        [XmlText]
        public string Override { get; set; }

        public void SetOverride(string @override)
        {
            Override = !string.IsNullOrWhiteSpace(@override)
                ? @override
                : throw new ArgumentOutOfRangeException(nameof(@override), @override, null);
        }

        public void SetName(string name)
        {
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentOutOfRangeException(nameof(name), name, null);
        }
    }

    [JsonObject(Title = "TechTreeOverrides", Description = "")]
    [XmlRoot(ElementName = "TechTreeOverrides")]
    public class TechTreeOverridesXml : DictionaryContainer<string, TechTreeOverridesXmlTech, ITechTreeOverridesTech>,
        ITechTreeOverridesXml
    {
        public TechTreeOverridesXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        public TechTreeOverridesXml(
            [JsonProperty(PropertyName = "unlockFullTechTree", Required = Required.Always)] bool unlockFullTechTree,
            [JsonProperty(PropertyName = "maxAge", Required = Required.Always)] int maxAge,
            [JsonProperty(PropertyName = "Tech", Required = Required.Always)]
            IEnumerable<TechTreeOverridesXmlTech> tech) :
            base(tech, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
            UnlockFullTechTree = unlockFullTechTree;
            MaxAge = maxAge > 0 && maxAge <= 4
                ? maxAge
                : throw new ArgumentOutOfRangeException(nameof(maxAge), maxAge, null);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "Tech", Required = Required.Always)]
        [XmlElement(ElementName = "Tech")]
        public TechTreeOverridesXmlTech[] TechArray
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
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonProperty(PropertyName = "unlockFullTechTree", Required = Required.Always)]
        [XmlAttribute(AttributeName = "unlockFullTechTree")]
        public bool UnlockFullTechTree { get; set; }

        [JsonProperty(PropertyName = "maxAge", Required = Required.Always)]
        [XmlAttribute(AttributeName = "maxAge")]
        public int MaxAge { get; set; }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public void SetMaxAge(int maxAge)
        {
            MaxAge = maxAge > 0 && maxAge <= 4
                ? maxAge
                : throw new ArgumentOutOfRangeException(nameof(maxAge), maxAge, null);
        }

        public void SetUnlockFullTechTree(bool unlockFullTechTree)
        {
            UnlockFullTechTree = unlockFullTechTree;
        }

        public static ITechTreeOverridesXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<TechTreeOverridesXml>(file);
        }
    }
}