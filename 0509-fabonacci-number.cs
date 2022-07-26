// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution509 {
        public int Fib(int n) {
            if (n < 1) {
                return 0;
            }

            if (n == 1 || n == 2) {
                return 1;
            }

            var n0 = 1;
            var n1 = 1;
            var idx = 3;
            while (idx <= n) {
                var sum = n1 + n0;
                n0 = n1;
                n1 = sum;
                idx++;
            }
            return n1;
        }
    }
}
