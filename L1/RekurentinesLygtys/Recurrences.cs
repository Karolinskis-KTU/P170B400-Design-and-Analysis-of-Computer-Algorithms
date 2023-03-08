using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recurrence
{
    class Recurrences
    {
        //public int calcCalls = 0;


        // T(n) = 2*T(n/8) + n^4
        public static void R1(int[] array, int start, int end)
        {                                                       
            if (end <= 0)                                  
                return;
            for (int i = 0; i < array.Length; i++)                
                for (int j = 0; j < array.Length; j++)             
                    for (int k = 0; k < array.Length; k++)         
                        for (int l = 0; l < array.Length; l++)      
                        {
                            //calcCalls++;
                            // Mock code completion functionality
                            Thread.Sleep(1); 
                        }

            R1(array, 0, end / 8);                                
            R1(array, 0, end / 8);                              
        }

        // T(n) = T(n/5) + T(n/6) + n^2
        public static void R2(int[] a, int n)
        {                                               // Laikas | Kartai
            if (n < 6)                                  // c1     | 1
            {
                return;                                 // c2     | 1
            }

            for (int i = 0; i < a.Length; i++)          // c3     | n
                for (int j = 0; j < a.Length; j++)      // c4     | n
                {
                    continue;                           // c5     | 1
                }

            R2(a, n / 5);                               // T(n/5) | 1
            R2(a, n / 6);                               // T(n/6) | 1


        }

        // T(n) = T(n-7) + T(n-6) + n
        public static void R3(int[] a, int n)
        {                                           // Laikas | Kartai
            if (n < 7)                              // c1     | 1
            {
                return;                             // c2     | 2
            }

            for (int i = 0; i < a.Length; i++)      // c3     | n
            {
                continue;                           // c4     | 1
            }

            R3(a, n - 7);                           // T(n-7) | 1
            R3(a, n - 6);                           // T(n-6) | 1
        }

    }
}
