using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Spaces.Complex_space.Objects;
using System;

namespace Algebra.Linear_algebra.Spaces.Complex_space.Problems
{
    public class MatrixInversion
    {
        public static Matrix ByMatrixEquation(Matrix matrix, Func<Matrix, Matrix, Matrix> method)
        {
            if (matrix.LinesCount != matrix.ColumnsCount)
                throw new ArgumentException(nameof(matrix), "Only for squared matrix");
            var dimension = matrix.LinesCount;
            var identityMatrix = new Matrix(dimension, dimension);
            for (var i = 0; i < dimension; i++) identityMatrix[i, i] = (Complex)1;
            return method(matrix, identityMatrix);
        }

        public static Matrix GaussianMethod(Matrix matrix)
        {
            if (matrix.LinesCount != matrix.ColumnsCount)
                throw new ArgumentException(nameof(matrix), "Only for squared matrix");
            var dimension = matrix.LinesCount;
            var temp = Decomposition.GaussianElimination(matrix);
            int rank = 0;
            for (rank = 0; rank < temp.Item2.LinesCount; rank++)
                if ((temp.Item2.Lines[rank]).Norm < Constants.DoublePrecision)
                    break;
            if (rank != dimension)
                throw new ArgumentException("Matrix cannot be degenerated");
            var result = new Matrix(dimension, dimension);
            for (var i = 0; i < dimension; i++) result[i, i] = (Complex)1;
            foreach (var simpleAction in temp.Item1)
            {
                switch (simpleAction.Type)
                {
                    case Enums.SimpleActionType.LinesReversion:
                        result.LinesReversion(simpleAction.FirstVector, simpleAction.SecondVector);
                        break;
                    case Enums.SimpleActionType.LineСoef:
                        for (var j = 0; j < result.ColumnsCount; j++)
                            result[simpleAction.FirstVector, j] *= simpleAction.Coefficient;
                        break;
                    case Enums.SimpleActionType.LinesSumCoef:
                        for (var j = 0; j < result.ColumnsCount; j++)
                            result[simpleAction.FirstVector, j] +=
                                simpleAction.Coefficient * result[simpleAction.SecondVector, j];
                        break;
                }
            }
            temp = Decomposition.GaussianElimination(temp.Item2, false, false);
            foreach (var simpleAction in temp.Item1)
            {
                switch (simpleAction.Type)
                {
                    case Enums.SimpleActionType.LinesReversion:
                        result.LinesReversion(simpleAction.FirstVector, simpleAction.SecondVector);
                        break;
                    case Enums.SimpleActionType.LineСoef:
                        for (var j = 0; j < result.ColumnsCount; j++)
                            result[simpleAction.FirstVector, j] *= simpleAction.Coefficient;
                        break;
                    case Enums.SimpleActionType.LinesSumCoef:
                        for (var j = 0; j < result.ColumnsCount; j++)
                            result[simpleAction.FirstVector, j] +=
                                simpleAction.Coefficient * result[simpleAction.SecondVector, j];
                        break;
                }
            }
            return result;
        }
    }
}
