using System;

namespace leetcode {
    public class Solution454 {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
            var dict = new ItemCountDictionary<int>();
            for (var i = 0; i < A.Length; ++i) {
                for (var j = 0; j < B.Length; ++j) {
                    dict[A[i] + B[j]]++;
                }
            }

            var count = 0;
            for (var k = 0; k < C.Length; ++k) {
                for (var l = 0; l < D.Length; ++l) {
                    var sum = C[k] + D[l];
                    if (dict[0 - sum] > 0) {
                        count += dict[0 - sum];
                    }
                }
            }

            return count;
        }
    }
}
