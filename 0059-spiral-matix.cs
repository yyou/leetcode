// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution59 {
        public int[][] GenerateMatrix(int n) {
            if (n <= 0) {
                return new int[0][];
            }

            var a = new int[n][];
            for (var i = 0; i < n; ++i) {
                a[i] = new int[n];
                for (var j = 0; j < n; ++j) {
                    a[i][j] = -1;
                }
            }

            var curDirection = 0;
            var curNum = 1;
            var row = 0;
            var column = 0;
            while (curNum <= n * n) {
                a[row][column] = curNum++;
                MoveToNextLocation(a, ref row, ref column, ref curDirection);
            }

            return a;
        }

        private void MoveToNextLocation(int[][] a, ref int curRow, ref int curColumn, ref int curDirection) {
            int nextColumn = 0;
            int nextRow = 0;

            switch (curDirection) {
                case 0: // go right
                    nextColumn = curColumn + 1;
                    if (nextColumn >= a[0].Length || a[curRow][nextColumn] != -1) {
                        curDirection = (curDirection + 1) % 4;
                        curRow++;
                    } else {
                        curColumn++;
                    }

                    break;
                case 1:  // go down
                    nextRow = curRow + 1;
                    if (nextRow >= a.Length || a[nextRow][curColumn] != -1) {
                        curDirection = (curDirection + 1) % 4;
                        curColumn--;
                    } else {
                        curRow++;
                    }
                    break;
                case 2:  // go left
                    nextColumn = curColumn - 1;
                    if (nextColumn < 0 || a[curRow][nextColumn] != -1) {
                        curDirection = (curDirection + 1) % 4;
                        curRow--;
                    } else {
                        curColumn--;
                    }

                    break;
                case 3:  // go up
                    nextRow = curRow - 1;
                    if (nextRow < 0 || a[nextRow][curColumn] != -1) {
                        curDirection = (curDirection + 1) % 4;
                        curColumn++;
                    } else {
                        curRow--;
                    }
                    break;
            }
        }

        // better solution than the one above
        public int[][] GenerateMatrix2(int n) {
            var left = 0;
            var right = n - 1;
            var top = 0;
            var bottom = n - 1;

            var matrix = new int[n][];
            for (var i = 0; i < n; ++i) {
                matrix[i] = new int[n];
            }

            var count = 0;

            while (top <= bottom && left <= right) {
                for (var i = left; i <= right; ++i) {
                    matrix[top][i] = ++count;
                }
                top++;

                for (var i = top; i <= bottom; ++i) {
                    matrix[i][right] = ++count;
                }
                right--;

                if (top <= bottom) {
                    for (var i = right; i >= left; --i) {
                        matrix[bottom][i] = ++count;
                    }
                    bottom--;
                }

                if (left <= right) {
                    for (var i = bottom; i >= top; --i) {
                        matrix[i][left] = ++count;
                    }

                    left++;
                }
            }

            return matrix;
        }
    }
}
