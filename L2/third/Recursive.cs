using System;
using System.Collections.Generic;

namespace Third
{
    static class Recursive
    {
        /// <summary>
        /// Method finds the sequence with the least cost
        /// </summary>
        /// <param name="n">Number of warehouses</param>
        /// <param name="C">Cost matrix</param>
        /// <param name="i">Starting warehouse</param>
        /// <returns>Returns the least cost sequence</returns>
        public static List<int> FindLeastCostSequence(int n, int[][] C, int i)
        {
            if (n == i)
            {
                return new List<int>() { i };
            }

            List<int> minSequence = null;
            int minCost = int.MaxValue;

            for (int j = i + 1; j <= n; j++)
            {
                if (C[i][j] > 0) {
                    List<int> sequence = FindLeastCostSequence(n, C, j);
                    sequence.Insert(0, i);

                    int cost = CalculateCost(sequence, C);
                    if (cost < minCost) {
                        minCost = cost;
                        minSequence = sequence;
                    }
                }
            }

            return minSequence;
        }

        public static int CalculateCost(List<int> sequence, int[][] C)
        {
            int cost = 0;
            for (int i = 0; i < sequence.Count - 1; i++) {
                int from = sequence[i];
                int to = sequence[i + 1];
                cost += C[from][to];
            }
            return cost;
        }
    }
}