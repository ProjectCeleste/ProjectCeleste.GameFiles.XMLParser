#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum.CharacterModifier;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
//TODO JsonConstructor
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "modifiertype", Description = "")]
    [XmlRoot(ElementName = "modifiertype")]
    public class CharacterModifierXmlModifierType
    {
        [Key]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public CharacterModifierTypeEnum Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "tooltipstringid", Required = Required.Always)]
        [XmlElement(ElementName = "tooltipstringid")]
        public int TooltipStringId { get; set; }
    }

    [JsonObject(Title = "modifiertypedata", Description = "")]
    [XmlRoot(ElementName = "modifiertypedata")]
    public class CharacterModifierXmlModifierTypeData
    {
        public CharacterModifierXmlModifierTypeData()
        {
            ModifierType = new Dictionary<CharacterModifierTypeEnum, CharacterModifierXmlModifierType>();
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<CharacterModifierTypeEnum, CharacterModifierXmlModifierType> ModifierType { get; }

        /// <summary>
        ///     Use ModifierType Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "modifiertype", Required = Required.Always)]
        [XmlElement(ElementName = "modifiertype")]
        public CharacterModifierXmlModifierType[] ModifierTypeArrayDoNotUse
        {
            get => ModifierType.Values.ToArray();
            set
            {
                ModifierType.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        ModifierType.Add(item.Type, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Type}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "modify", Description = "")]
    [XmlRoot(ElementName = "modify")]
    public class CharacterModifierXmlModify
    {
        [Key]
        [JsonIgnore]
        [XmlIgnore]
        internal string UnikId => string.IsNullOrWhiteSpace(Category) ? $"{Type}" : $"{Type}-{Category}";

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [XmlAttribute(AttributeName = "type")]
        public CharacterModifierTypeEnum Type { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "relativity", Required = Required.Always)]
        [XmlAttribute(AttributeName = "relativity")]
        public CharacterModifierRelativityEnum Relativity { get; set; }

        [Required]
        [Range(double.MinValue, double.MaxValue)]
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        [XmlAttribute(AttributeName = "amount")]
        public double Amount { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "category", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [DefaultValue(true)]
        [JsonProperty(PropertyName = "visible", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public bool IsVisible { get; set; } = true;

        [DefaultValue("true")]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "visible")]
        public string VisibletrDoNotUse
        {
            get => IsVisible ? "true" : "false";
            set => IsVisible = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }
    }

    [JsonObject(Title = "modifier", Description = "")]
    [XmlRoot(ElementName = "modifier")]
    public class CharacterModifierXml
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "category", Required = Required.Always)]
        [XmlElement(ElementName = "category")]
        public CharacterModifierCategoryEnum Category { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "descriptionid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "descriptionid")]
        public int Descriptionid { get; set; }

        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "displaynameid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "displaynameid")]
        public int Displaynameid { get; set; }

        /// <summary>
        ///     Use Duration TimeSpan Instead! Only only used for xml parsing.
        /// </summary>
        [DefaultValue(null)]
        [JsonIgnore]
        [XmlElement(ElementName = "duration")]
        public string DurationXml
        {
            get => Duration.ToString();
            set => Duration = string.IsNullOrWhiteSpace(value) ? TimeSpan.Zero : TimeSpan.Parse(value);
        }

        [Required]
        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        [XmlIgnore]
        public TimeSpan Duration { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "icon", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [DefaultValue(CharacterModifierStackingBehaviorEnum.None)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "stackingbehavior", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "stackingbehavior")]
        public CharacterModifierStackingBehaviorEnum StackingBehavior { get; set; } =
            CharacterModifierStackingBehaviorEnum.None;

        [Required]
        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, CharacterModifierXmlModify> Modify { get; } =
            new Dictionary<string, CharacterModifierXmlModify>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Use Modify Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "modify", Required = Required.Always)]
        [XmlElement(ElementName = "modify")]
        public CharacterModifierXmlModify[] ModifyArrayDoNotUse
        {
            get => Modify.Values.ToArray();
            set
            {
                Modify.Clear();
                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Modify.Add(item.UnikId, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.UnikId}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "modifiers", Description = "")]
    [XmlRoot(ElementName = "modifiers")]
    public class CharacterModifiersModifiersXml
    {
        public CharacterModifiersModifiersXml()
        {
            Modifier = new Dictionary<string, CharacterModifierXml>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<string, CharacterModifierXml> Modifier { get; }

        /// <summary>
        ///     Use Modify Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "modifier", Required = Required.Always)]
        [XmlElement(ElementName = "modifier")]
        public CharacterModifierXml[] ModifierArrayDoNotUse
        {
            get => Modifier.Values.ToArray();
            set
            {
                Modifier.Clear();
                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Modifier.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }
    }

    [JsonObject(Title = "charactermodifiers", Description = "")]
    [XmlRoot(ElementName = "charactermodifiers")]
    public class CharacterModifiersXml
    {
        public CharacterModifiersXml()
        {
            Modifiertypedata = new CharacterModifierXmlModifierTypeData();
        }

        [Required]
        [JsonProperty(PropertyName = "modifiertypedata", Required = Required.Always)]
        [XmlElement(ElementName = "modifiertypedata")]
        public CharacterModifierXmlModifierTypeData Modifiertypedata { get; set; }

        [Required]
        [JsonProperty(PropertyName = "modifiers", Required = Required.Always)]
        [XmlElement(ElementName = "modifiers")]
        public CharacterModifiersModifiersXml Modifiers { get; set; } = new CharacterModifiersModifiersXml();

        public static CharacterModifiersXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<CharacterModifiersXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }
}