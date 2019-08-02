#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class PowerExt
    {
        public static string GetDisplayNameLocalized(this IPower item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.Displaynameid].Text;
        }

        public static string GetRollOverTextLocalized(this IPower item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.Rolloverid].Text;
        }
    }
}