#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjectCeleste.GamesFiles.XMLParser.Container.Interface;

#endregion

namespace ProjectCeleste.GamesFiles.XMLParser.Container
{
    public class DictionaryContainer<T1, T2> : IDictionaryContainer<T1, T2>
    {
        [XmlIgnore]
        [JsonIgnore]
        private readonly IDictionary<T1, T2> _valuesDic;

        private readonly Func<T2, T1> _keySelector;

        public DictionaryContainer(Func<T2, T1> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>();
        }

        public DictionaryContainer(IDictionary<T1, T2> values, Func<T2, T1> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>(new Dictionary<T1, T2>(values));
        }

        public DictionaryContainer(Func<T2, T1> keySelector, IEqualityComparer<T1> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>(new Dictionary<T1, T2>(comparer));
        }

        public DictionaryContainer(IDictionary<T1, T2> values, Func<T2, T1> keySelector, IEqualityComparer<T1> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>(new Dictionary<T1, T2>(values, comparer));
        }

        public DictionaryContainer(IEnumerable<T2> values, Func<T2, T1> keySelector)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>(values.ToDictionary(keySelector));
        }

        public DictionaryContainer(IEnumerable<T2> values, Func<T2, T1> keySelector, IEqualityComparer<T1> comparer)
        {
            _keySelector = keySelector;
            _valuesDic = new Dictionary<T1, T2>(values.ToDictionary(keySelector, comparer));
        }

        public bool ContainsKey(T1 key)
        {
            return _valuesDic.ContainsKey(key);
        }
        
        public event EventHandler<T2> OnAdd;
        
        public bool Add(T2 value)
        {
            var key = _keySelector(value);

            _valuesDic.Add(key, value);

            OnAdd?.Invoke(this, value);

            return true;
        }

        public event EventHandler<T2> OnRemoved;

        public bool Remove(T1 key)
        {
            if (!_valuesDic.TryGetValue(key, out T2 value))
                return false;

            if(!_valuesDic.Remove(key))
                return false;

            OnRemoved?.Invoke(this, value);

            return true;
        }
        
        public event EventHandler<T2> OnUpdated;
        
        public bool Update(T2 value)
        {
            var keyResult = _keySelector(value);

            if (!_valuesDic.TryGetValue(keyResult, out T2 item))
                throw new KeyNotFoundException($"KeyNotFoundException '{keyResult}'");

            if (ReferenceEquals(value, item) || Equals(value, item))
                return false;

            if(string.Equals(JsonConvert.SerializeObject(value, Formatting.None),
                JsonConvert.SerializeObject(item, Formatting.None), StringComparison.OrdinalIgnoreCase))
                return false;

            _valuesDic[keyResult] = value;

            OnUpdated?.Invoke(this, value);

            return true;
        }

        [XmlIgnore]
        [JsonIgnore]
        public T2 this[T1 key] => _valuesDic.TryGetValue(key, out T2 value)
            ? value
            : throw new KeyNotFoundException($"KeyNotFoundException '{key}'");

        [XmlIgnore]
        [JsonIgnore]
        public int Count => _valuesDic.Count;

        public T2 Get(T1 key)
        {
            return _valuesDic.TryGetValue(key, out T2 value)
                ? value
                : default(T2);
        }

        public T2 Get(Func<T2, bool> critera)
        {
            return Gets().FirstOrDefault(critera);
        }

        public bool TryGet(T1 key, out T2 value)
        {
            return _valuesDic.TryGetValue(key, out value);
        }

        public IEnumerable<T2> Gets(Func<T2, bool> critera)
        {
            return Gets().Where(critera);
        }

        public IEnumerable<T2> Gets()
        {
            return _valuesDic.ToArray().Select(p => p.Value);
        }

        public void Clear()
        {
            _valuesDic.Clear();
        }

    }
}