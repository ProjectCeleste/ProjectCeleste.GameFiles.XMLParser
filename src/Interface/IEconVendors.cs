#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Model;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IEconVendorsXml : IEconVendors
    {
    }

    public interface IEconVendors : IDictionaryContainerWithEvent<string, IEconVendor>
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
}