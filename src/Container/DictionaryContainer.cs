#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container
{
    public class DictionaryContainer<TKey, TValue> : IDictionaryContainer<TKey, TValue>
    {
        [XmlIgnore] [JsonIgnore] private readonly Func<TValue, TKey> _keySelector;
        [XmlIgnore] [JsonIgnore] private readonly IDictionary<TKey, TValue> _valuesDic;

        public DictionaryContainer(Func<TValue, TKey> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<TKey, TValue>();
        }

        public DictionaryContainer(IDictionary<TKey, TValue> values, Func<TValue, TKey> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<TKey, TValue>(values);
        }

        public DictionaryContainer(Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<TKey, TValue>(comparer);
        }

        public DictionaryContainer(IDictionary<TKey, TValue> values, Func<TValue, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<TKey, TValue>(values, comparer);
        }

        public DictionaryContainer(IEnumerable<TValue> values, Func<TValue, TKey> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = values.ToDictionary(keySelector);
        }

        public DictionaryContainer(IEnumerable<TValue> values, Func<TValue, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = values.ToDictionary(keySelector, comparer);
        }

        public bool ContainsKey(TKey key)
        {
            return _valuesDic.ContainsKey(key);
        }

        public event EventHandler<TValue> OnAdd;

        public bool Add(TValue value)
        {
            var key = _keySelector(value);

            _valuesDic.Add(key, value);

            OnAdd?.Invoke(this, value);

            return true;
        }

        public event EventHandler<TValue> OnRemoved;

        public bool Remove(TKey key)
        {
            if (!_valuesDic.TryGetValue(key, out TValue value))
                return false;

            if (!_valuesDic.Remove(key))
                return false;

            OnRemoved?.Invoke(this, value);

            return true;
        }

        public event EventHandler<TValue> OnUpdated;

        public bool Update(TValue value)
        {
            var keyResult = _keySelector(value);

            if (!_valuesDic.TryGetValue(keyResult, out TValue item))
                throw new KeyNotFoundException($"KeyNotFoundException '{keyResult}'");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            //if (string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
            //    JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
            //    return false;

            _valuesDic[keyResult] = value;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        [XmlIgnore]
        [JsonIgnore]
        public TValue this[TKey key] => _valuesDic.TryGetValue(key, out TValue value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _valuesDic.Count;

        public TValue Get(TKey key)
        {
            return _valuesDic.TryGetValue(key, out TValue value)
                ? value
                : default(TValue);
        }

        public TValue Get(Func<TValue, bool> critera)
        {
            return Gets().FirstOrDefault(critera);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return _valuesDic.TryGetValue(key, out value);
        }

        public IEnumerable<TValue> Gets(Func<TValue, bool> critera)
        {
            return Gets().Where(critera);
        }

        public IEnumerable<TValue> Gets()
        {
            return _valuesDic.ToArray().Select(p => p.Value);
        }

        public void Clear()
        {
            _valuesDic.Clear();
        }
    }
}