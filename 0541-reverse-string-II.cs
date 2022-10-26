// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution541 {
        public string ReverseStr(string s, int k) {
            var c = s.ToCharArray();

            for (var i = 0; i < c.Length; i += 2 * k) {
                if (c.Length < i + k) {
                    Reverse(c, i, c.Length - 1);
                } else {
                    Reverse(c, i, i + k - 1);
                }
            }

            return new string(c);
        }

        private void Reverse(char[] c, int start, int end) {
            var i = start;
            var j = end;
            while (i < j) {
                var tmp = c[i];
                c[i] = c[j];
                c[j] = tmp;
                i++;
                j--;
            }
        }
    }
}
