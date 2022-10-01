// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution844 {
        public bool BackspaceCompare(string s, string t) {
            var stack1 = new Stack<char>();
            for (var i = 0; i < s.Length; ++i) {
                if (s[i] != '#') {
                    stack1.Push(s[i]);
                } else {
                    if (stack1.Count > 0) {
                        stack1.Pop();
                    }
                }
            }

            var stack2 = new Stack<char>();
            for (var i = 0; i < t.Length; ++i) {
                if (t[i] != '#') {
                    stack2.Push(t[i]);
                } else {
                    if (stack2.Count > 0) {
                        stack2.Pop();
                    }
                }
            }

            if (stack1.Count != stack2.Count) {
                return false;
            }

            while (stack1.Count > 0) {
                char c1 = stack1.Pop();
                char c2 = stack2.Pop();
                if (c1 != c2) {
                    return false;
                }
            }

            return true;
        }
    }
}
