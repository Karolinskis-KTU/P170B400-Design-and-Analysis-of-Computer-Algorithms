using Lab1;
using System;
using System.Diagnostics;
using System.Drawing;

namespace Lab1
{
    internal class Program
    {
        public static int calcCalls;

        static void Main(string[] args)
        {
            int[] sizes = { 0, 500};
            calcCalls = 0;

            for (int i = 0; i < sizes.Length; i++)
            {
                calcCalls = 0;
                var stopWatch = new Stopwatch();
                Renderer Render = new Renderer("Result", (uint)sizes[i], (uint)sizes[i], 0xFFFFFFFF);
                stopWatch.Start();

                Recursive(Render, sizes[i] / 2, sizes[i] / 2, sizes[i], 3);
                stopWatch.Stop();
                Render.Write();


                Console.WriteLine("Image size: {0}x{1}", sizes[i], sizes[i]);
                Console.WriteLine("Call count: {0}", calcCalls);
                Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed.TotalMicroseconds);
                Console.WriteLine("--------");

            }

        }

        enum GenerationMask
        {
            None = 0,
            Top = 1 << 0,
            Left = 1 << 1,
            Bottom = 1 << 2,
            Right = 1 << 3,
            Mask_All = Top | Left | Right | Bottom
        }

        static void SimpleShape(Renderer render, double X, double Y, double Size, GenerationMask Mask)
        {

            double Portion = Size / 5;

            if ((Mask & GenerationMask.Top) != 0)
                render.DrawLine(X - Portion * 0.5, Y + Portion * 2.5, X + Portion * 0.5, Y + Portion * 2.5, 0.5, 0); // Upper square top line

            render.DrawLine(X - Portion * 0.5, Y + Portion * 1.5, X - Portion * 0.5, Y + Portion * 2.5, 0.5, 0); // Upper square left line
            render.DrawLine(X + Portion * 0.5, Y + Portion * 1.5, X + Portion * 0.5, Y + Portion * 2.5, 0.5, 0); // Upper square right line

            render.DrawLine(X - Portion * 1.5, Y + Portion * 1.5, X - Portion * 0.5, Y + Portion * 1.5, 0.5, 0); // Upper mid left square top line
            render.DrawLine(X - Portion * 1.5, Y + Portion * 1.5, X - Portion * 1.5, Y + Portion * 0.5, 0.5, 0); // Upper mid left square left line

            render.DrawLine(X + Portion * 0.5, Y + Portion * 1.5, X + Portion * 1.5, Y + Portion * 1.5, 0.5, 0); // Upper mid right square top line
            render.DrawLine(X + Portion * 1.5, Y + Portion * 1.5, X + Portion * 1.5, Y + Portion * 0.5, 0.5, 0); // Upper mid right square right line

            render.DrawLine(X + Portion * 1.5, Y + Portion * 0.5, X + Portion * 2.5, Y + Portion * 0.5, 0.5, 0); // Mid right square top line

            if ((Mask & GenerationMask.Right) != 0)
                render.DrawLine(X + Portion * 2.5, Y + Portion * 0.5, X + Portion * 2.5, Y - Portion * 0.5, 0.5, 0); // Mid right square right line

            render.DrawLine(X + Portion * 2.5, Y - Portion * 0.5, X + Portion * 1.5, Y - Portion * 0.5, 0.5, 0); // Mid right square bottom line

            render.DrawLine(X - Portion * 1.5, Y + Portion * 0.5, X - Portion * 2.5, Y + Portion * 0.5, 0.5, 0); // Mid left square top line

            if ((Mask & GenerationMask.Left) != 0)
                render.DrawLine(X - Portion * 2.5, Y + Portion * 0.5, X - Portion * 2.5, Y - Portion * 0.5, 0.5, 0); // Mid left square left line

            render.DrawLine(X - Portion * 2.5, Y - Portion * 0.5, X - Portion * 1.5, Y - Portion * 0.5, 0.5, 0); // Mid left square bottom line

            render.DrawLine(X - Portion * 1.5, Y - Portion * 0.5, X - Portion * 1.5, Y - Portion * 1.5, 0.5, 0); // Lower mid left square left line
            render.DrawLine(X - Portion * 1.5, Y - Portion * 1.5, X - Portion * 0.5, Y - Portion * 1.5, 0.5, 0); // Lower mid left square bottom line

            render.DrawLine(X + Portion * 1.5, Y - Portion * 0.5, X + Portion * 1.5, Y - Portion * 1.5, 0.5, 0); // Lower mid right square right line
            render.DrawLine(X + Portion * 0.5, Y - Portion * 1.5, X + Portion * 1.5, Y - Portion * 1.5, 0.5, 0); // Lower mid right square bottom line

            render.DrawLine(X - Portion * 0.5, Y - Portion * 1.5, X - Portion * 0.5, Y - Portion * 2.5, 0.5, 0); // Lower square left line

            if ((Mask & GenerationMask.Bottom) != 0)
                render.DrawLine(X - Portion * 0.5, Y - Portion * 2.5, X + Portion * 0.5, Y - Portion * 2.5, 0.5, 0); // Lower square bottom line

            render.DrawLine(X + Portion * 0.5, Y - Portion * 1.5, X + Portion * 0.5, Y - Portion * 2.5, 0.5, 0); // Lower square left line
        }

        static void Recursive(Renderer render, double X, double Y, double Size, uint ParentTo, GenerationMask ConnectionMask = GenerationMask.Mask_All)
        {                    
            if (ParentTo == 0)                                                                               
            {
                SimpleShape(render, X, Y, Size, ConnectionMask);                                          
                return;                                                                                          
            }

            double CurrentIteration = (1 << (byte)ParentTo) * 5.0 + ((1 << (byte)ParentTo) - 1) * 3.0;              
            double LastIteration = (1 << (byte)(ParentTo - 1)) * 5.0 + ((1 << (byte)(ParentTo - 1)) - 1) * 3.0;  

            double Distance = Size * ((LastIteration / 2.0 + 1.5) / CurrentIteration);                           
            double NewSize = Size * (LastIteration / CurrentIteration);                                                     

            SimpleShape(render, X, Y, Size * (5 / CurrentIteration), GenerationMask.None);                                  

            if ((ConnectionMask & GenerationMask.Right) == 0)                                                                
                Recursive(render, X + Distance, Y, NewSize, ParentTo - 1, GenerationMask.Top | GenerationMask.Bottom);        
            else                                                                                                              
                Recursive(render, X + Distance, Y, NewSize, ParentTo - 1, GenerationMask.Mask_All & ~GenerationMask.Left);    

            if ((ConnectionMask & GenerationMask.Left) == 0)                                                                  
                Recursive(render, X - Distance, Y, NewSize, ParentTo - 1, GenerationMask.Top | GenerationMask.Bottom);        
            else                                                                                                               
                Recursive(render, X - Distance, Y, NewSize, ParentTo - 1, GenerationMask.Mask_All & ~GenerationMask.Right);    

            if ((ConnectionMask & GenerationMask.Top) == 0)                                                                     
                Recursive(render, X, Y + Distance, NewSize, ParentTo - 1, GenerationMask.Right | GenerationMask.Left);        
            else                                                                                                              
                Recursive(render, X, Y + Distance, NewSize, ParentTo - 1, GenerationMask.Mask_All & ~GenerationMask.Bottom);    

            if ((ConnectionMask & GenerationMask.Bottom) == 0)                                                                 
                Recursive(render, X, Y - Distance, NewSize, ParentTo - 1, GenerationMask.Right | GenerationMask.Left);        
            else                                                                                                                
                Recursive(render, X, Y - Distance, NewSize, ParentTo - 1, GenerationMask.Mask_All & ~GenerationMask.Top);  
            
        }
    }
}
