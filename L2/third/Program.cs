using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Third
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool DEBUG = false;

            int[][][] matrices = new int[][][] {
                // 2 warehouses
                new int[][] {
                    new int[] { 0, 5 },
                    new int[] { 0, 0 }
                },
                // 3 warehouses
                new int[][] {
                    new int[] { 0, 3, 5 },
                    new int[] { 0, 0, 2 },
                    new int[] { 0, 0, 0 }
                },
                // 4 warehouses
                new int[][] {
                    new int[] { 0, 2, 3, 5 },
                    new int[] { 0, 0, 4, 6 },
                    new int[] { 0, 0, 0, 1 },
                    new int[] { 0, 0, 0, 0 }
                },
                // 5 warehouses
                new int[][] {
                    new int[] { 0, 2, 4, 6, 8 },
                    new int[] { 0, 0, 3, 5, 7 },
                    new int[] { 0, 0, 0, 2, 4 },
                    new int[] { 0, 0, 0, 0, 1 },
                    new int[] { 0, 0, 0, 0, 0 }
                },
                // 6 warehouses
                new int[][] {
                    new int[] { 0, 2, 5, 1, 7, 8 },
                    new int[] { 0, 0, 3, 2, 6, 5 },
                    new int[] { 0, 0, 0, 4, 1, 2 },
                    new int[] { 0, 0, 0, 0, 8, 7 },
                    new int[] { 0, 0, 0, 0, 0, 3 },
                    new int[] { 0, 0, 0, 0, 0, 0 }
                },
                // 8 warehouses
                new int[][] {
                    new int[] { 0, 5, 3, 8, 1, 9, 6, 4 },
                    new int[] { 0, 0, 7, 4, 6, 5, 2, 9 },
                    new int[] { 0, 0, 0, 1, 4, 8, 6, 5 },
                    new int[] { 0, 0, 0, 0, 2, 1, 3, 7 },
                    new int[] { 0, 0, 0, 0, 0, 6, 4, 8 },
                    new int[] { 0, 0, 0, 0, 0, 0, 2, 3 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 5 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }
                }
            };

            foreach (int[][] matrix in matrices)
            {
                var RECstopWatch = new Stopwatch();
                var DINstopWatch = new Stopwatch();

                RECstopWatch.Start();
                List<int> reqleastCostSequence = Recursive.FindLeastCostSequence(matrix.Length - 1, matrix, 0);
                RECstopWatch.Stop();

                DINstopWatch.Start();
                List<int> dinleastCostSequence = Dynamic.FindLeastCostSequence(matrix.Length - 1, matrix, 0);
                DINstopWatch.Stop();

                Console.WriteLine("REC Elapsed time: {0}", RECstopWatch.Elapsed.TotalMicroseconds);
                Console.WriteLine("DIN Elapsed time: {0}", DINstopWatch.Elapsed.TotalMicroseconds);


                if (DEBUG) {
                Console.WriteLine("Cost matrix:");
                for (int i = 0; i < matrix.Length; i++) {
                    Console.WriteLine(string.Join(" ", matrix[i]));
                }

                Console.WriteLine("Starting warehouse: " + 0);
                Console.WriteLine("REQ: Least-cost sequence: " + string.Join(" -> ", reqleastCostSequence));
                Console.WriteLine("Total cost: " + CalculateCost(reqleastCostSequence, matrix));
                Console.WriteLine("DIN: Least-cost sequence: " + string.Join(" -> ", dinleastCostSequence));
                Console.WriteLine("Total cost: " + CalculateCost(dinleastCostSequence, matrix));
                Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Gets the total cost of the trip from the sequence
        /// </summary>
        /// <param name="sequence">Sequence of the trip</param>
        /// <param name="C">Cost matrix</param>
        /// <returns>Returns the total cost of the trip</returns>
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