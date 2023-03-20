using System.Diagnostics;
using System;

namespace Second
{
    public class Program
    {
        private static int calcCalls;

        public static void Main(string[] args)
        {
            for (int i = 0; i <= 50; i+=2)
            {
                FirstTest(i);
            }
        }

        public static void FirstTest(int size)
        {
            var stopWatch = new Stopwatch();
            calcCalls = 0;

            stopWatch.Start();
            methodToAnalysis(size);
            stopWatch.Stop();

            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
            Console.WriteLine("Size: {0}", size);
            Console.WriteLine("Call count: {0}", calcCalls);
            Console.WriteLine("---------------------");
        }

        public static long methodToAnalysis(int n)
        {
            long k = 0;
            int[] arr = new int[n];
            Random randNum = new Random();
            calcCalls += 4;
            for (int i = 0; i < n; i++)
            {
                arr[i] = randNum.Next(0, 0);
                calcCalls++;
                k += arr[i] + FF2(i, arr);
                calcCalls++;
            }
            return k;
        }

        public static long FF2(int n, int [] arr)
        {
            calcCalls++;
            if(n > 0 && arr.Length > n && arr[n] > 0)
            {
                calcCalls++;
                return FF2(n - 1, arr) + FF2(n - 3, arr);
            }
            calcCalls++;
            return n;
        }
    }
}