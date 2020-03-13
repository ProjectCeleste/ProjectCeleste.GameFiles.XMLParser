
using System;
using System.Collections.Generic;

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IDictionaryContainer<in TKey, TValue> : IReadOnlyContainer<TKey, TValue>
    {
        bool Add(TValue value);
        void Add(IEnumerable<TValue> values);
        void Clear();
        bool Remove(TKey key);
        bool Update(TValue value);
        event EventHandler<TValue> OnAdd;
        event EventHandler<TValue> OnRemoved;
        event EventHandler<TValue> OnUpdated;
    }
}