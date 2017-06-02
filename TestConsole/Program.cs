using System;
using Algebra.Fields_algebra.Fields;
using Algebra.Fields_algebra.Problems;
using Algebra.Linear_algebra.Spaces.Rational_space.Objects;
using Algebra.Linear_algebra.Spaces.Rational_space.Problems;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new Vector((Rational)3, 1, -2);
            var a2 = new Vector((Rational)(-3), 15, 1);
            var a3 = new Vector((Rational)5, -1, 9);
            var a = new Matrix(3, 3);
            a.VectorToLine(0, a1);
            a.VectorToLine(1, a2);
            a.VectorToLine(2, a2);
            Console.WriteLine(Decomposition.LUP(a).Item2);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
