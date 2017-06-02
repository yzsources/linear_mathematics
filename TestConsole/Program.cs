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
            //       var a1 = new Vector((Rational)3, 1, -2);
            //       var a2 = new Vector((Rational)(-3), 15, 1);
            //      var a3 = new Vector((Rational)5, -1, 9);
            ///      var a = new Matrix(3, 3);
            //     a.VectorToLine(0, a1);
            //     a.VectorToLine(1, a2);
            //    a.VectorToLine(2, a2);
            //   Console.WriteLine(Decomposition.LUP(a).Item2);
            var a = new Complex[8];
            a[0] = new Complex(1);
            a[1] = new Complex(-1);
            a[2] = new Complex(0, 1);
            a[3] = new Complex(0, -1);
            a[4] = new Complex(1, 2);
            a[5] = new Complex(-1, 4);
            a[6] = new Complex(-4, -2);
            a[7] = new Complex(3, -5);
            foreach (var tata in a) Console.WriteLine(Complex.Arg(tata));
            Console.ReadKey();
        }
    }
}
