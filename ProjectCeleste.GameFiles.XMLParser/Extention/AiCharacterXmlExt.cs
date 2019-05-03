#region Using directives

using System;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class AiCharacterXmlExt
    {
        public static bool AddOrUpdate(this AiCharacterXmlTechs techs, string techId, TechStatusEnum techStatut)
        {
            if (string.IsNullOrWhiteSpace(techId))
                throw new ArgumentNullException(nameof(techId));

            if (techStatut == TechStatusEnum.Invalid)
                throw new ArgumentOutOfRangeException(nameof(techStatut), techStatut, string.Empty);

            if (techs.Tech.TryGetValue(techId, out AiCharacterXmlTechsTech tech))
            {
                tech.Status = techStatut;
                tech.PersistentCityStatus = techStatut;

                return true;
            }

            var newTech = new AiCharacterXmlTechsTech
            {
                TechId = techId,
                Status = techStatut,
                PersistentCityStatus = techStatut
            };

            techs.Tech.Add(newTech.TechId, newTech);

            return true;
        }
    }
}