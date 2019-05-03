#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "string", Description = "")]
    [XmlRoot(ElementName = "string")]
    public class LanguageStringXml
    {
        public LanguageStringXml()
        {
        }

        [JsonConstructor]
        public LanguageStringXml([JsonProperty(PropertyName = "_locid", Required = Required.Always)] int locId,
            [JsonProperty(PropertyName = "symbol", DefaultValueHandling = DefaultValueHandling.Ignore)] string symbol,
            [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)] string comment,
            [JsonProperty(PropertyName = "text", Required = Required.AllowNull)] string text)
        {
            LocId = locId;
            Symbol = symbol;
            Comment = comment;
            Text = text;
        }

        [Key]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "_locid", Required = Required.Always)]
        [XmlAttribute(AttributeName = "_locid")]
        public int LocId { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "symbol", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "symbol")]
        public string Symbol { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "comment")]
        public string Comment { get; set; }

        [Required(AllowEmptyStrings = true)]
        [JsonProperty(PropertyName = "text", Required = Required.AllowNull)]
        [XmlText]
        public string Text { get; set; }
    }

    [JsonObject(Title = "language", Description = "")]
    [XmlRoot(ElementName = "language")]
    public class LanguageXml
    {
        public LanguageXml()
        {
            LanguageString = new Dictionary<int, LanguageStringXml>();
        }

        [JsonConstructor]
        public LanguageXml([JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "string", Required = Required.Always)]
            IDictionary<int, LanguageStringXml> languageString)
        {
            Name = name;
            LanguageString = new Dictionary<int, LanguageStringXml>(languageString);
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlIgnore]
        [JsonProperty(PropertyName = "string", Required = Required.Always)]
        public IDictionary<int, LanguageStringXml> LanguageString { get; }

        /// <summary>
        ///     Use LanguageString Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "string")]
        public LanguageStringXml[] LanguageStringArrayDoNotUse
        {
            get => LanguageString.Values.ToArray();
            set
            {
                LanguageString.Clear();
                if (value == null) return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        LanguageString.Add(item.LocId, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Language '{item.LocId}' \"{item.Text}\"", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "stringtable", Description = "")]
    [XmlRoot(ElementName = "stringtable")]
    public class StringTableXml
    {
        public StringTableXml()
        {
            Language = new Dictionary<string, LanguageXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public StringTableXml([JsonProperty(PropertyName = "version", Required = Required.Always)] int version
            , [JsonProperty(PropertyName = "id", Required = Required.Always)] string id
            , [JsonProperty(PropertyName = "locstart", DefaultValueHandling = DefaultValueHandling.Ignore)] int locstart
            , [JsonProperty(PropertyName = "locend", DefaultValueHandling = DefaultValueHandling.Ignore)] int locend
            , [JsonProperty(PropertyName = "loccurrent", DefaultValueHandling = DefaultValueHandling.Ignore)]
            int loccurrent
            , [JsonProperty(PropertyName = "language", Required = Required.Always)] IDictionary<string, LanguageXml> language)
        {
            Version = version;
            Id = id;
            Locstart = locstart;
            Locend = locend;
            Loccurrent = loccurrent;
            Language = new Dictionary<string, LanguageXml>(language, StringComparer.OrdinalIgnoreCase);
        }

        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlIgnore]
        public string Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "locstart", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "locstart")]
        public int Locstart { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "locend", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "locend")]
        public int Locend { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "loccurrent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "loccurrent")]
        public int Loccurrent { get; set; }

        [JsonProperty(PropertyName = "language", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, LanguageXml> Language { get; }

        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "language")]
        public LanguageXml[] LanguageArrayDoNotUse
        {
            get => Language.Values.ToArray();
            set
            {
                Language.Clear();
                if (value == null) return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Language.Add(item.Name, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Language '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static StringTableXml FromXmlFile(string file)
        {
            var languageXml = XmlUtils.FromXmlFile<StringTableXml>(file);

            var filename = Path.GetFileNameWithoutExtension(file)?.ToLower();

            if (filename == null)
                return languageXml;

            languageXml.Id = filename.Replace("fr-fr", "")
                .Replace("de-de", "").Replace("es-es", "").Replace("it-it", "").Replace("zh-cht", "");

            if (filename.Contains("fr-fr"))
                languageXml.Language.Values.First().Name = "French";
            else if (filename.Contains("de-de"))
                languageXml.Language.Values.First().Name = "German";
            else if (filename.Contains("es-es"))
                languageXml.Language.Values.First().Name = "Spanish";
            else if (filename.Contains("it-it"))
                languageXml.Language.Values.First().Name = "Italian";
            else if (filename.Contains("zh-cht"))
                languageXml.Language.Values.First().Name = "Chinese";
            else
                languageXml.Language.Values.First().Name = "English";

            languageXml.LanguageArrayDoNotUse =
                JsonConvert.DeserializeObject<LanguageXml[]>(
                    JsonConvert.SerializeObject(languageXml.Language.Values.ToArray()));

            return languageXml;
        }
    }

    [JsonObject(Title = "languages", Description = "")]
    [XmlRoot(ElementName = "languages")]
    public class LanguagesXml
    {
        public LanguagesXml()
        {
            Language = new Dictionary<string, StringTableXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public LanguagesXml(
            [JsonProperty(PropertyName = "stringtable", Required = Required.Always)]
            IDictionary<string, StringTableXml> language)
        {
            Language = new Dictionary<string, StringTableXml>(language, StringComparer.OrdinalIgnoreCase);
        }

        [JsonProperty(PropertyName = "stringtable", Required = Required.Always)]
        [XmlIgnore]
        public IDictionary<string, StringTableXml> Language { get; }

        /// <summary>
        ///     Use Language Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonIgnore]
        [XmlElement(ElementName = "stringtable")]
        public StringTableXml[] LanguageArrayDoNotUse
        {
            get => Language.Values.ToArray();
            set
            {
                Language.Clear();
                if (value == null) return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Language.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Language '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static LanguagesXml LanguagesFromXmlFiles(string languagesFolder)
        {
            var listFile = new List<string>
            {
                "econstrings.xml",
                "equipmentstrings.xml",
                "queststringtable.xml",
                "stringtablex.xml"
            };

            var prefixLang = new List<string> {"de-DE", "fr-FR", "es-es", "it-it", "zh-cht"};
            var languages = new LanguagesXml();
            foreach (var langFile in listFile)
            {
                var fileName = Path.Combine(languagesFolder, langFile);
                var newClass = StringTableXml.FromXmlFile(fileName);
                foreach (var newLang in newClass.Language.Values)
                    if (!languages.Language.ContainsKey(langFile.Replace(".xml", string.Empty)))
                        languages.Language.Add(langFile.Replace(".xml", string.Empty), newClass);
                    else
                        foreach (var languageString in newLang.LanguageString.Values.ToArray())
                            languages.Language[langFile.Replace(".xml", string.Empty)].Language[newLang.Name]
                                .LanguageString
                                .Add(languageString.LocId, languageString);
            }

            foreach (var prefix in prefixLang)
            foreach (var langFile in listFile)
            {
                var fileName = Path.Combine(languagesFolder, $"{prefix}-{langFile}");
                var newClass = StringTableXml.FromXmlFile(fileName);
                var languageXml = new LanguageXml();
                var lng = languages.Language[langFile.Replace(".xml", string.Empty)].Language["English"];
                languageXml.Name = newClass.Language.Values.First().Name;
                foreach (var newLang in lng.LanguageString.Values.ToArray())
                    languageXml.LanguageString.Add(newLang.LocId,
                        newClass.Language[languageXml.Name].LanguageString.ContainsKey(newLang.LocId)
                            ? newClass.Language[languageXml.Name].LanguageString[newLang.LocId]
                            : throw new KeyNotFoundException(newLang.LocId.ToString()));
                languages.Language[langFile.Replace(".xml", string.Empty)].Language.Add(languageXml.Name, languageXml);
            }

            return languages;
        }
    }
}