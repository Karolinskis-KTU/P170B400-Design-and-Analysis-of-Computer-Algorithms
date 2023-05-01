using System.Diagnostics;
using System;
using System.Xml.Linq;

namespace ThirdParalel
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
            AnalyzeBestCase(30000);
            AnalyzeBestCase(35000);
            AnalyzeBestCase(40000);
            Console.WriteLine("----------------------");
            Console.WriteLine("Worst case analysis:");
            AnalyzeWorstCase(2500);
            AnalyzeWorstCase(5000);
            AnalyzeWorstCase(10000);
            AnalyzeWorstCase(15000);
            AnalyzeWorstCase(20000);
            AnalyzeWorstCase(25000);
            AnalyzeWorstCase(30000);
            AnalyzeWorstCase(35000);
            AnalyzeWorstCase(40000);
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
            long value = methodToAnalysisLyg(array.Length, array);
            stopWatch.Stop();

            Console.WriteLine($"Array size: {array.Length}");
            Console.WriteLine($"Elapsed time (ms): {stopWatch.Elapsed.TotalMilliseconds}");
            Console.WriteLine();
        }

        public static long methodToAnalysisLyg(int n, int[] arr)
        {
            long k = 0;
            List<Task<long>> tasks = new List<Task<long>>();
            for (int i = 1; i < n; i++)
            {
                k += k;
                tasks.Add(Task.Factory.StartNew(() => FF10(i, arr)));
                tasks.Add(Task.Factory.StartNew(() => FF10(i / i, arr)));
            }
            return k + SumTasks(tasks);
        }

        public static long FF10(int n, int[] arr)
        {
            if (n > 1 && arr.Length > n)
            {
                //Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Task<long> taskLhs = Task.Factory.StartNew(() => FF10(n - 2, arr));
                Task<long> taskRhs = Task.Factory.StartNew(() => FF10(n / n, arr));
                Task.WaitAll(taskLhs, taskRhs);
                return taskLhs.Result + taskRhs.Result;
            }
            return n;
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