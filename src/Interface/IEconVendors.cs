#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconVendorsXml : IDictionaryContainer<string, EconVendorXml>
    {
    }

    public interface IEconVendors : IDictionaryContainer<string, IEconVendor>
    {
    }

    public interface IEconVendorsReadOnly : IReadOnlyContainer<string, IEconVendorReadOnly>
    {
    }

    public interface IEconVendor
    {
        IEconVendorItemsets Itemsets { get; }
        string Name { get; set; }
        string Protounit { get; set; }
    }

    public interface IEconVendorReadOnly
    {
        IEconVendorItemsetsReadOnly Itemsets { get; }
        string Name { get; }
        string Protounit { get; }
    }

    public interface IEconVendorItemsets
    {
        EconVendorXmlItemset Itemset { get; }
    }

    public interface IEconVendorItemsetsReadOnly
    {
        EconVendorXmlItemset Itemset { get; }
    }
}