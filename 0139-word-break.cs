// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution139 {
        public bool WordBreak(string s, IList<string> wordDict) {
            var dp = new bool[s.Length + 1];
            dp[0] = true;

            for (var i = 1; i <= s.Length; ++i) {
                for (var j = 0; j < i; ++j) {
                    var word = s.Substring(j, i - j);
                    if (wordDict.Contains(word) && dp[j] == true) {
                        dp[i] = true;
                    }
                }
            }

            return dp[s.Length];
        }
    }
}
