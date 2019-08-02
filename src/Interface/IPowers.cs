#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IPower
    {
        List<string> Abstractattacktargettype { get; set; }
        int Activetime { get; set; }
        int Allowduringnorush { get; set; }
        string Attachmodel { get; set; }
        int Cooldownstackingclass { get; set; }
        int Cooldowntime { get; set; }
        PowerXmlCost Cost { get; set; }
        List<PowerXmlCreateunit> Createunit { get; set; }
        int Displaynameid { get; set; }
        string Endsoundset { get; set; }
        string Expandcheckplacementhull { get; set; }
        string Icon { get; set; }
        string Killunitsonshutdown { get; set; }
        PowerXmlMinimapeventtime Minimapeventtime { get; set; }
        string Name { get; set; }
        PowerXmlPlacement Placement { get; set; }
        string Placementprotounitid { get; set; }
        string Powerplayerrelation { get; set; }
        double Radius { get; set; }
        PowerXmlRangeindicatorprotoid Rangeindicatorprotoid { get; set; }
        int Requiredage { get; set; }
        int Resource { get; set; }
        int Rolloverid { get; set; }
        string Showinpartyinterface { get; set; }
        string Showtimer { get; set; }
        string Stacks { get; set; }
        string Startsoundset { get; set; }
        string Tech { get; set; }
        PowerXmlTempunitmodify Tempunitmodify { get; set; }
        string Toggle { get; set; }
        string Type { get; set; }
        string Unitaction { get; set; }
        List<PowerXmlUnitmodify> Unitmodify { get; set; }
        int Untargeted { get; set; }
    }

    public interface IPowers : IDictionaryContainer<string, IPower>
    {
    }

    public interface IPowersXml : IPowers
    {
        void SaveToXmlFile(string file);
    }
}