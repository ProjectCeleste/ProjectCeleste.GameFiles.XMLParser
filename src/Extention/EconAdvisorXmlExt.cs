namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconAdvisorXmlExt
    {
        public static string GetDisplayNameLocalized(this EconAdvisorXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.DisplayNameId].Text;
        }

        public static string GetDisplayDescriptionLocalized(this EconAdvisorXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.DisplayDescriptionId].Text;
        }
    }
}