// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution367 {
        public bool IsPerfectSquare(int num) {
            if (num == 1) {
                return true;
            }

            long left = 0;
            long right = num / 2;
            while (left <= right) {
                long middle = left + (right - left) / 2;
                long product = middle * middle;
                if (product == num) {
                    return true;
                } else if (product > num) {
                    right = middle - 1;
                } else {
                    left = middle + 1;
                }
            }

            return false;
        }
    }
}
