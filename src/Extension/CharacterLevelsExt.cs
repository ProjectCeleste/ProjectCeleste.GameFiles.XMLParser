
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class CharacterLevelsExt
    {
        public static int GetLevelMaxXp(this ICharacterLevels characterLevelsXml, int currentLevel)
        {
            return currentLevel >= characterLevelsXml.MaxLevel
                ? characterLevelsXml[characterLevelsXml.MaxLevel].Xp
                : characterLevelsXml[currentLevel + 1].Xp;
        }
    }
}