using System;
using System.Collections.Generic;
using System.Linq;

public class Solution438
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var need = new Dictionary<Char, Int32>();
        var window = new Dictionary<Char, Int32>();

        for (var i = 0; i < p.Length; ++i)
        {
            if (need.ContainsKey(p[i]))
            {
                need[p[i]]++;
            }
            else
            {
                need[p[i]] = 1;
            }
        }

        int left = 0, right = 0;
        int valid = 0;
        var startLocations = new List<Int32>();

        while (right < s.Length)
        {
            char c = s[right];
            right++;

            if (need.ContainsKey(c))
            {
                if (window.ContainsKey(c))
                {
                    window[c]++;
                }
                else
                {
                    window[c] = 1;
                }

                if (window[c] == need[c])
                {
                    valid++;
                }
            }

            while (right - left >= p.Length)
            {

                char d = s[left];
                left++;

                if (valid == need.Count)
                {
                    startLocations.Add(left - 1);
                }

                if (need.ContainsKey(d))
                {
                    if (window[d] == need[d])
                    {
                        valid--;
                    }

                    window[d]--;
                }
            }
        }

        return startLocations;
    }
}