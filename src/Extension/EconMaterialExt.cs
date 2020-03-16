
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class EconMaterialExt
    {
        public static string GetDisplayNameLocalized(this IEconMaterial item, ILanguages languages,
            string language = "English")
        {
            return languages["econstrings"][language].ContainsKey(item.DisplayNameId)
                ? languages["econstrings"][language][item.DisplayNameId].Text
                : languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this IEconMaterial item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}