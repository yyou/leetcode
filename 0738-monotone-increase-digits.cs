// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution738 {
        public int MonotoneIncreasingDigits(int n) {
            var chars = n.ToString().ToCharArray();

            var flag = chars.Length;
            for (var i = chars.Length - 1; i > 0; i--) {
                if (chars[i - 1] > chars[i]) {
                    flag = i;
                    chars[i - 1]--;
                }
            }

            for (var i = flag; i < chars.Length; ++i) {
                chars[i] = '9';
            }

            var s = String.Join("", chars);
            return Int32.Parse(s);
        }
    }
}
