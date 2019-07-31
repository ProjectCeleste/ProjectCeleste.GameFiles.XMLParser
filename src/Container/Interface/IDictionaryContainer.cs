#region Using directives

using System;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IDictionaryContainer<in T1, T2> : IReadOnlyContainer<T1, T2>
    {
        bool Add(T2 value);
        void Clear();
        bool Remove(T1 key);
        bool Update(T2 value);
    }

    public interface IDictionaryContainerWithEvent<in T1, T2> : IDictionaryContainer<T1, T2>
    {
        event EventHandler<T2> OnAdd;
        event EventHandler<T2> OnRemoved;
        event EventHandler<T2> OnUpdated;
    }
}