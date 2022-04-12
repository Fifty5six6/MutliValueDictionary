using MultiValueDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class MultiValueDictionaryStringTests
    {
        private readonly MultiValueDictionary<string, string> _dictionary;

        public MultiValueDictionaryStringTests()
        {
            _dictionary = new MultiValueDictionary<string, string>();
        }

        [Fact]
        public void Add_AddsKeyAndValue()
        {
            _dictionary.Add("Key", "Value1");

            var result = _dictionary["Key"];

            Assert.Equal("Value1", result.First());
        }

        [Fact]
        public void Add_AddsKeyAndAdditionalValue()
        {
            _dictionary.Add("Key", "Value1");
            _dictionary.Add("Key", "Value2");

            var result = _dictionary["Key"];

            Assert.Equal(2, result.Count());
            Assert.Equal("Value1", result.First());
            Assert.Equal("Value2", result.Last());
        }

        [Fact]
        public void Add_ThrowsInvalidOperationExceptionIfValueExistsForKey()
        {
            _dictionary.Add("Key", "Value1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                _dictionary.Add("Key", "Value1");
            });
        }

        [Fact]
        public void Remove_RemovesTheSpecifiedMember()
        {
            _dictionary.Add("Key", "Value1");
            _dictionary.Add("Key", "Value2");

            _dictionary.Remove("Key", "Value2");

            var result = _dictionary["Key"];

            Assert.Contains("Value1", result);
            Assert.DoesNotContain("Value2", result);
        }

        [Fact]
        public void Remove_RemovesKeyIfNoMembersLeft()
        {
            _dictionary.Add("Key", "Value1");
            _dictionary.Remove("Key", "Value1");

            Assert.False(_dictionary.KeyExists("Key"));
        }

        [Fact]
        public void Remove_ReturnsTrueIfKeyHasMatchingValue()
        {
            _dictionary.Add("Key", "Value1");

            Assert.True(_dictionary.Remove("Key", "Value1"));
        }

        [Fact]
        public void Remove_ThrowsInvalidOperationExceptionIfKeyHasNoMatchingValue()
        {
            _dictionary.Add("Key", "Value1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                _dictionary.Remove("Key", "Value2");
            });
        }

        [Fact]
        public void Remove_ThrowsInvalidOperationExceptionIfKeyDoesNotExist()
        {
            _dictionary.Add("Key", "Value1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                _dictionary.Remove("Key2", "Value1");
            });
        }

        [Fact]
        public void RemoveAll_RemovesKeyAndAllMembers()
        {
            _dictionary.Add("Key", "Value1");
            _dictionary.Add("Key", "Value2");

            _dictionary.RemoveAll("Key");

            Assert.False(_dictionary.KeyExists("Key"));
        }

        [Fact]
        public void RemoveAll_ReturnsTrueIfMatchingKeyFoundAndRemoved()
        {
            _dictionary.Add("Key", "Value1");

            Assert.True(_dictionary.RemoveAll("Key"));
        }

        [Fact]
        public void RemoveAll_ThrowsInvalidOperationExceptionIfNoKeyFound()
        {
            _dictionary.Add("Key", "Value1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                _dictionary.RemoveAll("Key1");
            });
        }

        [Fact]
        public void Clear_RemovesEverything()
        {
            _dictionary.Add("Key", "Value1");
            _dictionary.Add("Key", "Value2");
            _dictionary.Add("Key2", "Value3");
            _dictionary.Add("Key2", "Value4");

            _dictionary.Clear();

            Assert.True(_dictionary.Items().Count() == 0);
        }

        [Fact]
        public void Keys_ReturnsAllKeys()
        {
            var keysToCompare = new[] { "Key1", "Key2", "Key3" };

            _dictionary.Add(keysToCompare[0], "Value1");
            _dictionary.Add(keysToCompare[1], "Value1");
            _dictionary.Add(keysToCompare[2], "Value1");

            var keys = _dictionary.Keys();

            Assert.All(keys, key => keysToCompare.Contains(key));
            Assert.All(keysToCompare, key => keys.Contains(key));
        }

        [Fact]
        public void Keys_IsEmptyIfDictionaryHasNoKeys()
        {
            Assert.Empty(_dictionary.Keys());
        }

        [Fact]
        public void KeyExists_ReturnsTrueIfKeyExists()
        {
            _dictionary.Add("Key", "Value1");

            Assert.True(_dictionary.KeyExists("Key"));
        }

        [Fact]
        public void KeyExists_ReturnsFalseIfKeyDoesNotExist()
        {
            _dictionary.Add("Key", "Value1");

            Assert.False(_dictionary.KeyExists("Key1"));
        }

        [Fact]
        public void Members_ReturnsAllMembersForSpecificKey()
        {
            var membersToCompare = new[] { "Value1", "Value2", "Value3" };

            _dictionary.Add("Key", membersToCompare[0]);
            _dictionary.Add("Key", membersToCompare[1]);
            _dictionary.Add("Key", membersToCompare[2]);
            _dictionary.Add("Key2", membersToCompare[0]);

            var values = _dictionary.Members("Key");

            Assert.All(values, value => membersToCompare.Contains(value));
            Assert.All(membersToCompare, value => values.Contains(value));
        }

        [Fact]
        public void Members_InvalidOperationExceptionWhenNoMatchingKey()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _dictionary.Members("Key");
            });
        }

        [Fact]
        public void AllMembers_ReturnsAllMembers()
        {
            var membersToCompare = new[] { "Value1", "Value2", "Value3", "Value4", "Value5", "Value6" };

            _dictionary.Add("Key", membersToCompare[0]);
            _dictionary.Add("Key", membersToCompare[1]);
            _dictionary.Add("Key", membersToCompare[2]);
            _dictionary.Add("Key2", membersToCompare[3]);
            _dictionary.Add("Key2", membersToCompare[4]);
            _dictionary.Add("Key2", membersToCompare[5]);

            var values = _dictionary.AllMembers();

            Assert.All(values, value => membersToCompare.Contains(value));
            Assert.All(membersToCompare, value => values.Contains(value));
        }

        [Fact]
        public void AllMembers_ThrowsInvalidArgumentExceptionIfEmpty()
        {
            var result = _dictionary.AllMembers();

            Assert.Empty(result);
        }

        [Fact]
        public void MemberExists_ReturnsTrueIfKeyExistsAndContainsMember()
        {
            _dictionary.Add("Key", "Value1");

            Assert.True(_dictionary.MemberExists("Key", "Value1"));
        }

        [Fact]
        public void MemberExists_ReturnsFalseIfKeyDoesNotExist()
        {
            _dictionary.Add("Key", "Value1");

            Assert.False(_dictionary.MemberExists("Key2", "Value1"));
        }

        [Fact]
        public void MemberExists_ReturnsFalseIfMemberDoesNotExist()
        {
            _dictionary.Add("Key", "Value1");

            Assert.False(_dictionary.MemberExists("Key", "Value2"));
        }

        [Fact]
        public void Items_ReturnsAllItems()
        {
            var kvpToCompare = new[]
            {
                new KeyValuePair<string, string>("Key1", "Value1"),
                new KeyValuePair<string, string>("Key1", "Value2"),
                new KeyValuePair<string, string>("Key1", "Value3"),
                new KeyValuePair<string, string>("Key2", "Value1"),
                new KeyValuePair<string, string>("Key2", "Value2"),
                new KeyValuePair<string, string>("Key3", "Value1"),
                new KeyValuePair<string, string>("Key3", "Value2"),
                new KeyValuePair<string, string>("Key3", "Value3")
            };

            foreach (var kvp in kvpToCompare)
            {
                _dictionary.Add(kvp.Key, kvp.Value);
            }

            var result = _dictionary.Items();

            Assert.All(result, itm => kvpToCompare.Contains(itm));
            Assert.All(kvpToCompare, itm => result.Contains(itm));
        }

        [Fact]
        public void Items_IsEmptyIfNoItemsExist()
        {
            var result = _dictionary.Items();

            Assert.Empty(result);
        }
    }
}
