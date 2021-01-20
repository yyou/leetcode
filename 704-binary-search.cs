using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class Solution704
    {
        public int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
