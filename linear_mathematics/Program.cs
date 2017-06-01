﻿using linear_mathematics.Algebra_objects;
using linear_mathematics.Algebra_objects.Real_space.Problems;
using System;

namespace linear_mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector(1.0, 2.0, 3.0);
            var v2 = new Vector(4.0, 5.0, 6.0);
            var v3 = new Vector(7.0, 8.0, 9.0);
            var v4 = new Vector(10.0, 11.0, 12.0);
            var matrix = new Matrix(4, 3);
            matrix.VectorToLine(0, v1);
            matrix.VectorToLine(1, v2);
            matrix.VectorToLine(2, v3);
            matrix.VectorToLine(3, v4);
            Console.WriteLine(matrix);
            Console.WriteLine();
            var hauss = Decomposition.GaussianElimination(matrix.Transposed);
            Console.WriteLine(hauss.Item2);
            Console.ReadKey();
        }
    }
}
