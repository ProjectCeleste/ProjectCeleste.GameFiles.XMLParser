namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class PowerXmlExt
    {
        public static string GetDisplayNameLocalized(this PowerXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.Displaynameid].Text;
        }

        public static string GetRollOverTextLocalized(this PowerXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.Rolloverid].Text;
        }
    }
}