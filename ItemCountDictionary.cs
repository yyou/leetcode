using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class ItemCountDictionary<TKey> : Dictionary<TKey, int> {
        public new int this[TKey key] { 
            get {
                if (!ContainsKey(key)) {
                    base[key] = 0;                    
                }
                return base[key];
            }
            set {
                base[key] = value;
            }
        }
    }
}