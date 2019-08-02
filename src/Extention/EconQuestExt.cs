#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconQuestExt
    {
        public static string GetDisplayNameLocalized(this IEconQuest item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this IEconQuest item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}