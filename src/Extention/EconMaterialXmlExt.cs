#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconMaterialXmlExt
    {
        public static string GetDisplayNameLocalized(this EconMaterialXml item, LanguagesXml languages,
            string language = "English")
        {
            if (languages["econstrings"][language].ContainsKey(item.DisplayNameId))
                return languages["econstrings"][language][item.DisplayNameId].Text;

            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconMaterialXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}