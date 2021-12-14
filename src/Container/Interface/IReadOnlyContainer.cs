
using System;
using System.Collections.Generic;

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IReadOnlyContainer<in TKey, out TValue>
    {
        TValue this[TKey key] { get; }
        int Count { get; }
        bool ContainsKey(TKey key);
        TValue Get(Func<TValue, bool> criteria);
        TValue Get(TKey key);
        IEnumerable<TValue> Gets();
        IEnumerable<TValue> Gets(Func<TValue, bool> criteria);
    }
}