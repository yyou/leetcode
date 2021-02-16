using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}