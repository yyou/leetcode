using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution150 {
        public int EvalRPN(string[] tokens) {
            var stack = new Stack<int>();
            for (var i = 0; i < tokens.Length; ++i) {
                if (tokens[i] == "+") {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 + num1);
                    continue;
                }

                if (tokens[i] == "-") {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 - num1);
                    continue;
                }

                if (tokens[i] == "*") {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 * num1);
                    continue;
                }

                if (tokens[i] == "/") {
                    var num1 = stack.Pop();
                    var num2 = stack.Pop();
                    stack.Push(num2 / num1);
                    continue;
                }

                stack.Push(int.Parse(tokens[i]));
            }

            return stack.Pop();
        }
    }
}