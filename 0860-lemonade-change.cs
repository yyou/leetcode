// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution860 {
        public bool LemonadeChange(int[] bills) {
            int fives = 0;
            int tens = 0;

            for (var i = 0; i < bills.Length; ++i) {
                switch (bills[i]) {
                    case 5:
                        fives++;
                        break;
                    case 10:
                        if (fives <= 0) {
                            return false;
                        }
                        fives--;
                        tens++;
                        break;
                    case 20:
                        if (fives > 0 && tens > 0) {
                            fives--;
                            tens--;
                        } else if (fives >= 3) {
                            fives -= 3;
                        } else {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
    }
}
