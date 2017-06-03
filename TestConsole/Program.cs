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
            var a=new Rational(2,1);
            var b = a.Clone();
            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
