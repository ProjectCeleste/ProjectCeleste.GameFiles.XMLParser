#region Using directives

using System.Runtime.Serialization;
using System.Xml.Serialization;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Enum
{
    public enum SchoolTagEnum
    {
        [XmlEnum("None")] [EnumMember(Value = "None")] None = 0,
        [XmlEnum("[WoodDesigns1]")] [EnumMember(Value = "[WoodDesigns1]")] WoodDesigns1 = 1,
        [XmlEnum("[StoneDesigns1]")] [EnumMember(Value = "[StoneDesigns1]")] StoneDesigns1 = 2,
        [XmlEnum("[MetalDesigns1]")] [EnumMember(Value = "[MetalDesigns1]")] MetalDesigns1 = 3,
        [XmlEnum("[LeatherDesigns1]")] [EnumMember(Value = "[LeatherDesigns1]")] LeatherDesigns1 = 4,
        [XmlEnum("[FarmDesigns1]")] [EnumMember(Value = "[FarmDesigns1]")] FarmDesigns1 = 5,
        [XmlEnum("[AlchemyDesigns1]")] [EnumMember(Value = "[AlchemyDesigns1]")] AlchemyDesigns1 = 6,
        [XmlEnum("[ToolDesigns1]")] [EnumMember(Value = "[ToolDesigns1]")] ToolDesigns1 = 7,
        [XmlEnum("[GemDesigns1]")] [EnumMember(Value = "[GemDesigns1]")] GemDesigns1 = 8,
        [XmlEnum("[ClothDesigns1]")] [EnumMember(Value = "[ClothDesigns1]")] ClothDesigns1 = 9,
        [XmlEnum("[LoreDesigns1]")] [EnumMember(Value = "[LoreDesigns1]")] LoreDesigns1 = 10,
        [XmlEnum("Religion")] [EnumMember(Value = "Religion")] Religion = 21,
        [XmlEnum("Craftsmen")] [EnumMember(Value = "Craftsmen")] Craftsmen = 22,
        [XmlEnum("Engineering")] [EnumMember(Value = "Engineering")] Engineering = 23,
        [XmlEnum("Construction")] [EnumMember(Value = "Construction")] Construction = 24,
        [XmlEnum("MilitaryCollege")] [EnumMember(Value = "MilitaryCollege")] MilitaryCollege = 25,
        [XmlEnum("HorseBreeding")] [EnumMember(Value = "HorseBreeding")] HorseBreeding = 26,
        [XmlEnum("Woodscraft")] [EnumMember(Value = "Woodscraft")] WoodsCraft = 27,
        [XmlEnum("Metalworking")] [EnumMember(Value = "Metalworking")] MetalWorking = 28
    }
}