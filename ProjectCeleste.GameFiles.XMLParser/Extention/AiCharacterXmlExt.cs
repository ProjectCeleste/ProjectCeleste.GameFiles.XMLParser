#region Using directives

using System;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Extention
{
    public static class AiCharacterXmlExt
    {
        public static bool AddOrUpdate(this AiTechsXml techs, string techId, string techStatut)
        {
            if (string.IsNullOrWhiteSpace(techId))
                throw new ArgumentNullException(nameof(techId));

            if (string.IsNullOrWhiteSpace(techStatut))
                throw new ArgumentNullException(nameof(techStatut));

            if (techs.Tech.TryGetValue(techId, out AiTechXml tech))
            {
                tech.Status = techStatut;
                tech.PersistentCityStatus = techStatut;

                return true;
            }

            var newTech = new AiTechXml
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