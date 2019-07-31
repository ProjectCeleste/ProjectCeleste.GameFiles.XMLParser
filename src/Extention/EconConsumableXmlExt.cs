#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconConsumableXmlExt
    {
        public static string GetDisplayNameLocalized(this EconConsumableXml item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconConsumableXml item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}