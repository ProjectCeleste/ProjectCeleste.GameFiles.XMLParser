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
using ProjectCeleste.GameFiles.XMLParser.Model.Common;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "iteminfo", Description = "")]
    public class EconVendorXmlItemInfo
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "level", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "level")]
        public int Level { get; set; }
    }

    [JsonObject(Title = "purchase", Description = "")]
    [XmlRoot(ElementName = "purchase")]
    public class EconVendorXmlPurchase
    {
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "trait")]
        public EconVendorXmlItemInfo Trait { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "consumable")]
        public EconVendorXmlItemInfo Consumable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "material", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "material")]
        public EconVendorXmlItemInfo Material { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "blueprint")]
        public EconVendorXmlItemInfo Blueprint { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "design", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "design")]
        public EconVendorXmlItemInfo Design { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "advisor")]
        public EconVendorXmlItemInfo Advisor { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "lootroll", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "lootroll")]
        public EconVendorXmlItemInfo Lootroll { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "quest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "quest")]
        public EconVendorXmlItemInfo Quest { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "resource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "resource")]
        public EconVendorXmlItemInfo Resource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "capitalresource")]
        public EconVendorXmlItemInfo CapitalResource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrency")]
        public EconVendorXmlItemInfo GameCurrency { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal string GetKey()
        {
            if (Trait != null)
                return Trait.Id;
            if (Consumable != null)
                return Consumable.Id;
            if (Material != null)
                return Material.Id;
            if (Blueprint != null)
                return Blueprint.Id;
            if (Design != null)
                return Design.Id;
            if (Advisor != null)
                return Advisor.Id;
            if (Lootroll != null)
                return Lootroll.Id;
            if (Quest != null)
                return Quest.Id;
            if (Resource != null)
                return Resource.Id;
            if (CapitalResource != null)
                return CapitalResource.Id;
            if (GameCurrency != null)
                return GameCurrency.Id;

            throw new Exception("Invalid Vendor Item");
        }
    }

    [JsonObject(Title = "item", Description = "")]
    [XmlRoot(ElementName = "item")]
    public class EconVendorXmlItem
    {
        [JsonProperty(PropertyName = "purchase", Required = Required.Always)]
        [XmlElement(ElementName = "purchase")]
        public EconVendorXmlPurchase Purchase { get; set; }

        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        [XmlElement(ElementName = "cost")]
        public ItemCostXml Cost { get; set; }
    }

    [JsonObject(Title = "items", Description = "")]
    [XmlRoot(ElementName = "items")]
    public class EconVendorXmlItems : DictionaryContainer<string, EconVendorXmlItem>
    {
        public EconVendorXmlItems() : base(key => key.Purchase.GetKey(), StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconVendorXmlItems(
            [JsonProperty(PropertyName = "item", Required = Required.Always)] IEnumerable<EconVendorXmlItem> items) :
            base(items, key => key.Purchase.GetKey(), StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "item", Required = Required.Always)]
        [XmlElement(ElementName = "item")]
        public EconVendorXmlItem[] ItemArray
        {
            get => Gets().ToArray();
            set
            {
                Clear();
                if (value == null) return;
                var exs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (item.Cost == null || item.Cost.GameCurrency == null && item.Cost.CapitalResource == null)
                            throw new Exception($"Invalid ItemCost '{item.Purchase.GetKey()}'");
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        exs.Add(e);
                    }
                if (exs.Count > 0)
                    throw new AggregateException(exs);
            }
        }
    }

    [JsonObject(Title = "itemset", Description = "")]
    [XmlRoot(ElementName = "itemset")]
    public class EconVendorXmlItemset
    {
        [JsonProperty(PropertyName = "items", Required = Required.AllowNull)]
        [XmlElement(ElementName = "items")]
        public EconVendorXmlItems Items { get; set; }

        [JsonProperty(PropertyName = "regionid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "regionid")]
        public int Regionid { get; set; }
    }

    [JsonObject(Title = "itemsets", Description = "")]
    [XmlRoot(ElementName = "itemsets")]
    public class EconVendorXmlItemsets : IEconVendorItemsets
    {
        [JsonProperty(PropertyName = "itemset", Required = Required.Always)]
        [XmlElement(ElementName = "itemset")]
        public EconVendorXmlItemset Itemset { get; set; }
    }

    [JsonObject(Title = "vendor", Description = "")]
    [XmlRoot(ElementName = "vendor")]
    public class EconVendorXml : IEconVendor
    {
        [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
        [XmlElement(ElementName = "protounit")]
        public string Protounit { get; set; }

        [JsonProperty(PropertyName = "itemsets", Required = Required.Always)]
        [XmlElement(ElementName = "itemsets")]
        public EconVendorXmlItemsets Itemsets { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        IEconVendorItemsets IEconVendor.Itemsets => Itemsets;
    }

    [JsonObject(Title = "vendors", Description = "")]
    [XmlRoot(ElementName = "vendors")]
    public class EconVendorsXml : DictionaryContainer<string, EconVendorXml, IEconVendor>, IEconVendorsXml
    {
        public EconVendorsXml() : base(key => key.Protounit, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconVendorsXml(
            [JsonProperty(PropertyName = "vendor", Required = Required.Always)] IEnumerable<EconVendorXml> traits) :
            base(traits, key => key.Protounit, StringComparer.OrdinalIgnoreCase)
        {
            IEconVendors x = new EconVendorsXml();
            x.Add(new EconVendorXml());
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "vendor", Required = Required.Always)]
        [XmlElement(ElementName = "vendor")]
        public EconVendorXml[] VendorArray
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

        public static IEconVendorsXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<EconVendorsXml>(file);
        }
    }
}