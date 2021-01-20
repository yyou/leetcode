using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class Solution
    {
        public int OpenLock(string[] deadends, string target)
        {
            var deads = new HashSet<String>(deadends);

            var visited = new HashSet<String>();
            visited.Add("0000");

            Queue<String> q = new Queue<string>();
            q.Enqueue("0000");

            var steps = 0;

            while (q.Count() != 0)
            {
                var count = q.Count();
                for (var i = 0; i < count; ++i)
                {
                    var currentLock = q.Dequeue();

                    if (deads.Contains(currentLock))
                    {
                        continue;
                    }

                    if (currentLock == target)
                    {
                        return steps;
                    }

                    for (var j = 0; j < 4; j++)
                    {
                        var addedOne = AddOne(currentLock, j);
                        if (!visited.Contains(addedOne))
                        {
                            q.Enqueue(addedOne);
                            visited.Add(addedOne);
                        }

                        var minusOne = MinusOne(currentLock, j);
                        if (!visited.Contains(minusOne))
                        {
                            q.Enqueue(minusOne);
                            visited.Add(minusOne);
                        }
                    }

                    visited.Add(currentLock);
                }

                steps++;
            }

            return -1;
        }

        private String AddOne(String s, Int32 index)
        {
            char[] chs = s.ToCharArray();
            if (chs[index] == '9')
            {
                chs[index] = '0';
            }
            else
            {
                chs[index]++;
            }
            return new String(chs);
        }

        private String MinusOne(String s, Int32 index)
        {
            char[] chs = s.ToCharArray();
            if (chs[index] == '0')
            {
                chs[index] = '9';
            }
            else
            {
                chs[index]--;
            }
            return new String(chs);
        }
    }
}
