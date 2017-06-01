using linear_mathematics.Algebra_objects.Real_space.Extra_objects;
using System;
using System.Collections.Generic;

namespace linear_mathematics.Algebra_objects.Real_space.Problems
{
    public static class Decomposition
    {
        /// <summary>
        /// LUP decomposition, where PA=LU
        /// </summary>
        /// <param name="matrix">Squared matrix</param>
        /// <returns>L - lower triangular with 1, U - upper triangular, P - transposition matrix</returns>
        public static Tuple<Matrix,Matrix,Matrix> LUP(Matrix matrix)
        {
            if (matrix.LinesCount != matrix.ColumnsCount) throw
                       new ArgumentException(nameof(matrix), "Only for squared matrix");
            var dimension = matrix.LinesCount;
            var U = new Matrix(matrix.ToArray());
            var L = new Matrix(dimension, dimension);
            var P = new Matrix(dimension, dimension);
            for (var i = 0; i < dimension; i++) L[i, i] = P[i, i] = 1;
            var maxElementIndex = 0;
            for(var i = 0; i < dimension; i++)
            {
                maxElementIndex = i;
                for (var j = i; j < dimension; j++)
                    maxElementIndex = (Math.Abs(U[j, i]) > Math.Abs(U[maxElementIndex, i])) ? j : maxElementIndex;
                if (Math.Abs(U[maxElementIndex, i]) < Constants.DoublePrecision)
                    continue;
                if (i != maxElementIndex)
                {
                    U.LinesReversion(i, maxElementIndex);
                    P.LinesReversion(i, maxElementIndex);
                }
                for(var j = i + 1; j < dimension; j++)
                {
                    U[j, i] /= U[i, i];
                    for (int k = i + 1; k < dimension; k++)
                        U[j, k] -= U[j, i] * U[i, k];
                }
            }
            for (var i = 0; i < dimension; i++)
                for (var j = 0; j < i; j++)
                {
                    L[i, j] = U[i, j];
                    U[i, j] = 0;
                }
            return new Tuple<Matrix, Matrix, Matrix>(L, U, P);
        }

        /// <summary>
        /// Gaussian Elimination for matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>List of simple actions and result matrix</returns>
        public static Tuple<List<SimpleAction>,Matrix> GaussianElimination(Matrix matrix)
        {
            var result = new Matrix(matrix.ToArray());
            var simpleActions = new List<SimpleAction>();
            var stepCount = (result.LinesCount > result.ColumnsCount) ? result.ColumnsCount : result.LinesCount;
            var maxElementIndex = 0;
            for (var i = 0; i < stepCount-1; i++)
            {
                maxElementIndex = i;
                for (var j = i; j < result.LinesCount; j++)
                    maxElementIndex = (Math.Abs(result[j, i]) > Math.Abs(result[maxElementIndex, i])) ?
                        j : maxElementIndex;
                if (Math.Abs(result[maxElementIndex, i]) < Constants.DoublePrecision)
                    continue;
                if (i != maxElementIndex)
                {
                    result.LinesReversion(i, maxElementIndex);
                    simpleActions.Add(new SimpleAction(Enums.SimpleActionType.LineReversion, i, maxElementIndex));
                }
                for(var j = i + 1; j < result.LinesCount; j++)
                {
                    var coefficient = -result[j, i] / result[i, i];
                    for (var k = i; k < result.ColumnsCount; k++)
                        result[j, k] += coefficient * result[i, k];
                    simpleActions.Add(new SimpleAction(Enums.SimpleActionType.LineSumCoef, j, i, coefficient));
                }
            }
            return new Tuple<List<SimpleAction>, Matrix>(simpleActions,result);
        }
    }
}
