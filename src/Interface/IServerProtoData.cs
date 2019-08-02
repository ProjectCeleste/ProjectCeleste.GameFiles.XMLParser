#region Using directives

using ProjectCeleste.GameFiles.XMLParser.Container.Interface;
using ProjectCeleste.GameFiles.XMLParser.Enum;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Interface
{
    public interface IServerProtoUnit
    {
        BuildingLimitTypeEnum BuildingLimitType { get; }
        bool IsMainInventory { get; }
        int MaxStackSize { get; }
        string Name { get; }
        int NumInventorySlots { get; }
    }

    public interface IServerProtoData : IDictionaryContainer<string, IServerProtoUnit>
    {
    }

    public interface IServerProtoDataXml : IServerProtoData
    {
        void SaveToXmlFile(string file);
    }
}