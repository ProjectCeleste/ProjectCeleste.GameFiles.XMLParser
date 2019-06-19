﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GameFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GameFiles.XMLParser.Container
{
    public class DictionaryContainer<TKey, TValue, TInterface, TInterface2> :
        IDictionaryContainerWithEvent<TKey, TInterface>, IReadOnlyContainer<TKey, TInterface2>
        where TValue : class, TInterface where TInterface : TInterface2
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
        public TValue this[TKey key] => _valuesDic.TryGetValue(key, out TValue value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        public event EventHandler<TInterface> OnAdd;

        public event EventHandler<TInterface> OnRemoved;

        public bool Remove(TKey key)
        {
            if (!_valuesDic.TryGetValue(key, out TValue value))
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

        [XmlIgnore]
        [JsonIgnore]
        TInterface IDictionaryContainer<TKey, TInterface>.this[TKey key] => this[key];

        public void Clear()
        {
            _valuesDic.Clear();
        }

        bool IDictionaryContainer<TKey, TInterface>.Add(TInterface value)
        {
            if (!(value is TValue item))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            var key = _keySelector(item);

            _valuesDic.Add(key, item);

            OnAdd?.Invoke(this, item);

            return true;
        }

        bool IDictionaryContainer<TKey, TInterface>.Update(TInterface value)
        {
            if (!(value is TValue value2))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            var keyResult = _keySelector(value2);

            if (!_valuesDic.TryGetValue(keyResult, out TValue item))
                throw new KeyNotFoundException($"KeyNotFoundException '{keyResult}'");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            //if (string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
            //    JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
            //    return false;

            _valuesDic[keyResult] = value2;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        TInterface IDictionaryContainer<TKey, TInterface>.Get(Func<TInterface, bool> critera)
        {
            throw new NotImplementedException();
        }

        TInterface IDictionaryContainer<TKey, TInterface>.Get(TKey key)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TInterface> IDictionaryContainer<TKey, TInterface>.Gets()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TInterface> IDictionaryContainer<TKey, TInterface>.Gets(Func<TInterface, bool> critera)
        {
            throw new NotImplementedException();
        }

        bool IDictionaryContainer<TKey, TInterface>.TryGet(TKey key, out TInterface value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            return _valuesDic.ContainsKey(key);
        }

        [XmlIgnore]
        [JsonIgnore]
        TInterface2 IReadOnlyContainer<TKey, TInterface2>.this[TKey key] => this[key];

        TInterface2 IReadOnlyContainer<TKey, TInterface2>.Get(Func<TInterface2, bool> critera)
        {
            return Get(critera);
        }

        TInterface2 IReadOnlyContainer<TKey, TInterface2>.Get(TKey key)
        {
            return Get(key);
        }

        IEnumerable<TInterface2> IReadOnlyContainer<TKey, TInterface2>.Gets()
        {
            return Gets();
        }

        IEnumerable<TInterface2> IReadOnlyContainer<TKey, TInterface2>.Gets(Func<TInterface2, bool> critera)
        {
            return Gets(critera);
        }

        bool IReadOnlyContainer<TKey, TInterface2>.TryGet(TKey key, out TInterface2 value)
        {
            if (!TryGet(key, out TValue item))
            {
                value = default(TValue);
                return false;
            }
            value = item;
            return true;
        }

        public bool Add(TValue value)
        {
            var key = _keySelector(value);

            _valuesDic.Add(key, value);

            OnAdd?.Invoke(this, value);

            return true;
        }

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
    }

    public class DictionaryContainer<TKey, TValue, TInterface> : IDictionaryContainerWithEvent<TKey, TInterface>,
        IReadOnlyContainer<TKey, TInterface>
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
        public TValue this[TKey key] => _valuesDic.TryGetValue(key, out TValue value)
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
            if (!_valuesDic.TryGetValue(key, out TValue value))
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

        [XmlIgnore]
        [JsonIgnore]
        TInterface IDictionaryContainer<TKey, TInterface>.this[TKey key] => this[key];

        public void Clear()
        {
            _valuesDic.Clear();
        }

        bool IDictionaryContainer<TKey, TInterface>.Add(TInterface value)
        {
            if (!(value is TValue item))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            var key = _keySelector(item);

            _valuesDic.Add(key, item);

            OnAdd?.Invoke(this, item);

            return true;
        }

        bool IDictionaryContainer<TKey, TInterface>.Update(TInterface value)
        {
            if (!(value is TValue value2))
                throw new NotSupportedException($"Value is not of type '{typeof(TValue)}'");

            var keyResult = _keySelector(value2);

            if (!_valuesDic.TryGetValue(keyResult, out TValue item))
                throw new KeyNotFoundException($"KeyNotFoundException '{keyResult}'");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            //if (string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
            //    JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
            //    return false;

            _valuesDic[keyResult] = value2;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        TInterface IDictionaryContainer<TKey, TInterface>.Get(Func<TInterface, bool> critera)
        {
            return Get(critera);
        }

        TInterface IDictionaryContainer<TKey, TInterface>.Get(TKey key)
        {
            return Get(key);
        }

        IEnumerable<TInterface> IDictionaryContainer<TKey, TInterface>.Gets()
        {
            return Gets();
        }

        IEnumerable<TInterface> IDictionaryContainer<TKey, TInterface>.Gets(Func<TInterface, bool> critera)
        {
            return Gets(critera);
        }

        bool IDictionaryContainer<TKey, TInterface>.TryGet(TKey key, out TInterface value)
        {
            if (!TryGet(key, out TValue item))
            {
                value = default(TValue);
                return false;
            }
            value = item;
            return true;
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

        bool IReadOnlyContainer<TKey, TInterface>.TryGet(TKey key, out TInterface value)
        {
            if (!TryGet(key, out TValue item))
            {
                value = default(TValue);
                return false;
            }
            value = item;
            return true;
        }

        public bool Add(TValue value)
        {
            var key = _keySelector(value);

            _valuesDic.Add(key, value);

            OnAdd?.Invoke(this, value);

            return true;
        }

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
    }

    public class DictionaryContainer<TKey, TValue> : IDictionaryContainer<TKey, TValue>,
        IReadOnlyContainer<TKey, TValue>
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

            _valuesDic.Add(key, value);

            OnAdd?.Invoke(this, value);

            return true;
        }

        public bool Remove(TKey key)
        {
            if (!_valuesDic.TryGetValue(key, out TValue value))
                return false;

            if (!_valuesDic.Remove(key))
                return false;

            OnRemoved?.Invoke(this, value);

            return true;
        }

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

        public event EventHandler<TValue> OnAdd;

        public event EventHandler<TValue> OnRemoved;

        public event EventHandler<TValue> OnUpdated;
    }
}