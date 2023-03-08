//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace Recurrence
//{
//    public class Benchmark
//    {
//        public int[] data;

//        [Params(10, 20, 30, 40, 50, 60, 70, 80, 90, 100)]
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
//        public void R1_Benchmark()
//        {
//            Recurrences.R1(data, data.Length);
//        }

//        [Benchmark]
//        public void R2_Benchmark()
//        {
//            Recurrences.R2(data, data.Length);
//        }

//        [Benchmark]
//        public void R3_Benchmark()
//        {
//            Recurrences.R3(data, data.Length);
//        }

//    }

//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var summary = BenchmarkRunner.Run<Benchmark>();
//        }
//    }
//}
