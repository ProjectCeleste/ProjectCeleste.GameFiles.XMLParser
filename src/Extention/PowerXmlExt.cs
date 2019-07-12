#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class PowerXmlExt
    {
        public static string GetDisplayNameLocalized(this PowerXml item, ILanguagesReadOnly languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.Displaynameid].Text;
        }

        public static string GetRollOverTextLocalized(this PowerXml item, ILanguagesReadOnly languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.Rolloverid].Text;
        }
    }
}