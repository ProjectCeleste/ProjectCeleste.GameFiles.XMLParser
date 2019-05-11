using System;

namespace ProjectCeleste.GamesFiles.XMLParser.Container.Interface
{
    public interface IDictionaryContainer<T1, T2> : IReadOnlyContainer<T1, T2>
    {
        bool Add(T2 value);
        event EventHandler<T2> OnAdd;
        void Clear();
        bool Remove(T1 key);
        event EventHandler<T2> OnRemoved;
        bool Update(T2 value);
        event EventHandler<T2> OnUpdated;
    }
}