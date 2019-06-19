﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface ICraftSchools : IDictionaryContainer<CraftSchoolEnum, CraftSchoolXml>
    {
    }

    public interface ICraftSchoolsReadOnly : IReadOnlyContainer<CraftSchoolEnum, CraftSchoolXml>
    {
    }
}