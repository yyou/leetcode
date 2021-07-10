using System.Collections.Generic;
using System;

namespace leetcode {
    public class Solution1002 {
        public IList<string> CommonChars(string[] words) {
            if (words == null) {
                return new List<string>();
            }

            var hash = new int[26];

            for (var i = 0; i < words[0].Length; ++i) {
                hash[words[0][i] - 'a']++;
            }

            for (var j = 1; j < words.Length; j++) {
                var anotherHash = new int[26];
                for (var k = 0; k < words[j].Length; k++) {
                    anotherHash[words[j][k] - 'a']++;
                }

                for (var n = 0; n < 26; ++n) {
                    hash[n] = Math.Min(hash[n], anotherHash[n]);
                }
            }

            var result = new List<String>();

            for (var n = 0; n < 26; n++) {
                if (hash[n] > 0) {
                    for (var m = 0; m < hash[n]; ++m) {
                        result.Add(new String(new Char[] { (Char)('a' + n) }));
                    }
                }
            }

            return result;
        }
    }
}