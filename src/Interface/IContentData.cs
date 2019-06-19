﻿#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IContentData
    {
        IDictionaryContainer<string, ContentDataXmlContent> Content { get; }
        IDictionaryContainer<string, ContentDataXmlCurrencycontent> CurrencyContent { get; }
    }

    public interface IContentDataReadOnly
    {
        IReadOnlyContainer<string, ContentDataXmlContent> Content { get; }
        IReadOnlyContainer<string, ContentDataXmlCurrencycontent> CurrencyContent { get; }
    }
}