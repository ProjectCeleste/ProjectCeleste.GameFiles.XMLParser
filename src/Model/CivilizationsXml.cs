#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
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
    [XmlRoot(ElementName = "agetech")]
    public class CivilizationXmlAgetech
    {
        [XmlElement(ElementName = "age")]
        public string Age { get; set; }

        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }

        [XmlElement(ElementName = "tierequipmentid")]
        public int Tierequipmentid { get; set; }
    }

    [XmlRoot(ElementName = "charactertype")]
    public class CivilizationXmlCharactertype
    {
        [XmlElement(ElementName = "type")]
        public CharacterTypeEnum Type { get; set; }

        [XmlElement(ElementName = "file")]
        public string File { get; set; }
    }

    [XmlRoot(ElementName = "allowedcharactertypes")]
    public class CivilizationXmlAllowedcharactertypes
    {
        [XmlElement(ElementName = "charactertype")]
        public List<CivilizationXmlCharactertype> Charactertype { get; set; }
    }

    [XmlRoot(ElementName = "scenariobaseunits")]
    public class CivilizationXmlScenariobaseunits
    {
        [XmlElement(ElementName = "baseunit")]
        public List<string> Baseunit { get; set; }
    }

    [XmlRoot(ElementName = "startingcity")]
    public class Startingcity
    {
        [XmlElement(ElementName = "cityname")]
        public string Cityname { get; set; }

        [XmlElement(ElementName = "scenariobaseunits")]
        public CivilizationXmlScenariobaseunits Scenariobaseunits { get; set; }
    }

    [XmlRoot(ElementName = "startingcities")]
    public class CivilizationXmlStartingcities
    {
        [XmlElement(ElementName = "startingcity")]
        public List<Startingcity> Startingcity { get; set; }
    }

    [XmlRoot(ElementName = "startingresources")]
    public class CivilizationXmlStartingresources
    {
        [XmlElement(ElementName = "gold")]
        public string Gold { get; set; }

        [XmlElement(ElementName = "food")]
        public string Food { get; set; }

        [XmlElement(ElementName = "wood")]
        public string Wood { get; set; }

        [XmlElement(ElementName = "stone")]
        public string Stone { get; set; }
    }

    [XmlRoot(ElementName = "civcardinfo")]
    public class CivilizationXmlCivcardinfo
    {
        [XmlElement(ElementName = "civstatus")]
        public string Civstatus { get; set; }

        [XmlElement(ElementName = "civcardtext")]
        public string Civcardtext { get; set; }

        [XmlElement(ElementName = "civcardinfotext")]
        public string Civcardinfotext { get; set; }

        [XmlElement(ElementName = "civcardbackground")]
        public string Civcardbackground { get; set; }

        [XmlElement(ElementName = "civcardbackgroundp")]
        public string Civcardbackgroundp { get; set; }

        [XmlElement(ElementName = "civinfobackground")]
        public string Civinfobackground { get; set; }

        [XmlElement(ElementName = "civinfobackgroundp")]
        public string Civinfobackgroundp { get; set; }

        [XmlElement(ElementName = "civshield")]
        public string Civshield { get; set; }
    }

    [XmlRoot(ElementName = "equipmentdialogtextures")]
    public class CivilizationXmlEquipmentdialogtextures
    {
        [XmlElement(ElementName = "tab1background")]
        public string Tab1Background { get; set; }

        [XmlElement(ElementName = "tab2background")]
        public string Tab2Background { get; set; }

        [XmlElement(ElementName = "tab3background")]
        public string Tab3Background { get; set; }

        [XmlElement(ElementName = "tab4background")]
        public string Tab4Background { get; set; }

        [XmlElement(ElementName = "tab1overlay2")]
        public string Tab1Overlay2 { get; set; }

        [XmlElement(ElementName = "tab1overlay3")]
        public string Tab1Overlay3 { get; set; }

        [XmlElement(ElementName = "tab1overlay4")]
        public string Tab1Overlay4 { get; set; }

        [XmlElement(ElementName = "tab2overlay2")]
        public string Tab2Overlay2 { get; set; }

        [XmlElement(ElementName = "tab2overlay3")]
        public string Tab2Overlay3 { get; set; }

        [XmlElement(ElementName = "tab2overlay4")]
        public string Tab2Overlay4 { get; set; }

        [XmlElement(ElementName = "tab3overlay2")]
        public string Tab3Overlay2 { get; set; }

        [XmlElement(ElementName = "tab3overlay3")]
        public string Tab3Overlay3 { get; set; }

        [XmlElement(ElementName = "tab3overlay4")]
        public string Tab3Overlay4 { get; set; }

        [XmlElement(ElementName = "milestonebanner")]
        public string Milestonebanner { get; set; }

        [XmlElement(ElementName = "milestonebannerdisabled")]
        public string Milestonebannerdisabled { get; set; }
    }

    [XmlRoot(ElementName = "homecityloadscreens")]
    public class CivilizationXmlHomecityloadscreens
    {
        [XmlElement(ElementName = "loadscreen")]
        public List<string> Loadscreen { get; set; }
    }

    [XmlRoot(ElementName = "matchmakingtextures")]
    public class CivilizationXmlMatchmakingtextures
    {
        [XmlElement(ElementName = "bannertexture")]
        public string Bannertexture { get; set; }

        [XmlElement(ElementName = "bannertexturecoords")]
        public string Bannertexturecoords { get; set; }

        [XmlElement(ElementName = "portraittexture")]
        public string Portraittexture { get; set; }

        [XmlElement(ElementName = "portraittexturecoords")]
        public string Portraittexturecoords { get; set; }

        [XmlElement(ElementName = "smallportraittexture")]
        public string Smallportraittexture { get; set; }

        [XmlElement(ElementName = "smallportraittexturecoords")]
        public string Smallportraittexturecoords { get; set; }
    }

    [XmlRoot(ElementName = "greeting")]
    public class CivilizationXmlGreeting
    {
        [XmlAttribute(AttributeName = "showleveleffectonclose")]
        public string Showleveleffectonclose { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "welcomedialogs")]
    public class CivilizationXmlWelcomedialogs
    {
        [XmlElement(ElementName = "firstquest")]
        public string Firstquest { get; set; }

        [XmlElement(ElementName = "greeting")]
        public CivilizationXmlGreeting Greeting { get; set; }

        [XmlElement(ElementName = "skiptutorialgreeting")]
        public string Skiptutorialgreeting { get; set; }

        [XmlElement(ElementName = "welcomedialogbackground")]
        public string Welcomedialogbackground { get; set; }
    }

    [XmlRoot(ElementName = "ui")]
    public class CivilizationXmlUi
    {
        [XmlElement(ElementName = "civcardinfo")]
        public CivilizationXmlCivcardinfo Civcardinfo { get; set; }

        [XmlElement(ElementName = "civcardorderindex")]
        public string Civcardorderindex { get; set; }

        [XmlElement(ElementName = "craftschooldialoglayout")]
        public string Craftschooldialoglayout { get; set; }

        [XmlElement(ElementName = "equipmentdialogtextures")]
        public CivilizationXmlEquipmentdialogtextures Equipmentdialogtextures { get; set; }

        [XmlElement(ElementName = "gearbuilding")]
        public string Gearbuilding { get; set; }

        [XmlElement(ElementName = "homecityflagtexture")]
        public string Homecityflagtexture { get; set; }

        [XmlElement(ElementName = "homecityflagbuttonset")]
        public string Homecityflagbuttonset { get; set; }

        [XmlElement(ElementName = "homecityflagbuttonsetlarge")]
        public string Homecityflagbuttonsetlarge { get; set; }

        [XmlElement(ElementName = "homecityloadscreens")]
        public CivilizationXmlHomecityloadscreens Homecityloadscreens { get; set; }

        [XmlElement(ElementName = "levelupuianimprefix")]
        public string Levelupuianimprefix { get; set; }

        [XmlElement(ElementName = "mappage")]
        public string Mappage { get; set; }

        [XmlElement(ElementName = "matchmakingtextures")]
        public CivilizationXmlMatchmakingtextures Matchmakingtextures { get; set; }

        [XmlElement(ElementName = "postgameflagtexture")]
        public string Postgameflagtexture { get; set; }

        [XmlElement(ElementName = "shieldtexture")]
        public string Shieldtexture { get; set; }

        [XmlElement(ElementName = "shieldgreytexture")]
        public string Shieldgreytexture { get; set; }

        [XmlElement(ElementName = "storehousetechid")]
        public string Storehousetechid { get; set; }

        [XmlElement(ElementName = "traiteditordialoglayout")]
        public string Traiteditordialoglayout { get; set; }

        [XmlElement(ElementName = "traiteditortraitsperrow")]
        public string Traiteditortraitsperrow { get; set; }

        [XmlElement(ElementName = "welcomedialogs")]
        public CivilizationXmlWelcomedialogs Welcomedialogs { get; set; }

        [XmlElement(ElementName = "firstquestid")]
        public string Firstquestid { get; set; }
    }

    [XmlRoot(ElementName = "unitregen")]
    public class CivilizationXmlUnitregen
    {
        [XmlElement(ElementName = "unittype")]
        public string Unittype { get; set; }

        [XmlElement(ElementName = "rate")]
        public string Rate { get; set; }

        [XmlElement(ElementName = "idletimeout")]
        public string Idletimeout { get; set; }
    }

    [XmlRoot(ElementName = "wall")]
    public class CivilizationXmlWall
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "civ")]
    public class CivilizationXml
    {
        [XmlElement(ElementName = "agetech")]
        public List<CivilizationXmlAgetech> Agetech { get; set; }

        [XmlElement(ElementName = "alliedid")]
        public string Alliedid { get; set; }

        [XmlElement(ElementName = "alliedotherid")]
        public string Alliedotherid { get; set; }

        [XmlElement(ElementName = "allowedcharactertypes")]
        public CivilizationXmlAllowedcharactertypes Allowedcharactertypes { get; set; }

        [XmlElement(ElementName = "buildingefficiency")]
        public string Buildingefficiency { get; set; }

        [XmlElement(ElementName = "capitolbldgunittype")]
        public string Capitolbldgunittype { get; set; }

        [XmlElement(ElementName = "civid")]
        public CivilizationEnum Civid { get; set; }

        [XmlElement(ElementName = "civmatchingid")]
        public ECivilizationEnum Civmatchingid { get; set; }

        [XmlElement(ElementName = "contentpack")]
        public int Contentpack { get; set; }

        [XmlElement(ElementName = "courierprotoname")]
        public string Courierprotoname { get; set; }

        [XmlElement(ElementName = "culture")]
        public string Culture { get; set; }

        [XmlElement(ElementName = "displaynameid")]
        public string Displaynameid { get; set; }

        [XmlElement(ElementName = "introvideo")]
        public string Introvideo { get; set; }

        [XmlElement(ElementName = "levelupsound")]
        public string Levelupsound { get; set; }

        [XmlElement(ElementName = "main")]
        public string Main { get; set; }

        [XmlElement(ElementName = "mapx")]
        public string Mapx { get; set; }

        [XmlElement(ElementName = "mapy")]
        public string Mapy { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "namestringid")]
        public string Namestringid { get; set; }

        [XmlElement(ElementName = "objectivecompletesound")]
        public string Objectivecompletesound { get; set; }

        [XmlElement(ElementName = "offertype")]
        public COfferTypeEnum Offertype { get; set; }

        [XmlElement(ElementName = "persistentcity")]
        public string Persistentcity { get; set; }

        [XmlElement(ElementName = "portrait")]
        public string Portrait { get; set; }

        [XmlElement(ElementName = "postindustrialtech")]
        public string Postindustrialtech { get; set; }

        [XmlElement(ElementName = "postimperialtech")]
        public string Postimperialtech { get; set; }

        [XmlElement(ElementName = "rollovernameid")]
        public string Rollovernameid { get; set; }

        [XmlElement(ElementName = "startingcities")]
        public CivilizationXmlStartingcities Startingcities { get; set; }

        [XmlElement(ElementName = "startingresources")]
        public CivilizationXmlStartingresources Startingresources { get; set; }

        [XmlElement(ElementName = "statsid")]
        public string Statsid { get; set; }

        [XmlElement(ElementName = "towncenter")]
        public string Towncenter { get; set; }

        [XmlElement(ElementName = "townstartingunit")]
        public List<string> Townstartingunit { get; set; }

        [XmlElement(ElementName = "ui")]
        public CivilizationXmlUi Ui { get; set; }

        [XmlElement(ElementName = "unalliedid")]
        public string Unalliedid { get; set; }

        [XmlElement(ElementName = "unitregen")]
        public CivilizationXmlUnitregen Unitregen { get; set; }

        [XmlElement(ElementName = "wall")]
        public List<CivilizationXmlWall> Wall { get; set; }

        [XmlElement(ElementName = "ignorecommandbutton")]
        public CivilizationXmlIgnorecommandbutton Ignorecommandbutton { get; set; }

        public static CivilizationXml FromXmlFile(string file)
        {
            return XmlUtils.FromXmlFile<CivilizationXml>(file);
        }

        public void SaveToXmlFile(string file)
        {
            this.ToXmlFile(file);
        }
    }

    [XmlRoot(ElementName = "ignorecommandbutton")]
    public class CivilizationXmlIgnorecommandbutton
    {
        [XmlAttribute(AttributeName = "protoname")]
        public string Protoname { get; set; }

        [XmlAttribute(AttributeName = "row")]
        public string Row { get; set; }

        [XmlAttribute(AttributeName = "column")]
        public string Column { get; set; }
    }

    [XmlRoot(ElementName = "civilizations")]
    public class CivilizationsXml : DictionaryContainer<CivilizationEnum, CivilizationXml>, ICivilizations
    {
        public CivilizationsXml() : base(key => key.Civid)
        {
        }

        [JsonConstructor]
        public CivilizationsXml(
            [JsonProperty(PropertyName = "civ", Required = Required.Always)]
            IEnumerable<CivilizationXml> civilizations) : base(key => key.Civid)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Required]
        [JsonProperty(PropertyName = "civ", Required = Required.Always)]
        [XmlElement(ElementName = "civ")]
        public CivilizationXml[] CivilizationArray
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
                        if (!Add(item))
                            throw new Exception("Add fail");
                    }
                    catch (Exception e)
                    {
                        excs.Add(new Exception($"Item '{item.Civid}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public static CivilizationsXml FromFolder(string folder)
        {
            var civs = new CivilizationsXml();
            var excs = new List<Exception>();
            foreach (var file in Directory.GetFiles(folder, "*.xml", SearchOption.TopDirectoryOnly))
                try
                {
                    var newClass = CivilizationXml.FromXmlFile(file);
                    if (!civs.Add(newClass))
                        throw new Exception("Add fail");
                }
                catch (Exception e)
                {
                    excs.Add(new Exception($"Item '{file.Replace(folder, string.Empty)}'", e));
                }
            if (excs.Count > 0)
                throw new AggregateException(excs);

            civs.CivilizationArray = civs.CivilizationArray.OrderBy(key => key.Civid).ToArray();

            return civs;
        }
    }
}