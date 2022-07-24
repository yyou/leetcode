// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution763 {
        public IList<int> PartitionLabels(string s) {
            var hash = new int[26];
            for (var i = 0; i < s.Length; ++i) {
                hash[s[i] - 'a'] = i;
            }

            var left = 0;
            var right = 0;
            var result = new List<int>();
            for (var i = 0; i < s.Length; ++i) {
                right = Math.Max(right, hash[s[i] - 'a']);
                if (right == i) {
                    result.Add(right - left + 1);
                    left = i + 1;
                }
            }

            return result;
        }
    }
}
