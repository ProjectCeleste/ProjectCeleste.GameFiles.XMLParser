#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container
{
    public class ReadOnlyContainer<T1, T2> : IReadOnlyContainer<T1, T2>
    {
        [XmlIgnore] [JsonIgnore] private readonly IReadOnlyDictionary<T1, T2> _values;

        public ReadOnlyContainer(IDictionary<T1, T2> values)
        {
            _values = new ReadOnlyDictionary<T1, T2>(new Dictionary<T1, T2>(values));
        }

        public ReadOnlyContainer(IDictionary<T1, T2> values, IEqualityComparer<T1> comparer)
        {
            _values = new ReadOnlyDictionary<T1, T2>(new Dictionary<T1, T2>(values, comparer));
        }

        public ReadOnlyContainer(IEnumerable<T2> values, Func<T2, T1> keySelector)
        {
            _values = new ReadOnlyDictionary<T1, T2>(values.ToDictionary(keySelector));
        }

        public ReadOnlyContainer(IEnumerable<T2> values, Func<T2, T1> keySelector, IEqualityComparer<T1> comparer)
        {
            _values = new ReadOnlyDictionary<T1, T2>(values.ToDictionary(keySelector, comparer));
        }

        [XmlIgnore]
        [JsonIgnore]
        public T2 this[T1 key] => _values.TryGetValue(key, out T2 value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _values.Count;

        public bool ContainsKey(T1 key)
        {
            return _values.ContainsKey(key);
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            return _values.Contains(item);
        }

        public T2 Get(T1 key)
        {
            return _values.TryGetValue(key, out T2 value)
                ? value
                : default(T2);
        }

        public T2 Get(Func<T2, bool> critera)
        {
            return Gets().FirstOrDefault(critera);
        }

        public bool TryGet(T1 key, out T2 value)
        {
            return _values.TryGetValue(key, out value);
        }

        public IEnumerable<T2> Gets(Func<T2, bool> critera)
        {
            return Gets().Where(critera);
        }

        public IEnumerable<T2> Gets()
        {
            return _values.ToArray().Select(p => p.Value);
        }
    }
}