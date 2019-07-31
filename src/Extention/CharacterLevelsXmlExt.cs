#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class CharacterLevelsXmlExt
    {
        public static int GetLevelMaxXp(this ICharacterLevels characterLevelsXml, int currentLevel)
        {
            return currentLevel >= characterLevelsXml.MaxLevel
                ? characterLevelsXml[characterLevelsXml.MaxLevel].Xp
                : characterLevelsXml[currentLevel + 1].Xp;
        }
    }
}