using linear_mathematics.Algebra_objects;
using linear_mathematics.Algebra_objects.Real_space.Problems;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Vector(1.0, 2.0, 3.0);
            var b2 = new Vector(5.0, 6.0, 3.0);
            var a1 = new Vector(3.0, 4.0, 2.0);
            var a2 = new Vector(2.0, -1.0, -3.0);
            var a3 = new Vector(1.0, 5.0, 1.0);
            var A = new Matrix(3, 3);
            A.VectorToLine(0, a1);
            A.VectorToLine(1, a2);
            A.VectorToLine(2, a3);
         //   A.VectorToLine(3, b2);
            var B = new Matrix(3, 2);
            B.VectorToColumn(0, b1);
            B.VectorToColumn(1, b2);
            var I = new Matrix(3, 3);
            I[0, 0] = I[1, 1] = I[2, 2] = 1.0;
       //     Console.WriteLine(A);
            Console.WriteLine(MatrixInversion.ByMatrixEquation(A,LinearSystem.LeftLUP));
         //   Console.WriteLine(Decomposition.ColumnGaussianElimination(A,true).Item2);
            Console.WriteLine();
        //    Console.WriteLine(Decomposition.ColumnGaussianElimination(Decomposition.RowGaussianElimination(A).Item2, false).Item2);
           Console.WriteLine(MatrixInversion.GaussianMethod(A));
            Console.WriteLine();
        //    Console.WriteLine(Decomposition.GaussianElimination(A, false, true).Item2);
            Console.ReadKey();
        }
    }
}
