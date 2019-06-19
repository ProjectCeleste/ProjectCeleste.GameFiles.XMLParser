#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IDictionaryContainer<T1, T2> //: IReadOnlyContainer<T1, T2>
    {
        // IReadOnlyContainer<T1, T2>
        T2 this[T1 key] { get; }
        int Count { get; }
        bool ContainsKey(T1 key);
        T2 Get(Func<T2, bool> critera);
        T2 Get(T1 key);
        IEnumerable<T2> Gets();
        IEnumerable<T2> Gets(Func<T2, bool> critera);
        bool TryGet(T1 key, out T2 value);
        //
        bool Add(T2 value);
        void Clear();
        bool Remove(T1 key);
        bool Update(T2 value);
    }
    
    public interface IDictionaryContainerWithEvent<T1, T2> : IDictionaryContainer<T1, T2>
    {
        event EventHandler<T2> OnAdd;
        event EventHandler<T2> OnRemoved;
        event EventHandler<T2> OnUpdated;
    }
}