using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution322 {
        public int CoinChange(int[] coins, int amount) {
            var memo = new Dictionary<int, int>();
            return CoinChangeImpl(coins, amount, memo);
        }

        private int CoinChangeImpl(Int32[] coins, int amount, Dictionary<int, int> memo) {
            if (amount == 0) {
                return 0;
            }

            if (amount < 0) {
                return -1;
            }

            if (memo.ContainsKey(amount)) {
                return memo[amount];
            }

            var coinCount = Int32.MaxValue;

            foreach (var coin in coins) {
                var subCoinCount = CoinChangeImpl(coins, amount - coin, memo);
                if (subCoinCount == -1) {
                    continue;
                }

                coinCount = Math.Min(coinCount, subCoinCount + 1);
            }

            if (coinCount == Int32.MaxValue) {
                memo[amount] = -1;
                return -1;
            }

            memo[amount] = coinCount;
            return coinCount;
        }
    }
}
