#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    [JsonObject(Title = "ProtoUnitOverride", Description = "")]
    [XmlRoot(ElementName = "ProtoUnitOverride")]
    public class ProtoUnitOverrideXml : ProtoAge4XmlUnit
    {
    }

    [JsonObject(Title = "ProtoUnitOverrides", Description = "")]
    [XmlRoot(ElementName = "ProtoUnitOverrides")]
    public class ProtoUnitOverridesXml :
        DictionaryContainer<string, ProtoUnitOverrideXml, IProtoAge4Unit>,
        IProtoUnitOverridesXml
    {
        public ProtoUnitOverridesXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public ProtoUnitOverridesXml(
            [JsonProperty(PropertyName = "ProtoUnitOverride", Required = Required.Always)]
            IEnumerable<ProtoUnitOverrideXml> items) : base(
            items, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "ProtoUnitOverride", Required = Required.Always)]
        [XmlElement(ElementName = "ProtoUnitOverride")]
        public ProtoUnitOverrideXml[] ProtoUnitOverrideArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null) return;
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

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IProtoUnitOverridesXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<ProtoUnitOverridesXml>(file);
        }
    }
}