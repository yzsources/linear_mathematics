using linear_mathematics.Algebra_objects;
using linear_mathematics.Algebra_objects.Real_space.Problems;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Vector(1.0, 2.0);
            var b2 = new Vector(5.0, 6.0);
            var a1 = new Vector(3.0, 4.0, 2.0);
            var a2 = new Vector(2.0, -1.0, -3.0);
            var a3 = new Vector(1.0, 5.0, 1.0);
            var A = new Matrix(3, 3);
            A.VectorToLine(0, a1);
            A.VectorToLine(1, a2);
            A.VectorToLine(2, a3);
            var B = new Matrix(2, 2);
            B.VectorToLine(0, b1);
            B.VectorToLine(1, b2);
            var x1 = new Vector(-1.0, 4.0);
            var x2 = new Vector(2.5, 12.0);
            var x3 = new Vector(-15.0, 2.0);
            var X = new Matrix(3, 2);
            X.VectorToLine(0, x1);
            X.VectorToLine(1, x2);
            X.VectorToLine(2, x3);
            var C = A * X * B;
            Console.WriteLine(X);
            Console.WriteLine();
               Console.WriteLine(LinearSystem.LUP(A,B,C));
           // Console.WriteLine(B.Rank());
            Console.ReadKey();
        }
    }
}
