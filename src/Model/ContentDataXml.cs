#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "content", Description = "")]
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

    [JsonObject(Title = "offertypes", Description = "")]
    [XmlRoot(ElementName = "offertypes")]
    public class ContentDataXmlOffertypes
    {
        [XmlElement(ElementName = "offertype")]
        public HashSet<EOfferTypeEnum> Offertype { get; set; } = new HashSet<EOfferTypeEnum>();
    }

    [JsonObject(Title = "dialog", Description = "")]
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

    [JsonObject(Title = "cost", Description = "")]
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

    [JsonObject(Title = "currencycontent", Description = "")]
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

    [JsonObject(Title = "contentinfo", Description = "")]
    [XmlRoot(ElementName = "contentinfo")]
    public class ContentDataXml : IContentData, IContentDataReadOnly
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonIgnore]
        [JsonProperty(PropertyName = "content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "content")]
        public ContentDataXmlContent[] ContentArray
        {
            get => Content.Gets().ToArray();
            set
            {
                Content.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!Content.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Content '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "currencycontent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "currencycontent")]
        public ContentDataXmlCurrencycontent[] CurrencyContentArray
        {
            get => CurrencyContent.Gets().ToArray();
            set
            {
                CurrencyContent.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        if (!CurrencyContent.Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"CurrencyContent '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<string, ContentDataXmlContent> Content { get; } =
            new DictionaryContainer<string, ContentDataXmlContent>(key => key.Name, StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<string, ContentDataXmlCurrencycontent> CurrencyContent { get; } =
            new DictionaryContainer<string, ContentDataXmlCurrencycontent>(key => key.Name,
                StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, ContentDataXmlContent> IContentData.Content => Content;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, ContentDataXmlCurrencycontent> IContentData.CurrencyContent => CurrencyContent;

        [JsonIgnore]
        [XmlIgnore]
        IReadOnlyContainer<string, ContentDataXmlContent> IContentDataReadOnly.Content => Content;

        [JsonIgnore]
        [XmlIgnore]
        IReadOnlyContainer<string, ContentDataXmlCurrencycontent> IContentDataReadOnly.CurrencyContent =>
            CurrencyContent;

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