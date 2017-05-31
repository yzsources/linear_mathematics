using linear_mathematics.Algebra_objects;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleVector vector1 = new DoubleVector(1.0, 2, 3);
            DoubleVector vector2 = new DoubleVector(4.0, 5, 6,7);
            Console.WriteLine(
                vector1*vector2
                );
            Console.ReadKey();
        }
    }
}
