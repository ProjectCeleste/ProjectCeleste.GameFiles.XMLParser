#region Using directives

using System;
using System.Linq;
using ProjectCeleste.GameFiles.XMLParser.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconBlueprintXmlExt
    {
        public static string GetDisplayNameLocalized(this EconBlueprintXml item, ILanguages languages,
            string language = "English")
        {
            return languages["econstrings"][language][item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconBlueprintXml item, ILanguages languages,
            string language = "English")
        {
            return languages["econstrings"][language][item.RollOverTextId].Text;
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