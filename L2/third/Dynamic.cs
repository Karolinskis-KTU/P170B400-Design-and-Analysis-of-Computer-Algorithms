using System;
using System.Collections.Generic;

namespace Third
{
    static class Dynamic
    {
        public static List<int> FindLeastCostSequence(int n, int[][] C, int start)
        {
            int[] dp = new int[n + 1];
            int[] prev = new int[n + 1];

            for (int i = start + 1; i <= n; i++) {
                dp[i] = int.MaxValue;
            }

            for (int j = start + 1; j <= n; j++) {
                for (int i = start; i < j; i++) {
                    if (C[i][j] != int.MaxValue && dp[j] > dp[i] + C[i][j]) {
                        dp[j] = dp[i] + C[i][j];
                        prev[j] = i;
                    }
                }
            }

            // Check if there is a valid path to the end node
            if (dp[n] == int.MaxValue) {
                return null;
            }

            // Trace back the path to the start node
            List<int> sequence = new List<int>();
            int cur = n;
            while (cur != start) {
                sequence.Add(cur);
                cur = prev[cur];
            }
            sequence.Add(start);

            // Reverse the path to get the correct order
            sequence.Reverse();
            return sequence;
        }
    }
}