﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IPowers : IDictionaryContainer<string, PowerXml>
    {
    }

    public interface IPowersReadOnly : IReadOnlyContainer<string, PowerXml>
    {
    }
}