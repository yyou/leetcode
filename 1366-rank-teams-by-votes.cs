// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution1366 {
    public static string RankTeams(string[] votes) {
        // prepare 
        var teamCount = votes[0].Length;
        var teamRanks = new Dictionary<char, int[]>();
        for (var i = 0; i < teamCount; ++i) {
            var teamName = votes[0][i];
            teamRanks[teamName] = new int[teamCount];
        }

        // populate votes
        foreach (var vote in votes) {
            for (var i = 0; i < teamCount; i++) {
                var teamName = vote[i];
                teamRanks[teamName][i]++;
            }
        }

        //sort
        var list = teamRanks.ToList();
        list.Sort((pair1, pair2) => {
            for (var i = 0; i < teamCount; ++i) {
                if (pair1.Value[i] == pair2.Value[i]) {
                    continue;
                }
                return pair2.Value[i] - pair1.Value[i];
            }

            return pair1.Key - pair2.Key;
        });

        // generate team names
        var s = new StringBuilder();
        for (var i = 0; i < list.Count; ++i) {
            s.Append(list[i].Key);
        }

        return s.ToString();
    }
}