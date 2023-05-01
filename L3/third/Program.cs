using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace Third
{
    public class Program
    {
        private static int calcCalls;

        public static void Main(string[] args)
        {
            Console.WriteLine("Best case analysis:");
            AnalyzeBestCase(2500);
            AnalyzeBestCase(5000);
            AnalyzeBestCase(10000);
            AnalyzeBestCase(15000);
            AnalyzeBestCase(20000);
            AnalyzeBestCase(25000);
            Console.WriteLine("----------------------");
            Console.WriteLine("Worst case analysis:");
            AnalyzeWorstCase(2500);
            AnalyzeWorstCase(5000);
            AnalyzeWorstCase(10000);
            AnalyzeWorstCase(15000);
            AnalyzeWorstCase(20000);
            AnalyzeWorstCase(25000);
        }

        private static void AnalyzeBestCase(int n)
        {
            var array = GenerateCase(n, 1);
            AnalyzeMethod(array);
        }

        private static void AnalyzeWorstCase(int n)
        {
            var array = GenerateCase(n, -1);
            AnalyzeMethod(array);
        }

        private static int[] GenerateCase(int n, int num)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = num;
            }
            return result;
        }

        private static void AnalyzeMethod(int[] array)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long value = methodToAnalysis(array.Length, array);
            stopWatch.Stop();

            Console.WriteLine($"Array size: {array.Length}");
            Console.WriteLine($"Elapsed time (ms): {stopWatch.Elapsed.TotalMilliseconds}");
            Console.WriteLine();
        }

        public static long methodToAnalysis(int n, int[] arr)
        {
            long k = 0;
            for (int i = 1; i < n; i++)
            {
                k += k;
                k += FF10(i, arr);
                k += FF10(i / i, arr);
            }
            return k;
        }

        public static long FF10(int n, int[] arr)
        {
            if (n > 1 && arr.Length > n)
            {
                return FF10(n - 2, arr) + FF10(n / n, arr);
            }

            return n;
        }

    }
}