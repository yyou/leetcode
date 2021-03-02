using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution20 {
        public bool IsValid(string s) {
            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; ++i) {
                if (s[i] == ' ') {
                    continue;
                }

                if (s[i] == '(' || s[i] == '{' || s[i] == '[') {
                    stack.Push(s[i]);
                }

                if (s[i] == ')') {
                    if (stack.Count == 0 || stack.Peek() != '(') {
                        return false;
                    }
                    stack.Pop();
                }

                if (s[i] == '}') {
                    if (stack.Count == 0 || stack.Peek() != '{') {
                        return false;
                    }
                    stack.Pop();
                }

                if (s[i] == ']') {
                    if (stack.Count == 0 || stack.Peek() != '[') {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}