// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution383 {
        public bool CanConstruct(string ransomNote, string magazine) {
            var magazineDict = new ItemCountDictionary<Char>();
            for (var i = 0; i < magazine.Length; ++i) {
                var c = magazine[i];
                magazineDict[c]++;
            }

            for (var i = 0; i < ransomNote.Length; ++i) {
                var c = ransomNote[i];
                magazineDict[c]--;
                if (magazineDict[c] < 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
