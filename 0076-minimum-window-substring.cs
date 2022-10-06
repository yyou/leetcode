// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution {
        public string MinWindow(string s, string t) {
            var need = new int[52];
            for (var i = 0; i < t.Length; ++i) {
                var idx = GetCharIndex(t[i]);
                need[idx]++;
            }

            var start = 0;
            var minLength = Int32.MaxValue;

            var window = new int[52];
            var left = 0;
            for (var right = 0; right < s.Length; ++right) {
                var idx = GetCharIndex(s[right]);
                window[idx]++;

                if (right - left + 1 < t.Length) {
                    continue;
                }

                while (IsValidWindow(window, need)) {
                    if (right - left + 1 < minLength) {
                        start = left;
                        minLength = right - left + 1;
                    }

                    idx = GetCharIndex(s[left]);
                    window[idx]--;
                    left++;
                }
            }

            if (minLength == Int32.MaxValue) {
                return "";
            }

            return s.Substring(start, minLength);
        }

        private int GetCharIndex(char c) {
            if (Char.IsUpper(c)) {
                return c - 'A';
            } else {
                return c - 'a' + 26;
            }
        }

        private bool IsValidWindow(int[] s, int[] t) {
            for (var i = 0; i < 52; ++i) {
                if (s[i] < t[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}

