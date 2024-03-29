﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
//TODO JsonConstructor
//TODO JsonProperty
//TODO C# Attribute
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "content", Description = "")]
    [XmlRoot(ElementName = "content")]
    public class ContentDataXmlContent : IContentDataContent
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [DefaultValue(null)]
        [XmlAttribute(AttributeName = "allowingameonly")]
        public string Allowingameonly { get; set; }

        [XmlElement(ElementName = "offerid")]
        public string Offerid { get; set; }

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
        [XmlElement(ElementName = "titlestring")]
        public string Titlestring { get; set; }

        [XmlElement(ElementName = "contentstring")]
        public string Contentstring { get; set; }

        [XmlElement(ElementName = "background")]
        public string Background { get; set; }
    }

    [JsonObject(Title = "cost", Description = "")]
    [XmlRoot(ElementName = "cost")]
    public class ContentDataXmlCost
    {
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [XmlAttribute(AttributeName = "currencytype")]
        public GameCurrencyTypeEnum Currencytype { get; set; }
    }

    [JsonObject(Title = "currencycontent", Description = "")]
    [XmlRoot(ElementName = "currencycontent")]
    public class ContentDataXmlCurrencyContent : ContentDataXmlContent, IContentDataCurrencyContent
    {
        [XmlElement(ElementName = "cost")]
        public ContentDataXmlCost Cost { get; set; }

        [DefaultValue(0)]
        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
    }

    [JsonObject(Title = "contentinfo", Description = "")]
    [XmlRoot(ElementName = "contentinfo")]
    public class ContentDataXml : IContentDataXml
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [JsonProperty(PropertyName = "currencycontent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "currencycontent")]
        public ContentDataXmlCurrencyContent[] CurrencyContentArray
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
        public DictionaryContainer<string, ContentDataXmlContent, IContentDataContent> Content { get; } =
            new DictionaryContainer<string, ContentDataXmlContent, IContentDataContent>(key => key.Name,
                StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        [XmlIgnore]
        public DictionaryContainer<string, ContentDataXmlCurrencyContent, IContentDataCurrencyContent> CurrencyContent
        {
            get;
        } =
            new DictionaryContainer<string, ContentDataXmlCurrencyContent, IContentDataCurrencyContent>(key => key.Name,
                StringComparer.OrdinalIgnoreCase);

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, IContentDataContent> IContentData.Content => Content;

        [JsonIgnore]
        [XmlIgnore]
        IDictionaryContainer<string, IContentDataCurrencyContent> IContentData.CurrencyContent => CurrencyContent;

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IContentDataXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<ContentDataXml>(file);
        }
    }
}