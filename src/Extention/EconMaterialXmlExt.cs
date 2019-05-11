namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconMaterialXmlExt
    {
        public static string GetDisplayNameLocalized(this EconMaterialXml item, LanguagesXml languages,
            string language = "English")
        {
            if (languages["econstrings"].Language[language]
                .LanguageString.ContainsKey(item.DisplayNameId))
                return languages["econstrings"].Language[language]
                    .LanguageString[item.DisplayNameId].Text;

            return languages["stringtablex"].Language[language]
                .LanguageString[item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconMaterialXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.RollOverTextId].Text;
        }
    }
}