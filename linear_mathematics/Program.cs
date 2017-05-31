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
            DoubleMatrix matrix1 = new DoubleMatrix(4, 2);
            matrix1.VectorToColumn(0, vector1);
            matrix1.VectorToColumn(1, vector2);
            DoubleMatrix matrix2 = new DoubleMatrix(5, 5, matrix1.ToArray());
            Console.WriteLine((matrix1*(matrix1.Transposed)).ToString());
            Console.ReadKey();
        }
    }
}
