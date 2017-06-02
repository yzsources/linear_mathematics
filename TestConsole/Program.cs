using System;
using Algebra.Fields_algebra.Fields;
using Algebra.Fields_algebra.Problems;
using Algebra.Linear_algebra.Spaces.Real_space.Objects;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = (Rational)1 / 2;
            Console.WriteLine(IntegerCalculations.FactorialAlgorithm(0,0));
     
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
