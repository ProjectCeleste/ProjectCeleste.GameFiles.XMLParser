
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IDictionaryContainer<in TKey, TValue> : IReadOnlyContainer<TKey, TValue>
    {
        bool Add([NotNull] TValue value);
        void Add([NotNull] [ItemNotNull] IEnumerable<TValue> values);
        void Clear();
        bool Remove([NotNull] TKey key);
        //bool Update(TValue value);
        event EventHandler<TValue> OnAdd;
        event EventHandler<TValue> OnRemoved;
        event EventHandler<TValue> OnUpdated;
    }
}