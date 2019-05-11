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
using ProjectCeleste.GamesFiles.XMLParser.Container;
using ProjectCeleste.GamesFiles.XMLParser.Enum;
using ProjectCeleste.GamesFiles.XMLParser.Helpers;

#endregion

//TODO ORDER
namespace ProjectCeleste.GamesFiles.XMLParser
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
            [JsonProperty(PropertyName = "MapName", DefaultValueHandling = DefaultValueHandling.Ignore)] string mapName,
            [JsonProperty(PropertyName = "MapLocationX", Required = Required.Always)] double mapLocationX,
            [JsonProperty(PropertyName = "MapLocationY", Required = Required.Always)] double mapLocationY,
            [JsonProperty(PropertyName = "MapMarker", Required = Required.AllowNull)] string mapMarker,
            [JsonProperty(PropertyName = "MapPage", Required = Required.Always)] string mapPage,
            [JsonProperty(PropertyName = "LoadScreen", Required = Required.AllowNull)] string loadScreen,
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
            Hidden = isHidden;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Alliance = isAlliance;
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
        [XmlAttribute(AttributeName = "hidden")]
        [XmlIgnore]
        public bool Hidden { get; set; }
        
        [DefaultValue(false)]
        [JsonProperty(PropertyName = "Alliance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "Alliance")]
        public bool Alliance { get; set; }
        
        [DefaultValue(CivilizationEnum.Any)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "CivID", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [XmlElement(ElementName = "CivID")]
        public CivilizationEnum CivId { get; set; } = CivilizationEnum.Any;

        [DefaultValue(null)]
        [JsonProperty(PropertyName = "MapName", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
        [JsonProperty(PropertyName = "LoadScreen", Required = Required.AllowNull)]
        [XmlElement(ElementName = "LoadScreen")]
        public string LoadScreen { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty(PropertyName = "DescriptionStringID", Required = Required.Always)]
        [XmlElement(ElementName = "DescriptionStringID")]
        public int DescriptionStringId { get; set; }

        [Required]
        [Range(-1, int.MaxValue)]
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
    public class RegionsXml : DictionaryContainer<int, RegionXml>
    {
        public RegionsXml() : base(key => key.Id)
        {
        }

        [JsonConstructor]
        public RegionsXml(
            [JsonProperty(PropertyName = "Region", Required = Required.Always)]
            IEnumerable<RegionXml> region) : base(region, key => key.Id)
        {
        }
        
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "Region", Required = Required.Always, Order = 1)]
        [XmlElement(ElementName = "Region")]
        public RegionXml[] RegionArray
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

        public static RegionsXml RegionsFromFolder(string regionFolder)
        {
            var regionsXml = new RegionsXml();
            var excs = new List<Exception>();
            foreach (var file in Directory.GetFiles(regionFolder, "*.region", SearchOption.AllDirectories))
                try
                {
                    var newClass = RegionXml.FromXmlFile(file);
                    regionsXml.Add(newClass);
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