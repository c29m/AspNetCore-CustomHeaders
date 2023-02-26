using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Mdameer.AspNetCore.CustomHeaders
{
    public class CustomHeadersOptions : ICollection<KeyValuePair<string, StringValues>>
    {
        private IDictionary<string, StringValues> items;

        public CustomHeadersOptions()
        {
            items = new Dictionary<string, StringValues>();
        }

        public int Count => items.Count;

        public bool IsReadOnly => items.IsReadOnly;

        public StringValues this[string key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        public StringValues Get(string key)
        {
            if (items.TryGetValue(key, out var value))
                return value;

            return StringValues.Empty;
        }

        public void Add(string key, StringValues value)
        {
            items[key] = value;
        }

        public void Add(KeyValuePair<string, StringValues> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear() => items.Clear();
        public bool Contains(KeyValuePair<string, StringValues> item) => items.Contains(item);
        public bool ContainsKey(string key) => items.ContainsKey(key);
        public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => items.GetEnumerator();
        public bool Remove(KeyValuePair<string, StringValues> item) => items.Remove(item.Key);
        public bool Remove(string key) => items.Remove(key);
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
