using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution509 {
        public int Fib(int n) {
            if (n < 1) {
                return 0;
            }

            if (n == 1 || n == 2) {
                return 1;
            }

            var n0 = 1;
            var n1 = 1;
            var idx = 3;
            while (idx <= n) {
                var tmp = n1 + n0;
                n0 = n1;
                n1 = tmp;
                idx++;
            }
            return n1;
        }
    }
}
