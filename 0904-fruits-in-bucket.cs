// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;

namespace leetcode {
    public class Solution904 {

        public int TotalFruit(int[] fruits) {
            var result = 0;
            var dict = new ItemCountDictionary<int>();
            var left = 0;
            for (var right = 0; right < fruits.Length; ++right) {
                dict[fruits[right]]++;

                while (dict.Count() > 2) {
                    dict[fruits[left]]--;
                    if (dict[fruits[left]] == 0) {
                        dict.Remove(fruits[left]);
                    }
                    left++;
                }

                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }

}
