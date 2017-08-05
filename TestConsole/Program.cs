using System;
using Algebra.Linear_algebra.Spaces.Rational_space.Problems;
using Algebra.Linear_algebra.Spaces.Rational_space.Objects;
using Algebra.Fields_algebra.Fields;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var A1 = new Polynomial((Rational)1, 0, -1,0);
            Console.WriteLine(A1.Coefficients.ToString());
            var list = new List<Rational>(new Rational[]{
                (Rational)1, (Rational)0, (Rational)(-1), (Rational)0
            });
            Console.WriteLine((new Polynomial(list)).Coefficients.ToString());
            Console.WriteLine((new Polynomial(list.ToArray())).Coefficients.ToString());
            Console.WriteLine((new Polynomial(new Vector(list))).Coefficients.ToString());
            //Console.WriteLine(PolynomialGeneration.HermiteProbability(5).Coefficients.ToString());
            Console.ReadKey();
        }
    }
}
