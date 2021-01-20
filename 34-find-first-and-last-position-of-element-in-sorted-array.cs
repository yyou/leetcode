using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
public class Solution34
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new Int32[2];

        // Search left bound of target
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                right = mid - 1;
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

        if (left >= nums.Length || nums[left] != target)
        {
            result[0] = -1;
        }
        else
        {
            result[0] = left;
        }

        // Search right bound of target
        left = 0;
        right = nums.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                left = mid + 1;
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

        if (right == -1 || nums[right] != target)
        {
            result[1] = -1;
        }
        else
        {
            result[1] = right;
        }

        return result;
    }
}
}
