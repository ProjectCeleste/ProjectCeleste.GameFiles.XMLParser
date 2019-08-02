#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconAdvisorExt
    {
        public static string GetDisplayNameLocalized(this IEconAdvisor item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetDisplayDescriptionLocalized(this IEconAdvisor item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayDescriptionId].Text;
        }
    }
}