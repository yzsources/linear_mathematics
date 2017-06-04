using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Spaces.Complex_space.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Linear_algebra.Spaces.Complex_space.Problems
{
    public static class LinearSystem
    {
        #region Left matrix equation
        /// <summary>
        /// Solving matrix equation with LUP decomposition: AX=B
        /// </summary>
        /// <param name="leftSide">A - squared, not degenetated</param>
        /// <param name="rightSide">B</param>
        /// <returns></returns>
        public static Matrix LeftLUP(Matrix leftSide, Matrix rightSide)
        {
            if (leftSide.ColumnsCount != leftSide.LinesCount)
                throw new ArgumentException(nameof(leftSide), "Only for squared matrix");
            var leftSideDimension = leftSide.LinesCount;
            if (leftSideDimension != rightSide.LinesCount)
                throw new ArgumentException(nameof(rightSide), "Imcompatibility between matrixes dimensions");
            var lupResult = Decomposition.LUP(leftSide);
            for (var i = 0; i < leftSideDimension; i++)
                if (lupResult.Item2[i, i].Abs() < Constants.DoublePrecision)
                    throw new ArgumentException(nameof(leftSide), "Matrix cannot be degenerated");
            var _reversedRightSide = lupResult.Item3 * rightSide;
            var result = new Matrix(rightSide.LinesCount, rightSide.ColumnsCount);
            for (var j = 0; j < _reversedRightSide.ColumnsCount; j++)
            {
                for (int i = 0; i < leftSideDimension; i++)
                {
                    var s = (Complex)0;
                    if (i != 0)
                        for (var k = 0; k < i; k++) s += lupResult.Item1[i, k] * result[k, j];
                    result[i, j] = _reversedRightSide[i, j] - s;
                }
            }
            _reversedRightSide = result;
            for (var j = 0; j < _reversedRightSide.ColumnsCount; j++)
            {
                for (var i = leftSideDimension - 1; i >= 0; i--)
                {
                    var s = (Complex)0;
                    if (i != leftSideDimension - 1)
                        for (var k = i + 1; k < leftSideDimension; k++) s += lupResult.Item2[i, k] * result[k, j];
                    result[i, j] = (1 / lupResult.Item2[i, i]) * (_reversedRightSide[i, j] - s);
                }
            }
            return result;
        }

        #endregion

        #region Right matrix equation
        /// <summary>
        /// Solving matrix equation with LUP decomposition: XA=B
        /// </summary>
        /// <param name="leftSide">A - squared, not degenetated</param>
        /// <param name="rightSide">B</param>
        /// <returns></returns>
        public static Matrix RightLUP(Matrix leftSide, Matrix rightSide)
        {
            if (leftSide.ColumnsCount != leftSide.LinesCount)
                throw new ArgumentException(nameof(leftSide), "Only for squared matrix");
            var leftSideDimension = leftSide.LinesCount;
            if (leftSideDimension != rightSide.ColumnsCount)
                throw new ArgumentException(nameof(rightSide), "Imcompatibility between matrixes dimensions");
            var lupResult = Decomposition.LUP(leftSide);
            for (var i = 0; i < leftSideDimension; i++)
                if (lupResult.Item2[i, i].Abs() < Constants.DoublePrecision)
                    throw new ArgumentException(nameof(leftSide), "Matrix cannot be degenerated");
            var tempRightSide = rightSide;
            var result = new Matrix(rightSide.LinesCount, rightSide.ColumnsCount);
            for (var j = 0; j < tempRightSide.ColumnsCount; j++)
            {
                for (int i = 0; i < tempRightSide.LinesCount; i++)
                {
                    var s = (Complex)0;
                    if (j != 0)
                        for (var k = 0; k < j; k++) s += lupResult.Item2[k, j] * result[i, k];
                    result[i, j] = (tempRightSide[i, j] - s) / lupResult.Item2[j, j];
                }
            }
            tempRightSide = result;
            for (var j = tempRightSide.ColumnsCount - 1; j >= 0; j--)
            {
                for (var i = 0; i < tempRightSide.LinesCount; i++)
                {
                    var s = (Complex)0;
                    if (j != tempRightSide.ColumnsCount - 1)
                        for (var k = j + 1; k < tempRightSide.ColumnsCount; k++)
                            s += lupResult.Item1[k, j] * result[i, k];
                    result[i, j] = tempRightSide[i, j] - s;
                }
            }
            return result * lupResult.Item3;
        }
        #endregion

        #region Both side matrix equations
        /// <summary>
        /// Solving matrix equation with LUP decomposition: AXB=C
        /// </summary>
        /// <param name="leftSideLeft">A - squared, not degenetated</param>
        /// <param name="leftSideRight">B - squared, not degenetated</param>
        /// <param name="rightSide">C</param>
        /// <returns></returns>
        public static Matrix LUP(Matrix leftSideLeft, Matrix leftSideRight, Matrix rightSide)
        {
            return RightLUP(leftSideRight, LeftLUP(leftSideLeft, rightSide));
        }
        #endregion

    }
}
