
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
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