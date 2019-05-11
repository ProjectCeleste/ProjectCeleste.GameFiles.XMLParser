﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Container;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
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
    public class CharacterModifierXmlModifierTypeData : DictionaryContainer<CharacterModifierTypeEnum,
        CharacterModifierXmlModifierType>
    {
        public CharacterModifierXmlModifierTypeData() : base(key => key.Type)
        {
        }

        [JsonConstructor]
        public CharacterModifierXmlModifierTypeData(
            [JsonProperty(PropertyName = "modifiertype", Required = Required.Always)]
            IEnumerable<CharacterModifierXmlModifierType> modifier) : base(modifier, key => key.Type)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "modifiertype", Required = Required.Always)]
        [XmlElement(ElementName = "modifiertype")]
        public CharacterModifierXmlModifierType[] Modifier
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
                        Add(item);
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [JsonIgnore]
        [XmlIgnore]
        public IDictionaryContainer<string, CharacterModifierXmlModify> Modify { get; } =
            new DictionaryContainer<string, CharacterModifierXmlModify>(key => key.UnikId,
                StringComparer.OrdinalIgnoreCase);

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "modify", Required = Required.Always)]
        [XmlElement(ElementName = "modify")]
        public CharacterModifierXmlModify[] ModifyArray
        {
            get => Modify.Gets().ToArray();
            set
            {
                Modify.Clear();
                if (value == null)
                    return;

                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Modify.Add(item);
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
    public class CharacterModifiersModifiersXml : DictionaryContainer<string, CharacterModifierXml>
    {
        public CharacterModifiersModifiersXml() : base(key => key.Id, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public CharacterModifiersModifiersXml(
            [JsonProperty(PropertyName = "modifier", Required = Required.Always)]
            IEnumerable<CharacterModifierXml> modifier) : base(modifier, key => key.Id,
            StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "modifier", Required = Required.Always)]
        [XmlElement(ElementName = "modifier")]
        public CharacterModifierXml[] Modifier
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
                        Add(item);
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
        }

        [JsonConstructor]
        public CharacterModifiersXml(
            [JsonProperty(PropertyName = "modifiertypedata", Required = Required.Always)]
            CharacterModifierXmlModifierTypeData modifierTypeData,
            [JsonProperty(PropertyName = "modifiers", Required = Required.Always)]
            CharacterModifiersModifiersXml modifiers)
        {
            ModifierTypeData = modifierTypeData;
            Modifiers = modifiers;
        }

        [Required]
        [JsonProperty(PropertyName = "modifiertypedata", Required = Required.Always)]
        [XmlElement(ElementName = "modifiertypedata")]
        public CharacterModifierXmlModifierTypeData ModifierTypeData { get; set; }

        [Required]
        [JsonProperty(PropertyName = "modifiers", Required = Required.Always)]
        [XmlElement(ElementName = "modifiers")]
        public CharacterModifiersModifiersXml Modifiers { get; set; }

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