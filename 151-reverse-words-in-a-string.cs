using System.Linq;
using System;

namespace leetcode {
    public class Solution151 {
        public string ReverseWords(string s) {
            var c = s.ToCharArray();
            RemoveExtraSpaces(ref c);
            ReverseWords(c);
            Reverse(c, 0, c.Length - 1);
            return new String(c);
        }

        private void RemoveExtraSpaces(ref char[] c) {
            var slow = 0;
            var fast = 0;

            // Skip the leading spaces
            while (fast < c.Length && c[fast] == ' ') {
                fast++;
            }

            while (fast < c.Length) {
                if (c[fast] != ' ') {
                    c[slow++] = c[fast++];
                    continue;
                }

                if (c[fast - 1] != ' ') {
                    c[slow++] = c[fast++];
                } else {
                    fast++;
                }
            }

            // Remove the trailing space
            if (c[slow - 1] == ' ') {
                slow--;
            }

            Array.Resize(ref c, slow);
        }

        private void Reverse(char[] c, int start, int end) {
            var i = start;
            var j = end;
            while (i < j) {
                var tmp = c[i];
                c[i] = c[j];
                c[j] = tmp;
                i++;
                j--;
            }
        }

        private void ReverseWords(char[] c) {
            var start = 0;
            var len = c.Count();
            while (start < len) {
                var end = start;
                while (end < len && c[end] != ' ') {
                    end++;
                }
                end--;
                Reverse(c, start, end);

                start = end + 2;
            }
        }
    }
}