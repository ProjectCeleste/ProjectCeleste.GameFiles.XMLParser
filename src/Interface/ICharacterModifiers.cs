#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICharacterModifiers
    {
        CharacterModifiersModifiersXml Modifiers { get; }
        CharacterModifierXmlModifierTypeData ModifierTypeData { get; }
    }
}