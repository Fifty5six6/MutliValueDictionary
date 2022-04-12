using System.Collections.Generic;

namespace MultiValueDictionary.Interfaces
{
    public interface IMultiValueDictionary<TKey, TValue> 
    {
        public TValue Add(TKey key, TValue value);

        bool Remove(TKey key, TValue value);

        bool RemoveAll(TKey key);

        void Clear();

        bool KeyExists(TKey key);

        bool MemberExists(TKey key, TValue value);

        IEnumerable<TKey> Keys();

        IEnumerable<TValue> AllMembers();

        IEnumerable<TValue> Members(TKey key);

        IEnumerable<KeyValuePair<TKey, TValue>> Items();

    }
}
