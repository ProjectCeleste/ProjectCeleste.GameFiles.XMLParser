#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IContentDataCurrencyContent : IContentDataContent
    {
        ContentDataXmlCost Cost { get; }
        int Quantity { get; }
    }

    public interface IContentDataContent
    {
        string Allowingameonly { get; }
        string Contentid { get; }
        ContentDataXmlDialog Dialog { get; }
        string Helpdisplayname { get; }
        string Name { get; }
        string Offerid { get; }
        ContentDataXmlOffertypes Offertypes { get; }
    }

    public interface IContentData
    {
        IDictionaryContainer<string, IContentDataContent> Content { get; }
        IDictionaryContainer<string, IContentDataCurrencyContent> CurrencyContent { get; }
    }

    public interface IContentDataXml : IContentData
    {
        void SaveToXmlFile(string file);
    }
}