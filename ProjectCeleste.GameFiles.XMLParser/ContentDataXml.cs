#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser
{
    [XmlRoot(ElementName = "content")]
    public class ContentDataXmlContent
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(null)]
        [XmlAttribute(AttributeName = "allowingameonly")]
        public string Allowingameonly { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlElement(ElementName = "offerid")]
        public string Offerid { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlElement(ElementName = "contentid")]
        public string Contentid { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "offertypes")]
        public ContentDataXmlOffertypes Offertypes { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "dialog")]
        public ContentDataXmlDialog Dialog { get; set; }

        [DefaultValue(null)]
        [XmlElement(ElementName = "helpdisplayname")]
        public string Helpdisplayname { get; set; }
    }

    [XmlRoot(ElementName = "offertypes")]
    public class ContentDataXmlOffertypes
    {
        [XmlElement(ElementName = "offertype")]
        public HashSet<EOfferTypeEnum> Offertype { get; set; } = new HashSet<EOfferTypeEnum>();
    }

    [XmlRoot(ElementName = "dialog")]
    public class ContentDataXmlDialog
    {
        [Required(AllowEmptyStrings = false)]
        [XmlElement(ElementName = "titlestring")]
        public string Titlestring { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlElement(ElementName = "contentstring")]
        public string Contentstring { get; set; }

        [Required(AllowEmptyStrings = false)]
        [XmlElement(ElementName = "background")]
        public string Background { get; set; }
    }

    [XmlRoot(ElementName = "cost")]
    public class ContentDataXmlCost
    {
        [Required]
        [Range(0, int.MaxValue)]
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [Key]
        [Required]
        [XmlAttribute(AttributeName = "currencytype")]
        public GameCurrencyTypeEnum Currencytype { get; set; }
    }

    [XmlRoot(ElementName = "currencycontent")]
    public class ContentDataXmlCurrencycontent : ContentDataXmlContent
    {
        [Required]
        [XmlElement(ElementName = "cost")]
        public ContentDataXmlCost Cost { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
    }

    [XmlRoot(ElementName = "contentinfo")]
    public class ContentDataXml
    {
        [Required]
        [JsonProperty(PropertyName = "content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public Dictionary<string, ContentDataXmlContent> Content { get; } =
            new Dictionary<string, ContentDataXmlContent>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Trait Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "content")]
        public ContentDataXmlContent[] ContentArrayDoNotUse
        {
            get => Content.Values.ToArray();
            set
            {
                Content.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Content.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Content '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Required]
        [JsonProperty(PropertyName = "currencycontent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public Dictionary<string, ContentDataXmlCurrencycontent> CurrencyContent { get; } =
            new Dictionary<string, ContentDataXmlCurrencycontent>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Trait Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "currencycontent")]
        public ContentDataXmlCurrencycontent[] CurrencycontentArrayDoNotUse
        {
            get => CurrencyContent.Values.ToArray();
            set
            {
                CurrencyContent.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        CurrencyContent.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"CurrencyContent '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static ContentDataXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<ContentDataXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}