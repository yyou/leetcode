using System;

namespace leetcode {
    public class Solution383 {
        public bool CanConstruct(string ransomNote, string magazine) {
            var magazineDict = new ItemCountDictionary<Char>();
            for (var i = 0; i < magazine.Length; ++i) {
                var c = magazine[i];
                magazineDict[c]++;
            }

            var ransomNoteDict = new ItemCountDictionary<Char>();
            for (var i = 0; i < ransomNote.Length; ++i) {
                var c = ransomNote[i];
                ransomNoteDict[c]++;
            }

            foreach (var entry in ransomNoteDict) {
                if (!magazineDict.ContainsKey(entry.Key) ||
                    ransomNoteDict[entry.Key] > magazineDict[entry.Key]) {
                    return false;
                }
            }

            return true;
        }
    }
}