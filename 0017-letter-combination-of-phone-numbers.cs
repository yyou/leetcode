using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution17 {
        private Dictionary<char, string> _dict = new Dictionary<char, string>();
        private List<string> _result = new List<string>();
        private String _path = String.Empty;

        public Solution17() {
            _dict.Add('0', "");
            _dict.Add('1', "");
            _dict.Add('2', "abc");
            _dict.Add('3', "def");
            _dict.Add('4', "ghi");
            _dict.Add('5', "jkl");
            _dict.Add('6', "mno");
            _dict.Add('7', "pqrs");
            _dict.Add('8', "tuv");
            _dict.Add('9', "wxyz");
        }

        public IList<string> LetterCombinations(string digits) {
            List<string> strings = new List<string>();
            for (var i = 0; i < digits.Length; ++i) {
                var c = digits[i];
                strings.Add(_dict[c]);
            }

            if (String.IsNullOrWhiteSpace(digits)) {
                return _result;
            }

            BackTracking(strings, 0);

            return _result;
        }

        private void BackTracking(List<string> strings, int index) {
            if (index == strings.Count) {
                _result.Add(_path);
                return;
            }

            var s = strings[index];
            for (var i = 0; i < s.Length; ++i) {
                _path = _path + s.Substring(i, 1);
                BackTracking(strings, index + 1);
                _path = _path.Substring(0, _path.Length - 1);
            }
        }
    }
}