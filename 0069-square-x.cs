// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution69 {
        public int MySqrt(int x) {
            if (x < 2) {
                return x;
            }

            long left = 0;
            long right = x / 2;
            int result = 0;
            while (left <= right) {
                long middle = left + (right - left) / 2;
                if (middle * middle <= x) {
                    result = (int)middle;
                    left = middle + 1;
                } else {
                    right = middle - 1;
                }

            }

            return result;
        }
    }
}
