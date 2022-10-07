// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution54 {
        public IList<int> SpiralOrder(int[][] matrix) {
            var left = 0;
            var right = matrix[0].Length - 1;
            var top = 0;
            var bottom = matrix.Length - 1;

            var result = new List<int>();

            while (top <= bottom && left <= right) {
                for (var i = left; i <= right; ++i) {
                    result.Add(matrix[top][i]);
                }

                top++;

                for (var i = top; i <= bottom; ++i) {
                    result.Add(matrix[i][right]);
                }

                right--;

                if (top <= bottom) {
                    for (var i = right; i >= left; --i) {
                        result.Add(matrix[bottom][i]);
                    }

                    bottom--;
                }

                if (left <= right) {
                    for (var i = bottom; i >= top; --i) {
                        result.Add(matrix[i][left]);
                    }

                    left++;
                }
            }

            return result;
        }
    }
}
