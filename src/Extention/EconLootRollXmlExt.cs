namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconLootRollXmlExt
    {
        public static string GetDisplayNameLocalized(this EconLootRollXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconLootRollXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"][language][item.RollOverTextId].Text;
        }
    }
}