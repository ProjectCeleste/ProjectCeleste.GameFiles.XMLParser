﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IRandomMapSets : IDictionaryContainer<string, RandomMapSetXml>
    {
    }

    public interface IRandomMapSetsReadOnly : IReadOnlyContainer<string, RandomMapSetXml>
    {
    }
}