#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum.CharacterModifier;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICharacterModifiers : IDictionaryContainer<string, CharacterModifierXml>
    {
    }

    public interface ICharacterModifierTypeData : IDictionaryContainer<CharacterModifierTypeEnum,
        CharacterModifierXmlModifierType>
    {
    }

    public interface ICharacterModifiersData
    {
        ICharacterModifiers Modifiers { get; }
        ICharacterModifierTypeData ModifierTypeData { get; }
    }

    public interface ICharacterModifiersDataXml : ICharacterModifiersData
    {
    }
}