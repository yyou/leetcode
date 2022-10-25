// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution18 {
        public IList<IList<int>> FourSum(int[] nums, int target) {
            Array.Sort(nums, 0, nums.Length);

            var result = new List<IList<int>>();

            for (var i = 0; i < nums.Length - 3; ++i) {
                if (nums[i] >= 0 && nums[i] > target) {
                    break;
                }

                if (i > 0 && nums[i] == nums[i - 1]) {
                    continue;
                }

                for (var j = i + 1; j < nums.Length - 2; ++j) {
                    if (nums[i] + nums[j] > target && nums[i] + nums[j] >= 0) {
                        break;
                    }

                    if (j > i + 1 && nums[j] == nums[j - 1]) {
                        continue;
                    }

                    var left = j + 1;
                    var right = nums.Length - 1;
                    while (left < right) {
                        var sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum < target) {
                            left++;
                        } else if (sum > target) {
                            right--;
                        } else if (sum == target) {
                            var tuple = new List<int>() { nums[i], nums[j], nums[left], nums[right] };
                            result.Add(tuple);

                            while (left < right && nums[left] == nums[left + 1]) {
                                left++;
                            }

                            while (left < right && nums[right] == nums[right - 1]) {
                                right--;
                            }

                            left++;
                            right--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
