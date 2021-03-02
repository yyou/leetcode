using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution202 {
        public bool IsHappy(int n) {
            var set = new HashSet<int>();
            while (true) {
                var sum = GetSquareSum(n);
                if (sum == 1) {
                    return true;
                }

                if (set.Contains(sum)) {
                    return false;
                } else {
                    set.Add(sum);
                    n = sum;
                }
            }
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