#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Helpers;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.Misc.Utils;

#endregion

//TODO ORDER
namespace ProjectCeleste.GameFiles.XMLParser.Model
{
    [JsonObject(Title = "string", Description = "")]
    [XmlRoot(ElementName = "string")]
    public class LanguageStringXml : ILanguageString
    {
        public LanguageStringXml()
        {
        }

        [JsonConstructor]
        public LanguageStringXml([JsonProperty(PropertyName = "_locid", Required = Required.Always)] int locId,
            [JsonProperty(PropertyName = "symbol", DefaultValueHandling = DefaultValueHandling.Ignore)] string symbol =
                null,
            [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
            string comment = null,
            [JsonProperty(PropertyName = "text", Required = Required.AllowNull)] string text = null)
        {
            LocId = locId < 0
                ? throw new ArgumentOutOfRangeException(nameof(locId), locId, null)
                : locId;
            Symbol = symbol;
            Comment = comment;
            Text = text;
        }

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

        [JsonProperty(PropertyName = "text", Required = Required.AllowNull)]
        [XmlText]
        public string Text { get; set; }

        public void SetLocId(int locId)
        {
            LocId = locId < 0
                ? throw new ArgumentOutOfRangeException(nameof(locId), locId, null)
                : locId;
        }

        public void SetComment(string comment = null)
        {
            Comment = comment;
        }

        public void SetSymbol(string symbol = null)
        {
            Symbol = symbol;
        }

        public void SetText(string text = null)
        {
            Text = text;
        }
    }

    [JsonObject(Title = "language", Description = "")]
    [XmlRoot(ElementName = "language")]
    public class LanguageXml : DictionaryContainer<int, LanguageStringXml, ILanguageString>,
        ILanguage
    {
        public LanguageXml() : base(key => key.LocId)
        {
        }

        public LanguageXml(string name) : base(key => key.LocId)
        {
            SetName(name);
        }

        [JsonConstructor]
        public LanguageXml([JsonProperty(PropertyName = "name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "string", Required = Required.Always)]
            IEnumerable<LanguageStringXml> languageString) : base(languageString, key => key.LocId)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "string", Required = Required.Always)]
        [XmlElement(ElementName = "string")]
        public LanguageStringXml[] LanguageStringArrayDoNotUse
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
                        excs.Add(new Exception($"Language '{item.LocId}' \"{item.Text}\"", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        public void SetName(string name)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }
    }

    [JsonObject(Title = "stringtable", Description = "")]
    [XmlRoot(ElementName = "stringtable")]
    public class StringTableXml : DictionaryContainer<string, LanguageXml, ILanguage>, IStringTable
    {
        public StringTableXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public StringTableXml([JsonProperty(PropertyName = "version", Required = Required.Always)] int version
            , [JsonProperty(PropertyName = "id", Required = Required.Always)] string id
            , [JsonProperty(PropertyName = "locstart", DefaultValueHandling = DefaultValueHandling.Ignore)] int locstart
            , [JsonProperty(PropertyName = "locend", DefaultValueHandling = DefaultValueHandling.Ignore)] int locend
            , [JsonProperty(PropertyName = "loccurrent", DefaultValueHandling = DefaultValueHandling.Ignore)]
            int loccurrent
            , [JsonProperty(PropertyName = "language", Required = Required.Always)] IEnumerable<LanguageXml> language) :
            base(language, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
            Version = version;
            Id = id;
            LocStart = locstart;
            LocEnd = locend;
            LocCurrent = loccurrent;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "language", Required = Required.Always)]
        [XmlElement(ElementName = "language")]
        public LanguageXml[] LanguageArrayDoNotUse
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
                        excs.Add(new Exception($"Language '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlIgnore]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "version", Required = Required.Always)]
        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "locstart", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "locstart")]
        public int LocStart { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "locend", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "locend")]
        public int LocEnd { get; set; }

        [DefaultValue(0)]
        [JsonProperty(PropertyName = "loccurrent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlAttribute(AttributeName = "loccurrent")]
        public int LocCurrent { get; set; }

        public void SetId(string id)
        {
            throw new NotImplementedException();
        }

        public void SetLocCurrent(int locCurrent)
        {
            throw new NotImplementedException();
        }

        public void SetLocEnd(int locEnd)
        {
            throw new NotImplementedException();
        }

        public void SetLocStart(int locStart)
        {
            throw new NotImplementedException();
        }

        public void SetVersion(int version)
        {
            throw new NotImplementedException();
        }

        public static StringTableXml FromXmlFile(string file)
        {
            var languageXml = XmlUtils.DeserializeFromFile<StringTableXml>(file);

            var filename = Path.GetFileNameWithoutExtension(file)?.ToLower();

            if (filename == null)
                return languageXml;

            languageXml.Id = filename.Replace("fr-fr-", "")
                .Replace("de-de-", "").Replace("es-es-", "").Replace("it-it-", "").Replace("zh-cht-", "").Replace("pt-br-", "");

            if (filename.Contains("fr-fr"))
                languageXml.Gets().First().Name = "French";
            else if (filename.Contains("de-de"))
                languageXml.Gets().First().Name = "German";
            else if (filename.Contains("es-es"))
                languageXml.Gets().First().Name = "Spanish";
            else if (filename.Contains("it-it"))
                languageXml.Gets().First().Name = "Italian";
            else if (filename.Contains("zh-cht"))
                languageXml.Gets().First().Name = "Chinese";
            else if (filename.Contains("pt-br-"))
                languageXml.Gets().First().Name = "Portuguese";
            else
                languageXml.Gets().First().Name = "English";

            return languageXml;
        }
    }

    [JsonObject(Title = "languages", Description = "")]
    [XmlRoot(ElementName = "languages")]
    public class LanguagesXml : DictionaryContainer<string, StringTableXml, IStringTable>,
        ILanguagesXml
    {
        public LanguagesXml() : base(key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public LanguagesXml(
            [JsonProperty(PropertyName = "stringtable", Required = Required.Always)]
            IEnumerable<StringTableXml> stringtable) : base(stringtable, key => key.Id,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "stringtable", Required = Required.Always)]
        [XmlElement(ElementName = "stringtable")]
        public StringTableXml[] LanguageArray
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
                        Add(item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Language '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static ILanguagesXml LanguagesFromXmlFiles(string languagesFolder)
        {
            var prefixLang = new[] {"", "de-DE", "fr-FR", "es-ES", "it-IT", "zh-CHT", "pt-BR" };

            var listFile = new[]
            {
                "econstrings",
                "equipmentstrings",
                "queststringtable",
                "stringtablex"
            };

            var languages = new LanguagesXml();
            foreach (var prefix in prefixLang)
            foreach (var langFile in listFile)
            {
                var fileName = Path.Combine(languagesFolder,
                    $"{(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}-")}{langFile}.xml");
                var newClass = StringTableXml.FromXmlFile(fileName);
                if (!languages.ContainsKey(newClass.Id))
                    languages.Add(newClass);
                else
                    foreach (var newLang in newClass.Gets())
                        languages[newClass.Id].Add(newLang);
            }

            //TODO MOVE TO EXT VERIFY
            var excs = new List<Exception>();
            foreach (var stringTable in languages.Gets())
            {
                var defLang = stringTable["English"];
                foreach (var language in stringTable.Gets(key => !string.Equals(key.Name, defLang.Name,
                    StringComparison.OrdinalIgnoreCase)))
                foreach (var str in defLang.Gets())
                    try
                    {
                        if (!language.ContainsKey(str.LocId))
                            throw new KeyNotFoundException(
                                $"Missing string [Language = {language}; LocId = {str.LocId};]");
                    }
                    catch (Exception e)
                    {
                        excs.Add(e);
                    }
            }
            if (excs.Count > 1)
                throw new AggregateException(excs);

            return languages;
        }
    }
}