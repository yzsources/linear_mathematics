using System;
using Algebra.Linear_algebra.Spaces.Rational_space.Problems;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PolynomialGeneration.HermiteProbability(5).Coefficients.ToString());
            Console.ReadKey();
        }
    }
}
