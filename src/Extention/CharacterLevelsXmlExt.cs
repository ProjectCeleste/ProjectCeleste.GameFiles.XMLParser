namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class CharacterLevelsXmlExt
    {
        public static int GetLevelMaxXp(this CharacterLevelsXml characterLevelsXml, int currentLevel)
        {
            return currentLevel >= characterLevelsXml.MaxLevel
                ? characterLevelsXml[characterLevelsXml.MaxLevel].Xp
                : characterLevelsXml[currentLevel + 1].Xp;
        }
    }
}