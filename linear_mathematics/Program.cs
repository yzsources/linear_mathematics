using linear_mathematics.Algebra_objects;
using linear_mathematics.Algebra_objects.Real_space.Problems;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector(1.0, 2.0, 3.0);
            var v2 = new Vector(3.0, 4.0, 5.0);
            var v3 = new Vector(6.0, 8.0, 10.0);
            var matrix = new Matrix(3, 3);
            matrix.VectorToLine(0, v1);
            matrix.VectorToLine(1, v2);
            matrix.VectorToLine(2, v3);
            Console.WriteLine(matrix);
            var lup = Decomposition.LUP(matrix);
            Console.WriteLine();
            Console.WriteLine(lup.Item1);
            Console.WriteLine();
            Console.WriteLine(lup.Item2);
            Console.WriteLine();
            Console.WriteLine(lup.Item3);
            Console.WriteLine();
            Console.WriteLine((lup.Item1 * lup.Item2 ).ToString());
            Console.WriteLine();
            Console.WriteLine((lup.Item3*matrix).ToString());
            Console.ReadKey();
        }
    }
}
