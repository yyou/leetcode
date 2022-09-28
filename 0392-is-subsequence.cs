// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution392 {
        public bool IsSubsequence(string s, string t) {
            var size1 = s.Length;
            if (size1 == 0) {
                return true;
            }

            var size2 = t.Length;
            if (size2 == 0) {
                return false;
            }

            int i = 0;
            int j = 0;
            while (j != size2 && i != size1) {
                if (s[i] == t[j]) {
                    i++;
                }

                j++;
            }

            return i == size1;
        }
    }
}
