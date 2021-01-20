using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class Solution3
    {
        public int LengthOfLongestSubstring(string s)
        {
            var window = new Dictionary<Char, Int32>();

            int left = 0, right = 0;
            int maxLength = Int32.MinValue;

            while (right < s.Length)
            {
                char c = s[right];

                if (!window.ContainsKey(c))
                {
                    maxLength = Math.Max(maxLength, right - left + 1);
                    window[c] = right;
                }
                else
                {
                    var previousLocation = window[c];
                    maxLength = Math.Max(maxLength, right - left);
                    while (left < previousLocation + 1)
                    {
                        window.Remove(s[left]);
                        left++;
                    }
                    window[c] = right;
                }

                right++;
            }

            return maxLength == Int32.MinValue ? 0 : maxLength;
        }
    }
}
