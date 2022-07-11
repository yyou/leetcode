using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode {
    public class Solution {
        private readonly IList<IList<string>> _result = new List<IList<string>>();

        public IList<IList<string>> SolveNQueens(int n) {
            var chessboard = new char[n, n];
            for (var row = 0; row < n; ++row) {
                for (var col = 0; col < n; ++col) {
                    chessboard[row, col] = '.';
                }
            }

            BackTracking(0, n, chessboard);

            return _result;
        }

        private void BackTracking(int row, int n, char[,] chessboard) {
            if (row == n) {
                var res = new List<string>();
                for (var i = 0; i < n; ++i) {
                    var s = new StringBuilder();
                    for (var j = 0; j < n; ++j) {
                        s.Append(chessboard[i, j]);
                    }
                    res.Add(s.ToString());
                }
                _result.Add(res);
                return;
            }

            for (var col = 0; col < n; ++col) {
                if (IsValid(row, col, n, chessboard)) {
                    chessboard[row, col] = 'Q';
                    BackTracking(row + 1, n, chessboard);
                    chessboard[row, col] = '.';
                }
            }
        }

        private static bool IsValid(int row, int col, int n, char[,] chessboard) {
            for (var i = 0; i < row; ++i) {
                if (chessboard[i, col] == 'Q') {
                    return false;
                }
            }

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--) {
                if (chessboard[i, j] == 'Q') {
                    return false;
                }
            }

            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++) {
                if (chessboard[i, j] == 'Q') {
                    return false;
                }
            }

            return true;
        }
    }
}
