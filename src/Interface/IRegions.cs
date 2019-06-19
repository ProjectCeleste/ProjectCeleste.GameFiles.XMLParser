﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRegions : IDictionaryContainer<int, RegionXml>
    {
    }

    public interface IRegionsReadOnly : IReadOnlyContainer<int, RegionXml>
    {
    }
}