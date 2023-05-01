using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace Second
{
    public class Program
    {
        private static int calcCalls;

        public static void Main(string[] args)
        {
            Console.WriteLine("Best case analysis:");
            AnalyzeBestCase(2500000);
            AnalyzeBestCase(5000000);
            AnalyzeBestCase(10000000);
            AnalyzeBestCase(20000000);
            AnalyzeBestCase(40000000);
            Console.WriteLine("----------------------");
            Console.WriteLine("Worst case analysis:");
            AnalyzeWorstCase(500);
            AnalyzeWorstCase(1000);
            AnalyzeWorstCase(1500);
            AnalyzeWorstCase(2000);
            AnalyzeWorstCase(2500);
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
            long value = methodToAnalysisLyg(array);
            stopWatch.Stop();

            Console.WriteLine($"Array size: {array.Length}");
            Console.WriteLine($"Elapsed time (ms): {stopWatch.Elapsed.TotalNanoseconds}");
            Console.WriteLine();
        }

        public static long methodToAnalysisLyg(int[] arr)
        {
            long n = arr.Length;
            long k = n;
            List<Task<long>> tasks = new List<Task<long>>();

            if (arr[0] < 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i > 0)
                    {
                        tasks.Add(Task.Factory.StartNew(() => InnerLoop(n)));
                    }
                }
            }
            Task.WaitAll(tasks.ToArray());
            return k + SumTasks(tasks);
        }

        private static long SumTasks(List<Task<long>> tasks)
        {
            long value = 0;
            foreach (Task<long> task in tasks)
                value += task.Result;

            return value;
        }

        private static long InnerLoop(long n)
        {
            long k = 0;
            for (int j = 0; j < n; j++)
            {
                k -= 2;
            }
            return k;
        }
    }
}