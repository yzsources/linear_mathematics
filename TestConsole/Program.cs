using System;
using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Spaces.Complex_space.Objects;
using Algebra.Linear_algebra.Spaces.Complex_space.Problems;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new Vector(new Complex(0, 1), 1);
            var a2 = new Vector(new Complex(-1, 1), 2);
            var A = new Matrix(2, 2);
            A.VectorToLine(0, a1);
            A.VectorToLine(1, a2);
            Console.WriteLine(A);
            Console.WriteLine();
            Console.WriteLine(MatrixInversion.ByMatrixEquation(A,LinearSystem.LeftLUP));
            Console.WriteLine();
            Console.WriteLine(MatrixInversion.GaussianMethod(A));
            Console.WriteLine();
            Console.WriteLine(MatrixInversion.GaussianMethod(A)*A);
            Console.ReadKey();
        }
    }
}
