// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution202 {
        public bool IsHappy(int n) {
            var set = new HashSet<int>();
            while (n != 1) {
                var sum = GetSquareSum(n);
                if (set.Contains(sum)) {
                    return false;
                } else {
                    set.Add(sum);
                    n = sum;
                }
            }
            return true;
        }

        private int GetSquareSum(int n) {
            var sum = 0;
            while (n != 0) {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }
            return sum;
        }
    }
}
