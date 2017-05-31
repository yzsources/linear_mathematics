using System;

namespace linear_mathematics.Algebra_objects
{
    public class DoubleMatrix
    {

        #region private

        /// <summary>
        /// Number of lines
        /// </summary>
        private int _linesCount;

        /// <summary>
        /// Number of columns
        /// </summary>
        private int _columnsCount;

        /// <summary>
        /// Array of matrix values
        /// </summary>
        private double[,] _array;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with preassigned dimension. Elements are zero-filled.
        /// </summary>
        /// <param name="linesCount">Number of lines</param>
        /// <param name="columnsCount">Number of columns</param>
        public DoubleMatrix(int linesCount, int columnsCount)
        {
            if (linesCount < 1) throw
                    new ArgumentOutOfRangeException(nameof(linesCount),"Count of lines must be positive");
            if (columnsCount < 1) throw
                     new ArgumentOutOfRangeException(nameof(columnsCount), "Count of columns must be positive");
            _linesCount = linesCount;
            _columnsCount = columnsCount;
            _array = new double[_linesCount, _columnsCount];
            for (var i = 0; i < _linesCount; i++)
                for (var j = 0; j < _columnsCount; j++) _array[i, j] = 0;
        }

        /// <summary>
        /// Constructor with preassigned dimension. First elements are preassigned, other elements are zero-filled.
        /// </summary>
        /// <param name="linesCount">Number of lines</param>
        /// <param name="columnsCount">Number of columns</param>
        /// <param name="preassignedCoordinates">Array of preassigned elements</param>
        public DoubleMatrix(int linesCount, int columnsCount, double[,] preassignedCoordinates)
        {
            if (linesCount < 1) throw
                    new ArgumentOutOfRangeException(nameof(linesCount), "Count of lines must be positive");
            if (columnsCount < 1) throw
                    new ArgumentOutOfRangeException(nameof(columnsCount), "Count of columns must be positive");
            if (preassignedCoordinates == null) throw
                       new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            _linesCount = linesCount;
            _columnsCount = columnsCount;
            _array = new double[_linesCount, _columnsCount];
            for (var i = 0; i < _linesCount; i++)
                for (var j = 0; j < _columnsCount; j++) _array[i, j] =
                               (i < preassignedCoordinates.GetLength(0) && j < preassignedCoordinates.GetLength(1)) ?
                               preassignedCoordinates[i, j] : 0;
        }

        /// <summary>
        /// Constructor with preassigned elements
        /// </summary>
        /// <param name="preassignedCoordinates">Array of preassigned elements</param>
        public DoubleMatrix(double[,] preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                       new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            _linesCount = preassignedCoordinates.GetLength(0);
            _columnsCount = preassignedCoordinates.GetLength(1);
            _array = new double[_linesCount, _columnsCount];
            for (var i = 0; i < _linesCount; i++)
                for (var j = 0; j < _columnsCount; j++) _array[i, j] = preassignedCoordinates[i, j];
        }

        #endregion

        #region Array methods

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _linesCount; i++)
                for (var j = 0; j < _columnsCount; j++)
                    result += _array[i, j].ToString() + ((j<_columnsCount-1)?" ":((i<_linesCount-1)? "\r\n":""));
            return result;
        }

        public int LinesCount { get => _linesCount; }

        public int ColumnsCount { get => _columnsCount; }

        public double this[int lineIndex, int columnIndex]
        {
            get
            {
                if (lineIndex < 0 || lineIndex >= _linesCount) throw
                        new ArgumentOutOfRangeException(nameof(lineIndex), "Index is out of range");
                if (columnIndex < 0 || columnIndex >= _columnsCount) throw
                        new ArgumentOutOfRangeException(nameof(columnIndex), "Index is out of range");
                return _array[lineIndex, columnIndex];
            }
            set
            {
                if (lineIndex < 0 || lineIndex >= _linesCount) throw
                        new ArgumentOutOfRangeException(nameof(lineIndex), "Index is out of range");
                if (columnIndex < 0 || columnIndex >= _columnsCount) throw
                        new ArgumentOutOfRangeException(nameof(columnIndex), "Index is out of range");
                _array[lineIndex, columnIndex] = value;
            }
        }

        public double[,] ToArray() => _array;

        public DoubleVector[] Lines
        {
            get
            {
                var result = new DoubleVector[_linesCount];
                for(var i = 0; i < _linesCount; i++)
                {
                    result[i] = new DoubleVector(_columnsCount);
                    for (var j = 0; j < _columnsCount; j++) result[i][j] = _array[i, j];
                }
                return result;
            }
        }

        public DoubleVector[] Columns
        {
            get
            {
                var result = new DoubleVector[_columnsCount];
                for(var j = 0; j < _columnsCount; j++)
                {
                    result[j] = new DoubleVector(_linesCount);
                    for (var i = 0; i < _linesCount; i++) result[j][i] = _array[i, j];
                }
                return result;
            }
        }

        public void VectorToLine(int lineIndex, DoubleVector vector)
        {
            if (lineIndex < 0 || lineIndex >= _linesCount) throw
                    new ArgumentOutOfRangeException(nameof(lineIndex), "Index is out of range");
            for (var j = 0; j < _columnsCount; j++)
                _array[lineIndex, j] = (j < vector.Dimension) ? vector[j] : 0;
        }

        public void VectorToColumn(int columnIndex, DoubleVector vector)
        {
            if (columnIndex < 0 || columnIndex >= _columnsCount) throw
                    new ArgumentOutOfRangeException(nameof(columnIndex), "Index is out of range");
            for (var i = 0; i < _linesCount; i++)
                _array[i, columnIndex] = (i < vector.Dimension) ? vector[i] : 0;
        }

        public void LinesReversion(int lineIndex1, int lineIndex2)
        {
            var temp = Lines[lineIndex1];
            VectorToLine(lineIndex1, Lines[lineIndex2]);
            VectorToLine(lineIndex2, temp);
        }

        public void ColumnsReversion(int columnIndex1, int columnIndex2)
        {
            var temp = Columns[columnIndex1];
            VectorToColumn(columnIndex1, Columns[columnIndex2]);
            VectorToColumn(columnIndex2, temp);
        }

        /// <summary>
        /// Returns maximum of lines minimums
        /// </summary>
        public double MaxMin
        {
            get
            {
                var result = Lines[0].Min;
                foreach(var line in Lines)
                {
                    result = (result < line.Min) ? line.Min : result;
                }
                return result;
            }
        }


        /// <summary>
        /// Returns minimum of columns maximums
        /// </summary>
        public double MinMax
        {
            get
            {
                var result = Columns[0].Max;
                foreach(var column in Columns)
                {
                    result = (result < column.Max) ? column.Max : result;
                }
                return result;
            }
        }

        #endregion

        #region Linear space operations

        public static DoubleMatrix operator + (DoubleMatrix matrix1, DoubleMatrix matrix2)
        {
            var resultColumnsCount = (matrix1.ColumnsCount >= matrix2.ColumnsCount) ? 
                matrix1.ColumnsCount : matrix2.ColumnsCount;
            var resultLinesCount = (matrix1.LinesCount >= matrix2.LinesCount) ?
                matrix1.LinesCount : matrix2.LinesCount;
            var result = new DoubleMatrix(resultLinesCount, resultColumnsCount);
            for (var i = 0; i < resultLinesCount; i++)
                for (var j = 0; j < resultColumnsCount; j++)
                    result[i, j] = ((i < matrix1.LinesCount && j < matrix1.ColumnsCount) ? matrix1[i, j] : 0) +
                        ((i < matrix2.LinesCount && j < matrix2.ColumnsCount) ? matrix2[i, j] : 0);
            return result;
        }

        public static DoubleMatrix operator - (DoubleMatrix matrix1, DoubleMatrix matrix2)
        {
            var resultColumnsCount = (matrix1.ColumnsCount >= matrix2.ColumnsCount) ?
                matrix1.ColumnsCount : matrix2.ColumnsCount;
            var resultLinesCount = (matrix1.LinesCount >= matrix2.LinesCount) ?
                matrix1.LinesCount : matrix2.LinesCount;
            var result = new DoubleMatrix(resultLinesCount, resultColumnsCount);
            for (var i = 0; i < resultLinesCount; i++)
                for (var j = 0; j < resultColumnsCount; j++)
                    result[i, j] = ((i < matrix1.LinesCount && j < matrix1.ColumnsCount) ? matrix1[i, j] : 0) -
                        ((i < matrix2.LinesCount && j < matrix2.ColumnsCount) ? matrix2[i, j] : 0);
            return result;
        }

        public static DoubleMatrix operator * (double coefficient, DoubleMatrix matrix)
        {
            var result = new DoubleMatrix(matrix._array);
            for (var i = 0; i < result._linesCount; i++)
                for (var j = 0; j < result._columnsCount; j++) result[i, j] *= coefficient;
            return result;
        }

        public static DoubleMatrix operator * (DoubleMatrix matrix1, DoubleMatrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.LinesCount) throw
                       new ArgumentException("Columns count of 1st matrix must be equal to lines count of 2nd matrix");
            var resultColumnsCount = matrix2.ColumnsCount;
            var resultLinesCount = matrix1.LinesCount;
            var result = new DoubleMatrix(resultLinesCount, resultColumnsCount);
            for (var i = 0; i < resultLinesCount; i++)
                for (var j = 0; j < resultColumnsCount; j++)
                    result[i, j] = matrix1.Lines[i] * matrix2.Columns[j];
            return result;
        }

        public static DoubleVector operator * (DoubleMatrix matrix, DoubleVector vector)
        {
            if (matrix.ColumnsCount != vector.Dimension) throw
                     new ArgumentException("Columns count of matrix must be equal to elements count of vector");
            var resultDimension = matrix.LinesCount;
            var result = new DoubleVector(resultDimension);
            for (var i = 0; i < resultDimension; i++)
                result[i] = matrix.Lines[i] * vector;
            return result;
        }

        public DoubleMatrix Transposed
        {
            get
            {
                var result = new DoubleMatrix(_columnsCount, _linesCount);
                for(var i = 0; i < _linesCount; i++)
                {
                    result.VectorToColumn(i,Lines[i]);
                }
                return result;
            }
        }

        public double Trace
        {
            get
            {
                var mainDiagonalLength = (_linesCount > _columnsCount) ? _columnsCount : _linesCount;
                var result = 0.0;
                for (int i = 0; i < mainDiagonalLength; i++) result += _array[i, i];
                return result;
            }
        }

        public DoubleMatrix LeftSqr { get => this * Transposed; }

        public DoubleMatrix RightSqr { get => Transposed * this; }

        #endregion

        #region Norms 

        /// <summary>
        /// Operator p-norm, where p=1 
        /// </summary>
        /// <returns></returns>
        public double MNorm()
        {
            var result = 0.0;
            foreach(var column in Columns)
            {
                result = (result < column.PNorm(1)) ? column.PNorm(1) : result;
            }
            return result;
        }

        /// <summary>
        /// Operator p-norm, where p=inf
        /// </summary>
        /// <returns></returns>
        public double LNorm()
        {
            var result = 0.0;
            foreach(var line in Lines)
            {
                result = (result < line.PNorm(1)) ? line.PNorm(1) : result;
            }
            return result;
        }

        /// <summary>
        /// Vector p-norm
        /// </summary>
        /// <returns></returns>
        public double PNorm(double p)
        {
            if (p < 1) throw
                   new ArgumentOutOfRangeException(nameof(p), "Argument cannot be less than 1");
            var result = 0.0;
            for(var i=0;i<_linesCount;i++)
                for(var j=0;j<_columnsCount;j++) result+= Math.Pow(Math.Abs(_array[i,j]), p);
            return Math.Pow(result, 1 / p);
        }

        // TODO: Add spectral norm (Operator p-norm, where p=2)
        
        /// <summary>
        /// Special L_p,q norm
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public double PQNorm(double p, double q)
        {
            if (p < 1) throw
                  new ArgumentOutOfRangeException(nameof(p), "Argument cannot be less than 1");
            if (q < 1) throw
                  new ArgumentOutOfRangeException(nameof(q), "Argument cannot be less than 1");
            var result = 0.0;
            foreach(var column in Columns)
            {
                result += Math.Pow(Math.Abs(column.PNorm(p)),q);
            }
            return Math.Pow(result, 1 / q);
        }

        /// <summary>
        /// Maximum norm
        /// </summary>
        /// <returns></returns>
        public double MaxNorm()
        {
            var result = 0.0;
            for (var i = 0; i < _linesCount; i++)
                for (var j = 0; j < _columnsCount; j++) result = (Math.Abs(_array[i, j]) > result) ? Math.Abs(_array[i, j]) : result;
            return result;
        }

        /// <summary>
        /// Frobenius norm
        /// </summary>
        public double FNorm { get => PNorm(2); } 

        /// <summary>
        /// Maximum norm as default
        /// </summary>
        public double Norm { get => MaxNorm(); }

        /// <summary>
        /// Norm as an error function in robust data analysis 
        /// </summary>
        public double RobustNorm { get => PQNorm(2, 1); }

        /// <summary>
        /// Returns true if matrix is near zero (with maximum norm)
        /// </summary>
        public bool IfZero { get => Norm < Constants.DoublePrecision; }

        #endregion

        #region Comparasion operators and methods

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var temp = obj as DoubleMatrix;
            if ((object)temp == null) return false;
            return (temp - this).IfZero;
        }

        public override int GetHashCode()
        {
            return _linesCount.GetHashCode() ^ _columnsCount.GetHashCode() ^ _array.GetHashCode();
        }

        public static bool operator == (DoubleMatrix matrix1, DoubleMatrix matrix2)
        {
            return matrix1.Equals(matrix2);
        }

        public static bool operator != (DoubleMatrix matrix1, DoubleMatrix matrix2)
        {
            return !matrix1.Equals(matrix2);
        }

        #endregion
    }
}
