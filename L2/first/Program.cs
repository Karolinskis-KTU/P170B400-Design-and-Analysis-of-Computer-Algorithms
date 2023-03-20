using System.Diagnostics;
using System;

namespace First
{
    public class Program
    {
        private static int calcCalls;

        public static void Main(string[] args)
        {
            List<int> sizes = new List<int>()
            {
                2,4,8,16,32,64,128,256,512
            };

            foreach (int size in sizes)
            {
                int[] array = RandomArray(size);
                FirstTest(array);
            }
        }

        public static void FirstTest(int[] array)
        {
            var stopWatch = new Stopwatch();
            calcCalls = 0;

            stopWatch.Start();
            methodToAnalysis(array);
            stopWatch.Stop();

            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
            Console.WriteLine("Array size: {0}", array.Length);
            Console.WriteLine("Call count: {0}", calcCalls);
            Console.WriteLine("---------------------");
        }

        public static int[] RandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(size);
            }

            return array;
        }

        public static long methodToAnalysis(int[] arr)
        {
            long n = arr.Length;
            long k = n;
            for (int i = 0; i < n*2; i++)
            {
                for(int j = 0; j < n/2; j++)
                {
                    k -=2;
                    calcCalls++;
                }
            }
            return k;
        }
    }
}