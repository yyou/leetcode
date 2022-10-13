// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution242 {
        public bool IsAnagram(string s, string t) {
            var a = new int[26];
            for (var i = 0; i < s.Length; ++i) {
                a[s[i] - 'a']++;
            }

            var b = new int[26];
            for (var i = 0; i < t.Length; ++i) {
                b[t[i] - 'a']++;
            }

            for (var i = 0; i < 26; ++i) {
                if (a[i] != b[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
