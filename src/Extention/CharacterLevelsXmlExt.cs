#region Using directives

using System;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class CharacterLevelsXmlExt
    {
        public static ICharacterLevelsReadOnly AsReadOnly(this ICharacterLevels characterLevelsXml)
        {
            return characterLevelsXml is ICharacterLevelsReadOnly item
                ? item
                : throw new NotSupportedException($"Value not implement '{typeof(ICharacterLevelsReadOnly)}'");
        }

        public static int GetLevelMaxXp(this ICharacterLevels characterLevelsXml, int currentLevel)
        {
            return currentLevel >= characterLevelsXml.MaxLevel
                ? characterLevelsXml[characterLevelsXml.MaxLevel].Xp
                : characterLevelsXml[currentLevel + 1].Xp;
        }

        public static int GetLevelMaxXp(this ICharacterLevelsReadOnly characterLevelsXml, int currentLevel)
        {
            return currentLevel >= characterLevelsXml.MaxLevel
                ? characterLevelsXml[characterLevelsXml.MaxLevel].Xp
                : characterLevelsXml[currentLevel + 1].Xp;
        }
    }
}