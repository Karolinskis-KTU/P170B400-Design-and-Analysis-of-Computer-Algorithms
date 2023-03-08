using System.Diagnostics;
using System;

namespace Recurrence.Second
{
    /// <summary>
    /// T(n) = T(n-7) + T(n-6) + n
    /// </summary>
    public class Program
    {
        private static int calcCalls;
        public static void Main(string[] args)
        {
            ThirdTest(new int[0]);
            ThirdTest(new int[1]);
            ThirdTest(new int[2]);
            ThirdTest(new int[4]);
            ThirdTest(new int[8]);
            ThirdTest(new int[16]);
            ThirdTest(new int[32]);
        }

        public static void ThirdTest(int[] array)
        {
            // Reset time
            var stopWatch = new Stopwatch();
            calcCalls = 0;

            stopWatch.Start();
            R3(array, array.Length);
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
            Console.WriteLine("Array size: {0}", array.Length);
            Console.WriteLine("Call count: {0}", calcCalls);
            Console.WriteLine("------");

        }

        public static void R3(int[] a, int n)
        {
            if (n <= 0)
                return;

            for (int i = 0; i < a.Length; i++)
                calcCalls++;

            R3(a, n - 7);
            R3(a, n - 6);
        }
    }
}
