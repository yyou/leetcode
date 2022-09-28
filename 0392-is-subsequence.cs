// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution392 {

        // two-points
        public bool IsSubsequence1(string s, string t) {
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

        // DP
        public bool IsSubsequence2(string s, string t) {
            var size1 = s.Length;
            if (size1 == 0) {
                return true;
            }

            var size2 = t.Length;
            if (size2 == 0) {
                return false;
            }

            var dp = new int[size1 + 1, size2 + 1];
            for (var i = 1; i <= size1; ++i) {
                for (var j = 1; j <= size2; ++j) {
                    if (s[i - 1] == t[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else {
                        dp[i, j] = dp[i, j - 1];
                    }
                }
            }

            return dp[size1, size2] == size1;
        }
    }
}
