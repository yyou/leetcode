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
                for (var j = 0; j < wordDict.Count; ++j) {
                    if (wordDict[j].Length <= i) {
                        var word = s.Substring(i - wordDict[j].Length, wordDict[j].Length);
                        if (word == wordDict[j] && dp[i - wordDict[j].Length]) {
                            dp[i] = true;
                        }
                    }
                }
            }

            return dp[s.Length];
        }
    }
}
