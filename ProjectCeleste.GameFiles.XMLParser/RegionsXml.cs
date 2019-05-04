#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
namespace ProjectCeleste.GameFiles.XMLParser
{
    [JsonObject(Title = "Region", Description = "")]
    [XmlRoot(ElementName = "Region")]
    public class RegionXml
    {
        public RegionXml()
        {
        }

        [JsonConstructor]
        public RegionXml([JsonProperty(PropertyName = "Id", Required = Required.Always)] int id,
            [JsonProperty(PropertyName = "Hidden", DefaultValueHandling = DefaultValueHandling.Ignore)] bool isHidden,
            [JsonProperty(PropertyName = "Name", Required = Required.Always)] string name,
            [JsonProperty(PropertyName = "Alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
            bool isAlliance,
            [JsonProperty(PropertyName = "CivID", DefaultValueHandling = DefaultValueHandling.Ignore)]
            CivilizationEnum civId,
            [JsonProperty(PropertyName = "MapName", Required = Required.AllowNull)] string mapName,
            [JsonProperty(PropertyName = "MapLocationX", Required = Required.Always)] double mapLocationX,
            [JsonProperty(PropertyName = "MapLocationY", Required = Required.Always)] double mapLocationY,
            [JsonProperty(PropertyName = "MapMarker", Required = Required.AllowNull)] string mapMarker,
            [JsonProperty(PropertyName = "MapPage", Required = Required.Always)] string mapPage,
            [JsonProperty(PropertyName = "LoadScreen", Required = Required.Always)] string loadScreen,
            [JsonProperty(PropertyName = "DescriptionStringID", Required = Required.Always)] int descriptionStringId,
            [JsonProperty(PropertyName = "DisplayNameStringID", Required = Required.Always)] int displayNameStringId,
            [JsonProperty(PropertyName = "AvatarShield", DefaultValueHandling = DefaultValueHandling.Ignore)]
            string avatarShield,
            [JsonProperty(PropertyName = "FlagIcon", DefaultValueHandling = DefaultValueHandling.Ignore)]
            string flagIcon,
            [JsonProperty(PropertyName = "PlayList", DefaultValueHandling = DefaultValueHandling.Ignore)]
            string playList)
        {
            Id = id;
            IsHidden = isHidden;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            IsAlliance = isAlliance;
            CivId = civId;
            MapName = mapName;
            MapLocationX = mapLocationX;
            MapLocationY = mapLocationY;
            MapMarker = mapMarker;
            MapPage = !string.IsNullOrWhiteSpace(mapPage) ? mapPage : throw new ArgumentNullException(nameof(mapPage));
            LoadScreen = !string.IsNullOrWhiteSpace(loadScreen)
                ? loadScreen
                : throw new ArgumentNullException(nameof(loadScreen));
            DescriptionStringId = descriptionStringId;
            DisplayNameStringId = displayNameStringId;
            AvatarShield = !string.IsNullOrWhiteSpace(avatarShield) ? avatarShield : null;
            FlagIcon = !string.IsNullOrWhiteSpace(flagIcon) ? flagIcon : null;
            PlayList = !string.IsNullOrWhiteSpace(playList) ? playList : null;
        }

        [JsonIgnore]
        [XmlIgnore]
        public string FileName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "Name", Required = Required.Always)]
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [Key]
        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "Id", Required = Required.Always)]
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "Hidden", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public bool IsHidden { get; set; }

        [DefaultValue("false")]
        [JsonIgnore]
        [XmlAttribute(AttributeName = "hidden")]
        public string HiddenStrDoNotUse
        {
            get => IsHidden ? "true" : "false";
            set => IsHidden = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "Alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlIgnore]
        public bool IsAlliance { get; set; }

        [DefaultValue("false")]
        [JsonIgnore]
        [XmlElement(ElementName = "Alliance")]
        public string AllianceStrDoNotUse
        {
            get => IsAlliance ? "true" : "false";
            set => IsAlliance = string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
        }

        [DefaultValue(CivilizationEnum.Any)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "CivID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "CivID")]
        public CivilizationEnum CivId { get; set; } = CivilizationEnum.Any;

        [Required]
        [JsonProperty(PropertyName = "MapName", Required = Required.AllowNull)]
        [XmlElement(ElementName = "MapName")]
        public string MapName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "MapLocationX", Required = Required.Always)]
        [XmlElement(ElementName = "MapLocationX")]
        public double MapLocationX { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [JsonProperty(PropertyName = "MapLocationY", Required = Required.Always)]
        [XmlElement(ElementName = "MapLocationY")]
        public double MapLocationY { get; set; }

        [Required]
        [JsonProperty(PropertyName = "MapMarker", Required = Required.AllowNull)]
        [XmlElement(ElementName = "MapMarker")]
        public string MapMarker { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonProperty(PropertyName = "MapPage", Required = Required.Always)]
        [XmlElement(ElementName = "MapPage")]
        public string MapPage { get; set; }

        [Required]
        [JsonProperty(PropertyName = "LoadScreen", Required = Required.Always)]
        [XmlElement(ElementName = "LoadScreen")]
        public string LoadScreen { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DescriptionStringID", Required = Required.Always)]
        [XmlElement(ElementName = "DescriptionStringID")]
        public int DescriptionStringId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DisplayNameStringID", Required = Required.Always)]
        [XmlElement(ElementName = "DisplayNameStringID")]
        public int DisplayNameStringId { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "AvatarShield", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "AvatarShield")]
        public string AvatarShield { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "FlagIcon", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "FlagIcon")]
        public string FlagIcon { get; set; }

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "PlayList", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "PlayList")]
        public string PlayList { get; set; }

        public static RegionXml FromXmlFile(string file)
        {
            var newClass = XmlUtils.FromXmlFile<RegionXml>(file);
            newClass.FileName = Path.GetFileNameWithoutExtension(file);
            return newClass;
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    [JsonObject(Title = "Regions", Description = "")]
    [XmlRoot(ElementName = "Regions")]
    public class RegionsXml
    {
        public RegionsXml()
        {
            Region = new Dictionary<int, RegionXml>();
        }

        public RegionsXml(IDictionary<int, RegionXml> regions)
        {
            Region = new Dictionary<int, RegionXml>(regions);
        }

        [JsonConstructor]
        public RegionsXml(
            [JsonProperty(PropertyName = "Region", Required = Required.Always, Order = 1)]
            IEnumerable<RegionXml> regions)
        {
            Region = regions.ToDictionary(key => key.Id);
        }

        [JsonIgnore]
        [XmlIgnore]
        public IDictionary<int, RegionXml> Region { get; }

        /// <summary>
        ///     Use Region Dictionary Instead! Only only used for xml parsing.
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "Region", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "Region")]
        public RegionXml[] RegionArrayDoNotUse
        {
            get => Region.Values.ToArray();
            set
            {
                Region.Clear();
                if (value == null)
                    return;
                var excs = new List<Exception>();
                foreach (var item in value)
                    try
                    {
                        Region.Add(item.Id, item);
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Id}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static RegionsXml RegionsFromFolder(string regionFolder)
        {
            var regionsXml = new RegionsXml();
            var excs = new List<Exception>();
            foreach (var file in Directory.GetFiles(regionFolder, "*.region", SearchOption.AllDirectories))
                try
                {
                    var newClass = RegionXml.FromXmlFile(file);
                    regionsXml.Region.Add(newClass.Id, newClass);
                }
                catch (Exception e)
                {
                    excs.Add(new Exception($"Item '{file}'", e));
                }

            if (excs.Count > 0)
                throw new AggregateException(excs);

            return regionsXml;
        }
    }
}