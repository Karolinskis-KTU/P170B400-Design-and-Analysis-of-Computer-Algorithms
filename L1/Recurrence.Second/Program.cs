using System.Diagnostics;
using System;

namespace Recurrence.Second
{
    /// <summary>
    /// T(n) = T(n/5) + T(n/6) + n^2
    /// </summary>
    public class Program
    {
        private static int calcCalls;
        public static void Main(string[] args)
        {
            SecondTest(new int[0]);
            SecondTest(new int[1]);
            SecondTest(new int[2]);
            SecondTest(new int[4]);
            SecondTest(new int[8]);
            SecondTest(new int[16]);
            SecondTest(new int[32]);
        }

        public static void SecondTest(int[] array)
        {
            // Reset time
            var stopWatch = new Stopwatch();
            calcCalls = 0;

            stopWatch.Start();
            R2(array, array.Length);
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
            Console.WriteLine("Array size: {0}", array.Length);
            Console.WriteLine("Call count: {0}", calcCalls);
            Console.WriteLine("------");

        }

        public static void R2(int[] array, int n)
        {
            if (n <= 0)
                return;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                {
                    calcCalls++;
                }

            R2(array, n / 5);
            R2(array, n / 6);
        }
    }
}
