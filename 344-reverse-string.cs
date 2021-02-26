using System.Linq;

namespace leetcode {
    public class Solution344 {
        public void ReverseString(char[] s) {
            var i = 0;
            var j = s.Count() - 1;

            while (i < j) {
                var tmp = s[i];
                s[i] = s[j];
                s[j] = tmp;
                i++;
                j--;
            }
        }
    }
}