using System;
using System.Collections.Generic;

namespace ProjectCeleste.GamesFiles.XMLParser.Container.Interface
{
    public interface IReadOnlyContainer<T1, T2>
    {
        T2 this[T1 key] { get; }
        int Count { get; }
        bool ContainsKey(T1 key);
        T2 Get(Func<T2, bool> critera);
        T2 Get(T1 key);
        IEnumerable<T2> Gets();
        IEnumerable<T2> Gets(Func<T2, bool> critera);
        bool TryGet(T1 key, out T2 value);
    }
}