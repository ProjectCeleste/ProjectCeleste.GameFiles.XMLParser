#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "protounit", Description = "")]
    [XmlRoot(ElementName = "protounit")]
    public class ServerProtoDataXmlProtoUnit : IServerProtoUnit
    {
        public ServerProtoDataXmlProtoUnit()
        {
            BuildingLimitType = BuildingLimitTypeEnum.None;
        }

        [JsonConstructor]
        public ServerProtoDataXmlProtoUnit(
            [JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)] string name,
            [JsonProperty(PropertyName = "ismaininventory", DefaultValueHandling = DefaultValueHandling.Ignore,
                Order = 2)] bool isMainInventory,
            [JsonProperty(PropertyName = "numinventoryslots", DefaultValueHandling = DefaultValueHandling.Ignore,
                Order = 3)] int numInventorySlots,
            [JsonProperty(PropertyName = "maxstacksize", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 4)]
            int maxStackSize,
            [JsonProperty(PropertyName = "buildinglimittype", DefaultValueHandling = DefaultValueHandling.Ignore,
                Order = 5)] BuildingLimitTypeEnum buildingLimitType)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            IsMainInventory = isMainInventory;
            NumInventorySlots = numInventorySlots;
            MaxStackSize = maxStackSize;
            BuildingLimitType = buildingLimitType;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always, Order = 1)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "ismaininventory", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 2)]
        [XmlElement(ElementName = "ismaininventory")]
        public bool IsMainInventory { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "numinventoryslots", DefaultValueHandling = DefaultValueHandling.Ignore,
            Order = 3)]
        [XmlElement(ElementName = "numinventoryslots")]
        public int NumInventorySlots { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "maxstacksize", DefaultValueHandling = DefaultValueHandling.Ignore, Order = 4)]
        [XmlElement(ElementName = "maxstacksize")]
        public int MaxStackSize { get; set; }

        [DefaultValue(BuildingLimitTypeEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "buildinglimittype", DefaultValueHandling = DefaultValueHandling.Ignore,
            Order = 5)]
        [XmlElement(ElementName = "buildinglimittype")]
        public BuildingLimitTypeEnum BuildingLimitType { get; set; }
    }

    [JsonObject(Title = "protodata", Description = "")]
    [XmlRoot(ElementName = "protodata")]
    public class ServerProtoDataXml : DictionaryContainer<string, ServerProtoDataXmlProtoUnit, IServerProtoUnit>,
        IServerProtoData
    {
        public ServerProtoDataXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public ServerProtoDataXml(
            [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
            IEnumerable<ServerProtoDataXmlProtoUnit> protounit) : base(protounit, key => key.Name,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "protounit", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "protounit", Order = 1)]
        public ServerProtoDataXmlProtoUnit[] ProtoUnitArrayDoNotUse
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

        public static ServerProtoDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<ServerProtoDataXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }
    }
}