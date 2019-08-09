#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IBonusEventDataXml : IBonusEventData
    {
        void SaveToXmlFile(string file);
    }

    public interface IBonusEventData
    {
        BonusEventDataXmlBonusEvents BonusEvents { get; set; }
        BonusEventDataXmlCategoryWeights CategoryWeights { get; set; }
    }
}