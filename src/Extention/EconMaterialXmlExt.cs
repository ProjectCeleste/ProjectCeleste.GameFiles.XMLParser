#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconMaterialXmlExt
    {
        public static string GetDisplayNameLocalized(this EconMaterialXml item, ILanguages languages,
            string language = "English")
        {
            return languages["econstrings"][language].ContainsKey(item.DisplayNameId)
                ? languages["econstrings"][language][item.DisplayNameId].Text
                : languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconMaterialXml item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}