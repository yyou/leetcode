// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution134 {
        public int CanCompleteCircuit1(int[] gas, int[] cost) {
            var num = gas.Length;
            var curSum = 0;
            var min = int.MaxValue;
            for (var i = 0; i < num; ++i) {
                curSum += (gas[i] - cost[i]);
                if (curSum < min) {
                    min = curSum;
                }
            }

            if (curSum < 0) {
                return -1;
            }

            if (min > 0) {
                return 0;
            }

            for (var i = num - 1; i >= 0; --i) {
                min += (gas[i] - cost[i]);
                if (min >= 0) {
                    return i;
                }
            }

            return -1;
        }

        public int CanCompleteCircuit2(int[] gas, int[] cost) {
            var start = 0;
            var curSum = 0;
            var totalSum = 0;

            for (var i = 0; i < gas.Length; ++i) {
                var rest = gas[i] - cost[i];
                curSum += rest;
                totalSum += rest;
                if (curSum < 0) {
                    start = i + 1;
                    curSum = 0;
                }
            }

            if (totalSum < 0) {
                return -1;
            }

            return start;
        }
    }
}
