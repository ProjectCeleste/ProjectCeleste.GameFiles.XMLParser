#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container
{
    public class ReadOnlyContainer<TKey, TValue> : IReadOnlyContainer<TKey, TValue>
    {
        [XmlIgnore] [JsonIgnore] private readonly IReadOnlyDictionary<TKey, TValue> _values;

        public ReadOnlyContainer(IDictionary<TKey, TValue> values)
        {
            _values = new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>(values));
        }

        public ReadOnlyContainer(IDictionary<TKey, TValue> values, IEqualityComparer<TKey> comparer)
        {
            _values = new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>(values, comparer));
        }

        public ReadOnlyContainer(IEnumerable<TValue> values, Func<TValue, TKey> keySelector)
        {
            _values = new ReadOnlyDictionary<TKey, TValue>(values.ToDictionary(keySelector));
        }

        public ReadOnlyContainer(IEnumerable<TValue> values, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _values = new ReadOnlyDictionary<TKey, TValue>(values.ToDictionary(keySelector, comparer));
        }

        [XmlIgnore]
        [JsonIgnore]
        public TValue this[TKey key] => _values.TryGetValue(key, out TValue value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _values.Count;

        public bool ContainsKey(TKey key)
        {
            return _values.ContainsKey(key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _values.Contains(item);
        }

        public TValue Get(TKey key)
        {
            return _values.TryGetValue(key, out TValue value)
                ? value
                : default(TValue);
        }

        public TValue Get(Func<TValue, bool> critera)
        {
            return Gets().FirstOrDefault(critera);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return _values.TryGetValue(key, out value);
        }

        public IEnumerable<TValue> Gets(Func<TValue, bool> critera)
        {
            return Gets().Where(critera);
        }

        public IEnumerable<TValue> Gets()
        {
            return _values.ToArray().Select(p => p.Value);
        }
       
    }
}