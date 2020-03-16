
using ProjectCeleste.GameFiles.XMLParser.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Extension
{
    public static class ProtoAge4Ext
    {
        public static string GetDisplayNameLocalized(this IProtoAge4Unit item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"]["English"][item.DisplayNameId].Text;
        }

        public static string GetRolloverTextLocalized(this IProtoAge4Unit item, ILanguages languages,
            string language = "English")
        {
            return languages["stringtablex"]["English"][item.RolloverTextId].Text;
        }
    }
}