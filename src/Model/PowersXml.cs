#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container;
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
    [JsonObject(Title = "minimapeventtime", Description = "")]
    [XmlRoot(ElementName = "minimapeventtime")]
    public class PowerXmlMinimapeventtime
    {
        [XmlAttribute(AttributeName = "sendalertto")]
        public string Sendalertto { get; set; }

        [XmlText]
        public int Text { get; set; }
    }

    [JsonObject(Title = "tempunitmodify", Description = "")]
    [XmlRoot(ElementName = "tempunitmodify")]
    public class PowerXmlTempunitmodify
    {
        [XmlAttribute(AttributeName = "attachmodel")]
        public string Attachmodel { get; set; }
    }

    [JsonObject(Title = "createunit", Description = "")]
    [XmlRoot(ElementName = "createunit")]
    public class PowerXmlCreateunit
    {
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        [XmlAttribute(AttributeName = "radius")]
        public int Radius { get; set; }

        [XmlAttribute(AttributeName = "delay")]
        public double Delay { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "minradius")]
        public int Minradius { get; set; }

        [XmlAttribute(AttributeName = "maxradius")]
        public int Maxradius { get; set; }

        [XmlAttribute(AttributeName = "forceattc")]
        public string Forceattc { get; set; }

        [XmlAttribute(AttributeName = "pattern")]
        public string Pattern { get; set; }

        [XmlAttribute(AttributeName = "buildrate")]
        public string Buildrate { get; set; }

        [XmlAttribute(AttributeName = "abstractunit")]
        public string Abstractunit { get; set; }

        [XmlAttribute(AttributeName = "forceselectiononfirstunit")]
        public string Forceselectiononfirstunit { get; set; }
    }

    [JsonObject(Title = "placement", Description = "")]
    [XmlRoot(ElementName = "placement")]
    public class PowerXmlPlacement
    {
        [XmlAttribute(AttributeName = "forceonmap")]
        public int Forceonmap { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [JsonObject(Title = "rangeindicatorprotoid", Description = "")]
    [XmlRoot(ElementName = "rangeindicatorprotoid")]
    public class PowerXmlRangeindicatorprotoid
    {
        [XmlAttribute(AttributeName = "radius")]
        public double Radius { get; set; }

        [XmlAttribute(AttributeName = "indicatorcount")]
        public int Indicatorcount { get; set; }

        [XmlAttribute(AttributeName = "speed")]
        public double Speed { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [JsonObject(Title = "unitmodify", Description = "")]
    [XmlRoot(ElementName = "unitmodify")]
    public class PowerXmlUnitmodify
    {
        [XmlAttribute(AttributeName = "amount")]
        public double Amount { get; set; }

        [XmlAttribute(AttributeName = "apply")]
        public string Apply { get; set; }

        [XmlAttribute(AttributeName = "attachmodel")]
        public string Attachmodel { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [JsonObject(Title = "cost", Description = "")]
    [XmlRoot(ElementName = "cost")]
    public class PowerXmlCost
    {
        [XmlElement(ElementName = "food")]
        public int Food { get; set; }

        [XmlElement(ElementName = "stone")]
        public int Stone { get; set; }

        [XmlElement(ElementName = "gold")]
        public int Gold { get; set; }

        [XmlElement(ElementName = "wood")]
        public int Wood { get; set; }
    }

    [JsonObject(Title = "power", Description = "")]
    [XmlRoot(ElementName = "power")]
    public class PowerXml : IPower
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "displaynameid")]
        public int Displaynameid { get; set; }

        [XmlElement(ElementName = "rolloverid")]
        public int Rolloverid { get; set; }

        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }

        [XmlElement(ElementName = "minimapeventtime")]
        public PowerXmlMinimapeventtime Minimapeventtime { get; set; }

        [XmlElement(ElementName = "activetime")]
        public int Activetime { get; set; }

        [XmlElement(ElementName = "tempunitmodify")]
        public PowerXmlTempunitmodify Tempunitmodify { get; set; }

        [XmlElement(ElementName = "createunit")]
        public List<PowerXmlCreateunit> Createunit { get; set; }

        [XmlElement(ElementName = "placement")]
        public PowerXmlPlacement Placement { get; set; }

        [XmlElement(ElementName = "rangeindicatorprotoid")]
        public PowerXmlRangeindicatorprotoid Rangeindicatorprotoid { get; set; }

        [XmlElement(ElementName = "allowduringnorush")]
        public int Allowduringnorush { get; set; }

        [XmlElement(ElementName = "showtimer")]
        public string Showtimer { get; set; }

        [XmlElement(ElementName = "cooldowntime")]
        public int Cooldowntime { get; set; }

        [XmlElement(ElementName = "cooldownstackingclass")]
        public int Cooldownstackingclass { get; set; }

        [XmlElement(ElementName = "startsoundset")]
        public string Startsoundset { get; set; }

        [XmlElement(ElementName = "endsoundset")]
        public string Endsoundset { get; set; }

        [XmlElement(ElementName = "killunitsonshutdown")]
        public string Killunitsonshutdown { get; set; }

        [XmlElement(ElementName = "requiredage")]
        public int Requiredage { get; set; }

        [XmlElement(ElementName = "untargeted")]
        public int Untargeted { get; set; }

        [XmlElement(ElementName = "placementprotounitid")]
        public string Placementprotounitid { get; set; }

        [XmlElement(ElementName = "unitmodify")]
        public List<PowerXmlUnitmodify> Unitmodify { get; set; }

        [XmlElement(ElementName = "powerplayerrelation")]
        public string Powerplayerrelation { get; set; }

        [XmlElement(ElementName = "radius")]
        public double Radius { get; set; }

        [XmlElement(ElementName = "abstractattacktargettype")]
        public List<string> Abstractattacktargettype { get; set; }

        [XmlElement(ElementName = "expandcheckplacementhull")]
        public string Expandcheckplacementhull { get; set; }

        [XmlElement(ElementName = "cost")]
        public PowerXmlCost Cost { get; set; }

        [XmlElement(ElementName = "tech")]
        public string Tech { get; set; }

        [XmlElement(ElementName = "attachmodel")]
        public string Attachmodel { get; set; }

        [XmlElement(ElementName = "showinpartyinterface")]
        public string Showinpartyinterface { get; set; }

        [XmlElement(ElementName = "unitaction")]
        public string Unitaction { get; set; }

        [XmlElement(ElementName = "toggle")]
        public string Toggle { get; set; }

        [XmlElement(ElementName = "stacks")]
        public string Stacks { get; set; }

        [XmlElement(ElementName = "resource")]
        public int Resource { get; set; }
    }

    [JsonObject(Title = "powers", Description = "")]
    [XmlRoot(ElementName = "powers")]
    public class PowersXml : DictionaryContainer<string, PowerXml, IPower>, IPowersXml
    {
        public PowersXml() : base(key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [JsonConstructor]
        public PowersXml(
            [JsonProperty(PropertyName = "power", Required = Required.Always)] IEnumerable<PowerXml> power) : base(
            power, key => key.Name, StringComparer.OrdinalIgnoreCase)
        {
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonProperty(PropertyName = "power", Required = Required.Always)]
        [XmlElement(ElementName = "power")]
        public PowerXml[] PowerArray
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
                        excs.Add(new Exception($"Item '{item.Name}'", e));
                    }
                if (excs.Count > 0)
                    throw new AggregateException(excs);
            }
        }

        public void SaveToXmlFile(string file)
        {
            this.SerializeToXmlFile(file);
        }

        public static IPowersXml FromXmlFile(string file)
        {
            return XmlUtils.DeserializeFromFile<PowersXml>(file);
        }
    }
}