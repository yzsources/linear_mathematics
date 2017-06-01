using System;

namespace linear_mathematics.Algebra_objects.Real_space.Problems
{
    public static class LinearSystem
    {
        #region Left matrix equation
        /// <summary>
        /// Solving matrix equation with LUP decomposition: AX=B
        /// </summary>
        /// <param name="leftMatrix">A - squared, not degenetated left matrix</param>
        /// <param name="rightMatrix">B - right matrix</param>
        /// <returns></returns>
        public static Matrix LeftLUP(Matrix leftMatrix, Matrix rightMatrix)
        {
            if (leftMatrix.ColumnsCount != leftMatrix.LinesCount)
                throw new ArgumentException(nameof(leftMatrix), "Only for squared matrix");
            var linesCount = leftMatrix.LinesCount;
            var lupResult = Decomposition.LUP(leftMatrix);
            for (var i = 0; i < linesCount; i++)
                if (Math.Abs(lupResult.Item2[i, i]) < Constants.DoublePrecision)
                    throw new ArgumentException(nameof(leftMatrix), "Matrix cannot be degenerated");
            var _reversedRightMatrix = lupResult.Item3 * rightMatrix;
            var result = new Matrix(rightMatrix.LinesCount, rightMatrix.ColumnsCount);
            var resultCurrentColumn = new Vector(rightMatrix.LinesCount);
            for (var j = 0; j < _reversedRightMatrix.ColumnsCount; j++)
            {
                for (int i = 0; i < linesCount; i++)
                {
                    var s = 0.0;
                    if (i != 0)
                        for (var k = 0; k < i; k++) s += lupResult.Item1[i, k] * resultCurrentColumn[k];
                    resultCurrentColumn[i] = _reversedRightMatrix[i, j] - s;
                }
                result.VectorToColumn(j, resultCurrentColumn);
            }
            _reversedRightMatrix = result;
            for (var j = 0; j < _reversedRightMatrix.ColumnsCount; j++)
            {
                for (var i = linesCount - 1; i >= 0; i--)
                {
                    var s = 0.0;
                    if (i != linesCount - 1)
                        for (var k = i + 1; k < linesCount; k++) s += lupResult.Item2[i, k] * resultCurrentColumn[k];
                    resultCurrentColumn[i] = (1 / lupResult.Item2[i, i]) * (_reversedRightMatrix[i, j] - s);
                }
                result.VectorToColumn(j, resultCurrentColumn);
            }
            return result;
        }
        #endregion

    }
}
