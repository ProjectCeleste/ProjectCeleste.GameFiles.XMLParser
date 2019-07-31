#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconAdvisorXmlExt
    {
        public static string GetDisplayNameLocalized(this EconAdvisorXml item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetDisplayDescriptionLocalized(this EconAdvisorXml item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayDescriptionId].Text;
        }
    }
}