#region Using directives

using System.Collections.Generic;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICivilization
    {
        List<CivilizationXmlAgetech> Agetech { get; }
        string Alliedid { get; }
        string Alliedotherid { get; }
        CivilizationXmlAllowedcharactertypes Allowedcharactertypes { get; }
        string Buildingefficiency { get; }
        string Capitolbldgunittype { get; }
        CivilizationEnum Civid { get; }
        ECivilizationEnum Civmatchingid { get; }
        int Contentpack { get; }
        string Courierprotoname { get; }
        string Culture { get; }
        string Displaynameid { get; }
        CivilizationXmlIgnorecommandbutton Ignorecommandbutton { get; }
        string Introvideo { get; }
        string Levelupsound { get; }
        string Main { get; }
        string Mapx { get; }
        string Mapy { get; }
        string Name { get; }
        string Namestringid { get; }
        string Objectivecompletesound { get; }
        COfferTypeEnum Offertype { get; }
        string Persistentcity { get; }
        string Portrait { get; }
        string Postimperialtech { get; }
        string Postindustrialtech { get; }
        string Rollovernameid { get; }
        CivilizationXmlStartingcities Startingcities { get; }
        CivilizationXmlStartingresources Startingresources { get; }
        string Statsid { get; }
        string Towncenter { get; }
        List<string> Townstartingunit { get; }
        CivilizationXmlUi Ui { get; }
        string Unalliedid { get; }
        CivilizationXmlUnitregen Unitregen { get; }
        List<CivilizationXmlWall> Wall { get; }
    }

    public interface ICivilizations : IDictionaryContainer<CivilizationEnum, ICivilization>
    {
    }

    public interface ICivilizationsXml : ICivilizations
    {
        void SaveToXmlFile(CivilizationEnum id, string file);
    }
}