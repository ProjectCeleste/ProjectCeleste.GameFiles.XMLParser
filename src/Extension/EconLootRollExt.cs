
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class EconLootRollExt
    {
        public static string GetDisplayNameLocalized(this IEconLootRoll item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this IEconLootRoll item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}