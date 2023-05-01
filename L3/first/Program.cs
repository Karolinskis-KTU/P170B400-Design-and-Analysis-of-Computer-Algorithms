using System.Diagnostics;
using System;

namespace First
{
    public class Program
    {
        private static int calcCalls;

        public static void Main(string[] args)
        {
            List<int[,]> matrixes = new List<int[,]>
            {
                new int[,]
                {
                    {1, 1 },
                    {1, 1 }
                },
                new int[,]
                {
                    {1, 3, 3 },
                    {2, 3, 3 },
                    {1, 2, 4 }
                },
                new int[,]
                {
                    { 4, 4, 4, 3 },
                    { 4, 4, 4, 3 },
                    { 4, 4, 4, 3 },
                    { 5, 5, 5, 5 }
                },
                new int[,]
                {
                    { 5, 5, 5, 5, 3 },
                    { 5, 5, 5, 5, 3 },
                    { 5, 5, 5, 5, 3 },
                    { 5, 5, 5, 5, 3 },
                    { 6, 6, 6, 6, 6 }
                },
                new int[,]
                {
                    { 6, 6, 6, 6, 6, 7},
                    { 6, 6, 6, 6, 6, 7},
                    { 6, 6, 6, 6, 6, 7},
                    { 6, 6, 6, 6, 6, 7},
                    { 6, 6, 6, 6, 6, 7},
                    { 1, 2, 3, 4, 5, 7}
                },
                new int[,]
                {
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 7, 7, 7, 7, 7, 7, 8 },
                    { 0, 1, 3, 4, 6, 9, 8 }
                },
                new int[,]
                {
                    { 2, 2, 2, 2, 1, 2, 4, 3 },
                    { 2, 2, 2, 2, 1, 2, 4, 3 },
                    { 2, 2, 2, 2, 1, 2, 4, 3 },
                    { 2, 2, 2, 2, 1, 2, 4, 3 },
                    { 5, 5, 5, 1, 3, 5, 6, 7 },
                    { 5, 5, 5, 1, 3, 5, 6, 7 },
                    { 5, 5, 5, 1, 3, 5, 6, 7 },
                    { 2, 2, 2, 1, 3, 5, 6, 7 },
                },
                new int[,]
                {
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 7, 7, 7, 7, 7, 7, 8, 8, 8 },
                    { 0, 1, 3, 4, 6, 9, 8, 7, 7 },
                    { 0, 1, 3, 4, 6, 9, 8, 7, 7 },
                }
            };

            foreach (var matrix in matrixes)
            {
                var RECstopWatch = new Stopwatch();
                var DINstopWatch = new Stopwatch();

                RECstopWatch.Start();
                int maxK = FindMaxSubMatrix(matrix, matrix.GetLength(0));
                RECstopWatch.Stop();
                
                DINstopWatch.Start();
                int maxKDP = FindMaxSubMatrixDP(matrix, matrix.GetLength(0));
                DINstopWatch.Stop();

                Console.WriteLine("REC Elapsed time: {0}", RECstopWatch.Elapsed.TotalNanoseconds);
                Console.WriteLine("DIN Elapsed time: {0}", DINstopWatch.Elapsed.TotalNanoseconds);
                Console.WriteLine();
            }



            //int maxKDP = FindMaxSubMatrixDP(matrix, matrix.GetLength(0));
            //Console.WriteLine("Atsakymas " + maxKDP);
        }

        private static int FindMaxSubMatrix(int[,] matrix, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int prevMaxK = FindMaxSubMatrix(matrix, n - 1);
            int maxK = prevMaxK;

            for (int i = 0; i <= matrix.GetLength(0) - n; i++)
            {
                for (int j = 0; j <= matrix.GetLength(1) - n; j++)
                {
                    if (IsSubMatrixAllEqual(matrix, n, i, j))
                    {
                        maxK = n;
                        break;
                    }
                }
                if (maxK > prevMaxK)
                {
                    break;
                }
            }

            return maxK;
        }

        private static bool IsSubMatrixAllEqual(int[,] matrix, int n, int i0, int j0)
        {
            int value = matrix[i0, j0];

            for (int i = i0; i < i0 + n; i++)
            {
                for (int j = j0; j < j0 + n; j++)
                {
                    if (matrix[i, j] != value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static int FindMaxSubMatrixDP(int[,] matrix, int n)
        {
            int[,] dp = new int[n, n];
            int maxK = 1;

            // initialize first row and column of dp
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 1;
                dp[0, i] = 1;
            }

            // fill dp
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i, j] == matrix[i - 1, j] && matrix[i, j] == matrix[i, j - 1] && matrix[i, j] == matrix[i - 1, j - 1])
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        maxK = Math.Max(maxK, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = 1;
                    }
                }
            }

            return maxK;
        }
    }
}