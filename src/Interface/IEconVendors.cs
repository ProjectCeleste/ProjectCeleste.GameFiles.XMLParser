#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconVendors : IDictionaryContainer<string, IEconVendor>
    {
    }

    public interface IEconVendor
    {
        IEconVendorItemsets Itemsets { get; }
        string Name { get; }
        string Protounit { get; }
    }

    public interface IEconVendorItemsets
    {
        EconVendorXmlItemset Itemset { get; }
    }

    public interface IEconVendorsXml : IEconVendors
    {
        void SaveToXmlFile(string file);
    }
}