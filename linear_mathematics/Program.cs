using linear_mathematics.Test_objects;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new ComplexNumber(1, 0);
            var c2 = new ComplexNumber(0, 1);
            Console.WriteLine(((ComplexNumber)(Abstract.Twice(c1)+c2)).Norm.ToString());
            Console.ReadKey();
        }
    }
}
