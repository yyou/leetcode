// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution37 {
        public void SolveSudoku(char[][] board) {
            BackTracking(board);
        }

        private bool BackTracking(char[][] board) {
            var rowNum = board.Length;
            var colNum = board[0].Length;

            for (var i = 0; i < rowNum; ++i) {
                for (var j = 0; j < colNum; ++j) {
                    if (board[i][j] != '.') {
                        continue;
                    }

                    for (var k = '1'; k <= '9'; ++k) {
                        if (IsValid(i, j, k, board)) {
                            board[i][j] = k;
                            if (BackTracking(board)) {
                                return true;
                            }
                            board[i][j] = '.';
                        }
                    }

                    return false;
                }
            }

            return true;
        }

        private bool IsValid(int row, int col, char val, char[][] board) {
            for (var i = 0; i < 9; ++i) {
                if (board[row][i] == val) {
                    return false;
                }
            }

            for (var i = 0; i < 9; ++i) {
                if (board[i][col] == val) {
                    return false;
                }
            }

            var rowStart = (row / 3) * 3;
            var colStart = (col / 3) * 3;
            for (var i = rowStart; i < rowStart + 3; ++i) {
                for (var j = colStart; j < colStart + 3; ++j) {
                    if (board[i][j] == val) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
