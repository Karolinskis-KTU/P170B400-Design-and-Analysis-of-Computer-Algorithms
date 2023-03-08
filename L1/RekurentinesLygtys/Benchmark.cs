//using BenchmarkDotNet.Attributes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Recurrence
//{
//    public class Benchmark
//    {
//        private int[] data;

//        [Params(1000, 10000)]
//        public int N;

//        [GlobalSetup]
//        public void Setup()
//        {
//            data = new int[N];
//            int Min = 0;
//            int Max = 20;
//            Random randNum = new Random();
//            data = Enumerable
//                .Repeat(0, data.Length)
//                .Select(i => randNum.Next(Min, Max))
//                .ToArray();
//        }

//        [Benchmark]
//        public static void R1_Benchmark(int[] a)
//        {
//            Recurrences.R1(a, a.Length);
//        }

//        [Benchmark]
//        public static void R2_Benchmark(int[] a)
//        {
//            Recurrences.R2(a, a.Length);
//        }

//        [Benchmark]
//        public static void R3_Benchmark(int[] a)
//        {
//            Recurrences.R3 (a, a.Length);
//        }

//    }

//    public class
//}
