using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class LRUCache {
        private Dictionary<int, int> _keyToValue;
        private List<int> _keyToRecent;
        private int _capacity;

        public LRUCache(int capacity) {
            _keyToValue = new Dictionary<int, int>();
            _keyToRecent = new List<int>();
            _capacity = capacity;
        }

        public int Get(int key) {
            if (!_keyToValue.ContainsKey(key)) {
                return -1;
            }

            MakeKeyMostRecent(key);
            return _keyToValue[key];
        }

        public void Put(int key, int value) {
            if (_capacity <= 0) {
                return;
            }

            if (_keyToValue.ContainsKey(key)) {
                MakeKeyMostRecent(key);
                _keyToValue[key] = value;
                return;
            }

            if (_keyToValue.Count() >= _capacity) {
                RemoveRecentKey();
            }

            _keyToValue[key] = value;
            MakeKeyMostRecent(key);
        }

        private void MakeKeyMostRecent(int key) {
            var index = _keyToRecent.IndexOf(key);
            if (index == -1) {
                _keyToRecent.Add(key);
                return;
            } else {
                _keyToRecent.Remove(key);
                _keyToRecent.Add(key);
            }
        }

        private void RemoveRecentKey() {
            var key = _keyToRecent[0];
            _keyToValue.Remove(key);
            _keyToRecent.RemoveAt(0);
        }


    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}