#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Common;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser
{
    public class VendorXmlItemInfo
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

    [XmlRoot(ElementName = "purchase")]
    public class VendorXmlPurchase
    {
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "trait", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "trait")]
        public VendorXmlItemInfo Trait { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "consumable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "consumable")]
        public VendorXmlItemInfo Consumable { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "material", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "material")]
        public VendorXmlItemInfo Material { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "blueprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "blueprint")]
        public VendorXmlItemInfo Blueprint { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "design", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "design")]
        public VendorXmlItemInfo Design { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "advisor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "advisor")]
        public VendorXmlItemInfo Advisor { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "lootroll", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "lootroll")]
        public VendorXmlItemInfo Lootroll { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "quest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "quest")]
        public VendorXmlItemInfo Quest { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "resource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "resource")]
        public VendorXmlItemInfo Resource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "capitalresource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "capitalresource")]
        public VendorXmlItemInfo CapitalResource { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "gamecurrency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "gamecurrency")]
        public VendorXmlItemInfo GameCurrency { get; set; }

        public string GetKey()
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

    [XmlRoot(ElementName = "item")]
    public class VendorXmlItem
    {
        [Required]
        [JsonProperty(PropertyName = "purchase", Required = Required.Always)]
        [XmlElement(ElementName = "purchase")]
        public VendorXmlPurchase Purchase { get; set; }

        [Required]
        [JsonProperty(PropertyName = "cost", Required = Required.Always)]
        [XmlElement(ElementName = "cost")]
        public ItemCost Cost { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class VendorXmlItems
    {
        [Required]
        [XmlIgnore]
        [JsonProperty(PropertyName = "item", Required = Required.Always)]
        public Dictionary<string, VendorXmlItem> Item { get; } =
            new Dictionary<string, VendorXmlItem>(StringComparer.OrdinalIgnoreCase);

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "item")]
        public VendorXmlItem[] ItemArray
        {
            get => Item.Values.ToArray();
            set
            {
                Item.Clear();
                if (value == null) return;
                var exs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (item.Cost == null || item.Cost.GameCurrency == null && item.Cost.CapitalResource == null)
                            throw new Exception($"Invalid ItemCost '{item.Purchase.GetKey()}'");
                        Item.Add(item.Purchase.GetKey(), item);
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

    [XmlRoot(ElementName = "itemset")]
    public class VendorXmlItemset
    {
        [Required]
        [JsonProperty(PropertyName = "items", Required = Required.AllowNull)]
        [XmlElement(ElementName = "items")]
        public VendorXmlItems Items { get; set; }


        [Required]
        [Range(0, 255)]
        [JsonProperty(PropertyName = "regionid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "regionid")]
        public int Regionid { get; set; }
    }

    [XmlRoot(ElementName = "itemsets")]
    public class VendorXmlItemsets
    {
        [Required]
        [JsonProperty(PropertyName = "itemset", Required = Required.Always)]
        [XmlElement(ElementName = "itemset")]
        public VendorXmlItemset Itemset { get; set; }
    }

    [XmlRoot(ElementName = "vendor")]
    public class VendorXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "protounit", Required = Required.Always)]
        [XmlElement(ElementName = "protounit")]
        public string Protounit { get; set; }

        [Required]
        [JsonProperty(PropertyName = "itemsets", Required = Required.Always)]
        [XmlElement(ElementName = "itemsets")]
        public VendorXmlItemsets Itemsets { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "vendors")]
    public class VendorsXml
    {
        [JsonProperty(PropertyName = "vendor", Required = Required.Always)]
        [XmlIgnore]
        public Dictionary<string, VendorXml> Vendor { get; } =
            new Dictionary<string, VendorXml>(StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        [XmlElement(ElementName = "vendor")]
        public VendorXml[] VendorArray
        {
            get => Vendor.Values.ToArray();
            set
            {
                Vendor.Clear();
                if (value == null) return;
                var exs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Vendor.Add(item.Protounit.Replace("gn_", "Gn_"), item);
                    }
                    catch (Exception e)
                    {
                        exs.Add(e);
                    }
                if (exs.Count > 0)
                    throw new AggregateException(exs);
            }
        }

        public static VendorsXml FromFile(string file)
        {
            return XmlUtils.FromXmlFile<VendorsXml>(file);
        }

        public void SaveToFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}