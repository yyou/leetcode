using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution130UnionFind {
        public void Solve(char[][] board) {
            if (board.Length == 0) {
                return;
            }

            var m = board.Length;
            var n = board[0].Length;

            var uf = new UnionFind(m * n + 1);
            var dummy = m * n;

            for (var i = 0; i < n; ++i) {
                if (board[0][i] == 'O') {
                    uf.Union(i, dummy);
                }

                if (board[m - 1][i] == 'O') {
                    uf.Union((m - 1) * n + i, dummy);
                }
            }

            for (var j = 0; j < m; ++j) {
                if (board[j][0] == 'O') {
                    uf.Union(j * n, dummy);
                }

                if (board[j][n - 1] == 'O') {
                    uf.Union((j + 1) * n - 1, dummy);
                }
            }

            for (var i = 1; i < n - 1; ++i) {
                for (var j = 1; j < m - 1; ++j) {
                    if (board[j][i] == 'O') {
                        if (board[j - 1][i] == 'O') {
                            uf.Union((j - 1) * n + i, j * n + i);
                        }
                        if (board[j + 1][i] == 'O') {
                            uf.Union((j + 1) * n + i, j * n + i);
                        }
                        if (board[j][i - 1] == 'O') {
                            uf.Union(j * n + (i - 1), j * n + i);
                        }
                        if (board[j][i + 1] == 'O') {
                            uf.Union(j * n + i + 1, j * n + i);
                        }
                    }
                }
            }

            for (var i = 1; i < n - 1; ++i) {
                for (var j = 1; j < m - 1; ++j) {
                    if (board[j][i] == 'O' && !uf.Connected(j * n + i, dummy)) {
                        board[j][i] = 'X';
                    }
                }
            }
        }
    }
}