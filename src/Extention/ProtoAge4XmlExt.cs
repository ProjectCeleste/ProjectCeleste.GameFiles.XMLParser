#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class ProtoAge4XmlExt
    {
        public static string GetDisplayNameLocalized(this ProtoAge4XmlUnit item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"]["English"][item.DisplayNameId].Text;
        }

        public static string GetRolloverTextLocalized(this ProtoAge4XmlUnit item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"]["English"][item.RolloverTextId].Text;
        }
    }
}