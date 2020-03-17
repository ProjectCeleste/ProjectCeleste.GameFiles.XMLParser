
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

namespace ProjectCeleste.GameFiles.XMLParser.Container
{
    public class DictionaryContainer<TKey, TValue, TInterface> : IDictionaryContainer<TKey, TInterface>
        where TValue : class, TInterface
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

        [XmlIgnore]
        [JsonIgnore]
        public TValue this[TKey key] => _valuesDic.TryGetValue(key, out var value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        public bool ContainsKey(TKey key)
        {
            return _valuesDic.ContainsKey(key);
        }

        public event EventHandler<TInterface> OnAdd;

        public event EventHandler<TInterface> OnRemoved;

        public bool Remove(TKey key)
        {
            if (!_valuesDic.TryGetValue(key, out var value))
                return false;

            if (!_valuesDic.Remove(key))
                return false;

            OnRemoved?.Invoke(this, value);

            return true;
        }

        public event EventHandler<TInterface> OnUpdated;

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _valuesDic.Count;

        public void Clear()
        {
            _valuesDic.Clear();
        }

        bool IDictionaryContainer<TKey, TInterface>.Add(TInterface value)
        {
            if (!(value is TValue item))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            return Add(item);
        }

        void IDictionaryContainer<TKey, TInterface>.Add(IEnumerable<TInterface> value)
        {
            Add(value.Cast<TValue>());
        }

        bool IDictionaryContainer<TKey, TInterface>.Update(TInterface value)
        {
            if (!(value is TValue value2))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            return Update(value2);
        }

        [XmlIgnore]
        [JsonIgnore]
        TInterface IReadOnlyContainer<TKey, TInterface>.this[TKey key] => this[key];

        TInterface IReadOnlyContainer<TKey, TInterface>.Get(Func<TInterface, bool> critera)
        {
            return Get(critera);
        }

        TInterface IReadOnlyContainer<TKey, TInterface>.Get(TKey key)
        {
            return Get(key);
        }

        IEnumerable<TInterface> IReadOnlyContainer<TKey, TInterface>.Gets()
        {
            return Gets();
        }

        IEnumerable<TInterface> IReadOnlyContainer<TKey, TInterface>.Gets(Func<TInterface, bool> critera)
        {
            return Gets(critera);
        }

        //bool IReadOnlyContainer<TKey, TInterface>.TryGet(TKey key, out TInterface value)
        //{
        //    if (!TryGet(key, out var item))
        //    {
        //        value = default(TValue);
        //        return false;
        //    }
        //    value = item;
        //    return true;
        //}

        public bool Add(TValue value)
        {
            var key = _keySelector(value);

            try
            {
                _valuesDic.Add(key, value);
            }
            catch (Exception)
            {
                return false;
            }

            OnAdd?.Invoke(this, value);

            return true;
        }

        public void Add(IEnumerable<TValue> values)
        {
            if (values == null)
                return;

            var excs = new List<Exception>();
            foreach (var value in values)
                try
                {
                    if (!Add(value))
                        throw new Exception($"Add item '{_keySelector(value)}' failed");
                }
                catch (Exception e)
                {
                    excs.Add(e);
                }

            if (excs.Count > 0)
                throw new AggregateException(excs);
        }

        public bool Update(TValue value)
        {
            var keyResult = _keySelector(value);

            if (!_valuesDic.TryGetValue(keyResult, out var item))
                throw new KeyNotFoundException($"KeyNotFoundException '{keyResult}'");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            if (string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
                JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
                return false;

            _valuesDic[keyResult] = value;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        public TValue Get(TKey key)
        {
            return _valuesDic.TryGetValue(key, out var value)
                ? value
                : default;
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
    }

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

        public bool Add(TValue value)
        {
            var key = _keySelector(value);

            try
            {
                _valuesDic.Add(key, value);
            }
            catch (Exception)
            {
                return false;
            }

            OnAdd?.Invoke(this, value);

            return true;
        }

        public void Add(IEnumerable<TValue> values)
        {
            if (values == null)
                return;

            var excs = new List<Exception>();
            foreach (var value in values)
                try
                {
                    if (!Add(value))
                        throw new Exception($"Add item '{_keySelector(value)}' failed");
                }
                catch (Exception e)
                {
                    excs.Add(e);
                }

            if (excs.Count > 0)
                throw new AggregateException(excs);
        }

        public bool Remove(TKey key)
        {
            if (!_valuesDic.TryGetValue(key, out var value))
                return false;

            if (!_valuesDic.Remove(key))
                return false;

            OnRemoved?.Invoke(this, value);

            return true;
        }

        public bool Update(TValue value)
        {
            var keyResult = _keySelector(value);

            if (!_valuesDic.TryGetValue(keyResult, out var item))
                throw new KeyNotFoundException($"Key '{keyResult}' not found");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            if (string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
                JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
                return false;

            _valuesDic[keyResult] = value;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        [XmlIgnore]
        [JsonIgnore]
        public TValue this[TKey key] => _valuesDic.TryGetValue(key, out var value)
            ? value
            : throw new KeyNotFoundException($"Key '{key}' not found");

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _valuesDic.Count;

        public TValue Get(TKey key)
        {
            return _valuesDic.TryGetValue(key, out var value)
                ? value
                : default;
        }

        public TValue Get(Func<TValue, bool> criteria)
        {
            return Gets().FirstOrDefault(criteria);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return _valuesDic.TryGetValue(key, out value);
        }

        public IEnumerable<TValue> Gets(Func<TValue, bool> criteria)
        {
            return Gets().Where(criteria);
        }

        public IEnumerable<TValue> Gets()
        {
            return _valuesDic.Select(p => p.Value);
        }

        public void Clear()
        {
            _valuesDic.Clear();
        }

        public event EventHandler<TValue> OnAdd;

        public event EventHandler<TValue> OnRemoved;

        public event EventHandler<TValue> OnUpdated;
    }
}