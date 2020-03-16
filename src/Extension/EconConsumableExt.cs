
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class EconConsumableExt
    {
        public static string GetDisplayNameLocalized(this IEconConsumable item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this IEconConsumable item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}