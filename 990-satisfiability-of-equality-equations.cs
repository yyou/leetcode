using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution990 {
        public bool EquationsPossible(string[] equations) {
            var uf = new UnionFind(26);
            foreach (var equation in equations.Where(e => e.Contains("=="))) {
                var firstLetter = equation[0];
                var fourthLetter = equation[3];
                uf.Union(firstLetter - 'a', fourthLetter - 'a');
            }

            foreach (var equation in equations.Where(e => e.Contains("!="))) {
                var firstLetter = equation[0];
                var fourthLetter = equation[3];
                if (uf.Connected(firstLetter - 'a', fourthLetter - 'a')) {
                    return false;
                }
            }

            return true;
        }
    }
}