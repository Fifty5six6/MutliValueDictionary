using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;

namespace MultiValueDictionary.Models
{
    /// <summary>
    /// Generic Implementation of a MultiValueDictionary
    /// </summary>
    /// <typeparam name="Key"> Datatype for the key </typeparam>
    /// <typeparam name="Value"> Datatype for the value </typeparam>
    public class MultiValueDictionary<Key, Value> : IMultiValueDictionary<Key, Value>
    {
        private Dictionary<Key, List<Value>> _dictionary { get; set; }

        public MultiValueDictionary()
        {
            _dictionary = new Dictionary<Key, List<Value>>();
        }

        public IEnumerable<Value> this[Key key]
        {
            get
            {
                return _dictionary[key]; ;
            }
        }

        public Value Add(Key key, Value value)
        {
            if (_dictionary.ContainsKey(key))
            {
                if (_dictionary[key].Contains(value))
                    throw new InvalidOperationException("Member already exists for key.");

                _dictionary[key].Add(value);
            }
            else
            {
                var newItem = new List<Value>();
                newItem.Add(value);
                _dictionary.Add(key, newItem);
            }

            return value;
        }

        public bool Remove(Key key, Value value)
        {
            if (_dictionary.ContainsKey(key))
            {
                var listVal = _dictionary[key];
                var memberFound = false;

                foreach (var val in listVal)
                {
                    if (EqualityComparer<Value>.Default.Equals(val, value))
                    {
                        memberFound = true;
                        if (listVal.Count > 1)
                            return listVal.Remove(val);
                        
                        return _dictionary.Remove(key);                        
                    }
                }

                if (!memberFound)
                    throw new InvalidOperationException("Member does not exist.");
            }
            throw new InvalidOperationException("Key does not exist.");
        }

        public bool RemoveAll(Key key)
        {
            if (!_dictionary.ContainsKey(key))
                throw new InvalidOperationException("Key does not exist.");

            return _dictionary.Remove(key);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public IEnumerable<Key> Keys()
        {
            return _dictionary.Keys;
        }

        public bool KeyExists(Key key)
        {
            return _dictionary.ContainsKey(key);
        }

        public IEnumerable<Value> Members(Key key)
        {
            if (_dictionary.ContainsKey(key))
            {
                var members = _dictionary[key];
                return members;
            }

            throw new ArgumentOutOfRangeException("", "Key does not exist.");
        }

        public IEnumerable<Value> AllMembers()
        {
            List<Value> membersToReturn = new List<Value>();

            var members = _dictionary.Values;

            foreach (var member in members)
            {
                foreach (var list in member)
                {
                    membersToReturn.Add(list);
                }
            }

            return membersToReturn;
        }

        public bool MemberExists(Key key, Value value)
        {
            if (_dictionary.ContainsKey(key))
                return _dictionary[key].Contains(value);
                                       
            return false;            
        }

        public IEnumerable<KeyValuePair<Key, Value>> Items()
        {
            var kvpList = new List<KeyValuePair<Key, Value>>();

            foreach(var key in _dictionary.Keys)
            {
                foreach (var val in _dictionary[key])
                {
                    kvpList.Add(new KeyValuePair<Key, Value>(key, val));
                }
            }

            return kvpList;
        }


    }
}
