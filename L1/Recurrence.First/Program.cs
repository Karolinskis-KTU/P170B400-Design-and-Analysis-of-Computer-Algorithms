using System.Diagnostics;
using System;

namespace Recurrence.First
{
    /// <summary>
    /// T(n) = 2*T(n/8) + n^4
    /// </summary>
    public class Program
    {
        private static int calcCalls;
        public static void Main(string[] args)
        {
            FirstTest(new int[0]);
            FirstTest(new int[1]);
            FirstTest(new int[2]);
            FirstTest(new int[4]);
            FirstTest(new int[8]);
            FirstTest(new int[16]);
            FirstTest(new int[32]);
        }

        public static void FirstTest(int[] array)
        {
            // Reset time
            var stopWatch = new Stopwatch();
            calcCalls = 0;

            stopWatch.Start();
            R1(array, array.Length);
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
            Console.WriteLine("Array size: {0}", array.Length);
            Console.WriteLine("Call count: {0}", calcCalls);
            Console.WriteLine("------");

        }

        public static void R1(int[] array, int n)
        {
            if (n <= 0)
                return;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    for (int k = 0; k < array.Length; k++)
                        for (int l = 0; l < array.Length; l++)
                        {
                            calcCalls++;
                        }

            R1(array, n / 8);
            R1(array, n / 8);
        }
    }
}
