#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class EconDesignXmlExt
    {
        public static string GetDisplayNameLocalized(this EconDesignXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["econstrings"].Language[language]
                .LanguageString[item.DisplayNameId].Text;
        }

        public static string GetRollOverTextLocalized(this EconDesignXml item, LanguagesXml languages,
            string language = "English")
        {
            return languages["stringtablex"].Language[language]
                .LanguageString[item.RollOverTextId].Text;
        }

        public static void Verify(this EconDesignsXml item, EconMaterialsXml econMaterials,
            EconConsumablesXml econConsumables, EconTraitsXml econTraits, EconAdvisorsXml econAdvisors,
            EconBlueprintsXml econBlueprints)
        {
            var list = new List<Exception>();
            foreach (var design in item.Gets())
            {
                if (design.Output != null)
                    if (design.Output.Consumable != null)
                    {
                        if (econConsumables.Get(design.Output.Consumable.Id) == null)
                            list.Add(new Exception(
                                $"{design.Name}, Output Consumable {design.Output.Consumable.Id} don't exist."));
                    }
                    else if (design.Output.Material != null)
                    {
                        if (econMaterials.Get(design.Output.Material.Id) == null)
                            list.Add(new Exception(
                                $"{design.Name}, Output Material {design.Output.Material.Id} don't exist."));
                    }
                    else if (design.Output.Trait != null)
                    {
                        if (econTraits.Get(design.Output.Trait.Id) == null)
                            list.Add(new Exception(
                                $"{design.Name}, Output Trait {design.Output.Trait.Id} don't exist."));
                    }
                    else if (design.Output.Advisor != null)
                    {
                        if (econAdvisors.Get(design.Output.Advisor.Id) == null)
                            list.Add(new Exception(
                                $"{design.Name}, Output Advisor {design.Output.Advisor.Id} don't exist."));
                    }
                    else if (design.Output.Blueprint != null)
                    {
                        if (econBlueprints.Get(design.Output.Blueprint.Id) == null)
                            list.Add(new Exception(
                                $"{design.Name}, Output Trait {design.Output.Blueprint.Id} don't exist."));
                    }
                    else
                    {
                        list.Add(new Exception($"{design.Name}, Output is unknow or empty."));
                    }
                else
                    list.Add(new Exception($"{design.Name}, Output is null."));

                if (design.Input?.Material != null)
                    list.AddRange(from material in design.Input.Material.Gets()
                        where econMaterials.Get(material.Id) == null
                        select new Exception($"Design: {design.Name}, Input Material {material.Id} don't exist."));
            }

            if (list.Count > 0)
                throw new AggregateException(list);
        }
    }
}