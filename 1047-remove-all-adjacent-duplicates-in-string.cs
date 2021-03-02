using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution1047 {
        public string RemoveDuplicates(string S) {
            if (S.Length <= 1) {
                return S;
            }

            var stack = new Stack<char>();
            stack.Push(S[0]);
            for (var i = 1; i < S.Length; ++i) {
                if (stack.Count > 0 && stack.Peek() == S[i]) {
                    stack.Pop();
                } else {
                    stack.Push(S[i]);
                }
            }

            var a = new Char[stack.Count];
            var index = a.Length - 1;
            while (stack.Count > 0) {
                a[index--] = stack.Pop();
            }
            return new String(a);
        }
    }
}
