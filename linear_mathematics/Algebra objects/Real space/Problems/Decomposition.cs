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
        /// <returns>L - lower triangular with 1, U - upper triangular, P - transposition matrix, reversions count</returns>
        public static Tuple<Matrix, Matrix, Matrix, int> LUP(Matrix matrix)
        {
            if (matrix.LinesCount != matrix.ColumnsCount) throw
                       new ArgumentException(nameof(matrix), "Only for squared matrix");
            var dimension = matrix.LinesCount;
            var U = new Matrix(matrix.ToArray());
            var L = new Matrix(dimension, dimension);
            var P = new Matrix(dimension, dimension);
            var reversionsCount = 0;
            for (var i = 0; i < dimension; i++) L[i, i] = P[i, i] = 1;
            var maxElementIndex = 0;
            for (var i = 0; i < dimension - 1; i++)
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
                    reversionsCount++;
                }
                for (var j = i + 1; j < dimension; j++)
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
            return new Tuple<Matrix, Matrix, Matrix, int>(L, U, P, reversionsCount);
        }

        /// <summary>
        /// Gaussian row elimination for matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>List of simple actions and result matrix</returns>
        public static Tuple<List<SimpleAction>, Matrix> GaussianElimination(Matrix matrix, bool maxElementFinding = true, bool upper = true)
        {
            var result = new Matrix(matrix.ToArray());
            var simpleActions = new List<SimpleAction>();
            var stepCount = (result.LinesCount > result.ColumnsCount) ? result.ColumnsCount : result.LinesCount;
            var linesCount = result.LinesCount;
            var columnsCount = result.ColumnsCount;
            for (var i = 0; i < stepCount; i++)
            {
                var currentLineIndex = (upper) ? i : linesCount - 1 - i;
                var currentColumnIndex = (upper) ? i : columnsCount - 1 - i;
                var mainElementIndex = (upper)?i:linesCount-1-i;
                if (maxElementFinding)
                {
                    for(var linesStep = i; linesStep < result.LinesCount; linesStep++)
                    {
                        var linesIndex = (upper) ? linesStep : linesCount - linesStep - 1;
                        mainElementIndex = (Math.Abs(result[linesIndex, currentColumnIndex]) > 
                            Math.Abs(result[mainElementIndex, currentColumnIndex])) ? linesIndex : mainElementIndex;
                    }
                }
                else
                {
                    for (var linesStep = i; linesStep < result.LinesCount; linesStep++)
                    {
                        var linesIndex = (upper) ? linesStep : linesCount - linesStep - 1;
                        if (Math.Abs(result[linesIndex, currentColumnIndex]) > Constants.DoublePrecision)
                        {
                            mainElementIndex = linesIndex;
                            break;
                        }
                    }
                }
                if (Math.Abs(result[mainElementIndex, currentColumnIndex]) < Constants.DoublePrecision)
                    continue;
                if (currentLineIndex != mainElementIndex)
                {
                    result.LinesReversion(currentLineIndex, mainElementIndex);
                    simpleActions.Add(new SimpleAction(Enums.SimpleActionType.LinesReversion, currentLineIndex, mainElementIndex));
                }
                var coefficient1 = (1 / result[currentLineIndex, currentColumnIndex]);
                for (var columnsStep = i; columnsStep < columnsCount; columnsStep++)
                {
                    var columnsIndex = (upper) ? columnsStep : columnsCount - columnsStep - 1;
                    result[currentLineIndex, columnsIndex] *= coefficient1;
                }  
                simpleActions.Add(new SimpleAction(Enums.SimpleActionType.LineСoef, currentLineIndex, coefficient1));
                for (var linesStep = i + 1; linesStep< result.LinesCount; linesStep++)
                {
                    var linesIndex = (upper) ? linesStep : linesCount - linesStep - 1;
                    var coefficient2 = -result[linesIndex, currentColumnIndex];
                    for (var columnsStep = i; columnsStep < result.ColumnsCount; columnsStep++)
                    {
                        var columnsIndex = (upper) ? columnsStep : columnsCount - columnsStep - 1;
                        result[linesIndex, columnsIndex] += coefficient2 * result[currentLineIndex, columnsIndex];
                    }
                    simpleActions.Add(
                        new SimpleAction(Enums.SimpleActionType.LinesSumCoef, linesIndex, currentLineIndex, coefficient2)
                        );
                }
            }
            return new Tuple<List<SimpleAction>, Matrix>(simpleActions, result);
        }

      
    }
}
