#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconAdvisors : IDictionaryContainer<string, EconAdvisorXml>
    {
    }

    public interface IEconAdvisorsReadOnly : IReadOnlyContainer<string, EconAdvisorXml>
    {
    }
}