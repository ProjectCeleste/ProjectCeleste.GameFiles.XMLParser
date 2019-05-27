#region Using directives

using System;
using System.Linq;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconBlueprintXmlExt
    {
        public static string GetDisplayNameLocalized(this EconBlueprintXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["econstrings"].Language[language]
                .LanguageString[item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconBlueprintXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["econstrings"].Language[language]
                .LanguageString[item.RollOverTextId].Text;
        }

        public static void Verify(this EconBlueprintsXml item, EconMaterialsXml econMaterials)
        {
            var list = (from bp in item.Gets(key => key.Cost?.Material != null)
                from material in bp.Cost.Material.Gets()
                where econMaterials.Get(material.Id) == null
                select new Exception($"[BluePrint: {bp.Name}] Material {material.Id} don't exist.")).ToArray();

            if (list.Length > 0)
                throw new AggregateException(list);
        }
    }
}