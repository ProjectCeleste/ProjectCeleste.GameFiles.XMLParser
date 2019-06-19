#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconDesigns : IDictionaryContainer<string, EconDesignXml>
    {
    }

    public interface IEconDesignsReadOnly : IDictionaryContainer<string, EconDesignXml>
    {
    }
}