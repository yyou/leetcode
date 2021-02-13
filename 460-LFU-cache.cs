using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class LFUCache {
        private Dictionary<int, int> _keyToValue;
        private ItemCountDictionary<int> _keyToFreq;
        private Dictionary<int, List<int>> _freqToKeys;
        private int _capacity;
        private int _minFreq;

        public LFUCache(int capacity) {
            _keyToValue = new Dictionary<int, int>();
            _keyToFreq = new ItemCountDictionary<int>();
            _freqToKeys = new Dictionary<int, List<int>>();
            _capacity = capacity;
            _minFreq = 0;
        }

        public int Get(int key) {
            if (!_keyToValue.ContainsKey(key)) {
                return -1;
            }

            IncreaseFrequency(key);
            return _keyToValue[key];
        }

        private void IncreaseFrequency(int key) {
            // Increase key's frequency        
            var freq = _keyToFreq[key];
            _keyToFreq[key] = freq + 1;

            // Increase frequency to keys
            if (freq == 0) {
                if (!_freqToKeys.ContainsKey(1)) {
                    _freqToKeys[1] = new List<int>();
                }
                _freqToKeys[1].Add(key);
                _minFreq = 1;
                return;
            }

            List<int> keys = _freqToKeys[freq];
            keys.Remove(key);
            if (!keys.Any()) {
                _freqToKeys.Remove(freq);
                if (_minFreq == freq) {
                    _minFreq = freq + 1;
                }
            }
            if (!_freqToKeys.ContainsKey(freq + 1)) {
                _freqToKeys[freq + 1] = new List<int>();
            }
            _freqToKeys[freq + 1].Add(key);
        }

        public void Put(int key, int value) {
            if (this._capacity <= 0) {
                return;
            }

            if (_keyToValue.ContainsKey(key)) {
                IncreaseFrequency(key);
                _keyToValue[key] = value;
                return;
            }

            if (_capacity <= _keyToValue.Count()) {
                RemoveLeastFrequencyKey();
            }

            _keyToValue[key] = value;
            IncreaseFrequency(key);
        }

        private void RemoveLeastFrequencyKey() {
            var keys = _freqToKeys[_minFreq];
            var key = keys.First();
            keys.RemoveAt(0);
            if (!keys.Any()) {
                _freqToKeys.Remove(_minFreq);
            }
            _keyToFreq.Remove(key);
            _keyToValue.Remove(key);
        }
    }
}