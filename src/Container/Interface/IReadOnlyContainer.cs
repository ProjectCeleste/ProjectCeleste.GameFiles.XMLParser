
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace ProjectCeleste.GameFiles.XMLParser.Container.Interface
{
    public interface IReadOnlyContainer<in TKey, out TValue>
    {
        [NotNull] TValue this[[NotNull] TKey key] { get; }
        [Range(0, int.MaxValue)] int Count { get; }
        bool ContainsKey([NotNull] TKey key);
        [CanBeNull] TValue Get([NotNull] Func<TValue, bool> criteria);
        [CanBeNull] TValue Get([NotNull] TKey key);
        [NotNull] [ItemNotNull] IEnumerable<TValue> Gets();
        [NotNull] [ItemNotNull] IEnumerable<TValue> Gets(Func<TValue, bool> criteria);
    }
}