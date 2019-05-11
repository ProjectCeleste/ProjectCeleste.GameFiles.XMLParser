namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconLootRollXmlExt
    {
        public static string GetDisplayNameLocalized(this EconLootRollXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconLootRollXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.RollOverTextId].Text;
        }
    }
}