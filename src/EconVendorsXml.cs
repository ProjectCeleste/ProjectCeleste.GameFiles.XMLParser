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

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "iteminfo", Description = "")]
    public class EconVendorXmlItemInfo
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlText]
        public string Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
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
        [Required]
        [JsonProperty(PropertyName = "purchase", Required = Required.Always)]
        [XmlElement(ElementName = "purchase")]
        public EconVendorXmlPurchase Purchase { get; set; }

        [Required]
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
        [Required]
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
                        Add(item);
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
        [Required]
        [JsonProperty(PropertyName = "items", Required = Required.AllowNull)]
        [XmlElement(ElementName = "items")]
        public EconVendorXmlItems Items { get; set; }

        [Required]
        [Range(0, 255)]
        [JsonProperty(PropertyName = "regionid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "regionid")]
        public int Regionid { get; set; }
    }

    [JsonObject(Title = "itemsets", Description = "")]
    [XmlRoot(ElementName = "itemsets")]
    public class EconVendorXmlItemsets
    {
        [Required]
        [JsonProperty(PropertyName = "itemset", Required = Required.Always)]
        [XmlElement(ElementName = "itemset")]
        public EconVendorXmlItemset Itemset { get; set; }
    }

    [JsonObject(Title = "vendor", Description = "")]
    [XmlRoot(ElementName = "vendor")]
    public class EconVendorXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
        [XmlElement(ElementName = "protounit")]
        public string Protounit { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemsets", Required = Required.Always)]
        [XmlElement(ElementName = "itemsets")]
        public EconVendorXmlItemsets Itemsets { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [JsonObject(Title = "vendors", Description = "")]
    [XmlRoot(ElementName = "vendors")]
    public class EconVendorsXml : DictionaryContainer<string, EconVendorXml>
    {
        public EconVendorsXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public EconVendorsXml(
            [JsonProperty(PropertyName = "vendor", Required = Required.Always)] IEnumerable<EconVendorXml> traits) :
            base(traits, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "vendor", Required = Required.Always)]
        [XmlElement(ElementName = "vendor")]
        public EconVendorXml[] VendorArray
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
                        Add(item);
                    }
                    catch (Exception e)
                    {
                        exs.Add(e);
                    }
                if (exs.Count > 0)
                    throw new AggregateException(exs);
            }
        }

        public static EconVendorsXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<EconVendorsXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}