using System;
using System.Collections.Generic;

namespace linear_mathematics.Algebra_objects
{

    public class DoubleVector
    {

        #region private

        /// <summary>
        /// Number of coodinates
        /// </summary>
        private int _dimension;

        /// <summary>
        /// Array of coordinates
        /// </summary>
        private double[] _array;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with preassigned dimension. Coordinates are zero-filled.
        /// </summary>
        /// <param name="dimension">Number of coordinates</param>
        public DoubleVector(int dimension)
        {
            if (dimension < 1) throw
                    new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            _dimension = dimension;
            _array = new double[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = 0;
        }

        /// <summary>
        /// Constructor with preassigned dimension. First coordinates are preassigned, other coordinates are zero-filled.
        /// </summary>
        /// <param name="dimension">Number of coordinates</param>
        /// <param name="coordinates">Array of preassigned coordinates</param>
        public DoubleVector(int dimension, params double[] preassignedCoordinates)
        {
            if (dimension < 1) throw
                    new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            if (preassignedCoordinates == null) throw
                       new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            _dimension = dimension;
            _array = new double[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] =
                    (preassignedCoordinates.Length > i) ? preassignedCoordinates[i] : 0;
        }

        /// <summary>
        /// Constructor with preassigned coordinates.
        /// </summary>
        /// <param name="preassignedCoordinates">List of preassigned coordinates</param>
        public DoubleVector(List<double> preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                    new ArgumentNullException(nameof(preassignedCoordinates), "List cannot be NULL");
            if (preassignedCoordinates.Count < 1) throw
                       new ArgumentOutOfRangeException(nameof(preassignedCoordinates),
                       "Number of list elements must be positive");
            _dimension = preassignedCoordinates.Count;
            _array = new double[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = preassignedCoordinates[i];
        }

        /// <summary>
        /// Constructor with preassigned coordinates.
        /// </summary>
        /// <param name="preassignedCoordinates">Array of preassigned coordinates</param>
        public DoubleVector(params double[] preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                    new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            if (preassignedCoordinates.Length < 1) throw
           new ArgumentOutOfRangeException(nameof(preassignedCoordinates),
           "Number of array elements must be positive");
            _dimension = preassignedCoordinates.Length;
            _array = new double[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = preassignedCoordinates[i];
        }

        #endregion

        #region Array methods

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _dimension; i++) result +=
                    (_array[i].ToString() + ((i < _dimension - 1) ? " " : ""));
            return result;
        }

        public int Dimension { get => _dimension; }

        public double Max
        {
            get
            {
                var result = _array[0];
                foreach (var coordinate in _array)
                {
                    result = (result < coordinate) ? coordinate : result;
                }
                return result;
            }
        }

        public double Min
        {
            get
            {
                var result = _array[0];
                foreach (var coordinate in _array)
                {
                    result = (result > coordinate) ? coordinate : result;
                }
                return result;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _dimension)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                return _array[index];
            }

            set
            {
                if (index < 0 || index >= _dimension)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                _array[index] = value;
            }
        }

        public double[] ToArray() => _array;

        public List<double> ToList() => new List<double>(_array);

        public void ElementsReversion(int index1, int index2)
        {
            double temp = _array[index1];
            _array[index1] = _array[index2];
            _array[index2] = temp;
        }

        #endregion

        #region Linear space and eucledian operations

        public static DoubleVector operator +(DoubleVector vector1, DoubleVector vector2)
        {
            var resultDimension = (vector1.Dimension >= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = new DoubleVector(resultDimension);
            for (var i = 0; i < resultDimension; i++)
                result[i] = ((i < vector1.Dimension) ? vector1[i] : 0) +
                    ((i < vector2.Dimension) ? vector2[i] : 0);
            return result;
        }

        public static DoubleVector operator -(DoubleVector vector1, DoubleVector vector2)
        {
            var resultDimension = (vector1.Dimension >= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = new DoubleVector(resultDimension);
            for (var i = 0; i < resultDimension; i++)
                result[i] = ((i < vector1.Dimension) ? vector1[i] : 0) -
                    ((i < vector2.Dimension) ? vector2[i] : 0);
            return result;
        }

        public static DoubleVector operator *(double coefficient, DoubleVector vector)
        {
            var result = new DoubleVector(vector._array);
            for (var i = 0; i < result.Dimension; i++) result[i] *= coefficient;
            return result;
        }

        /// <summary>
        /// Returns inner product of two vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double operator *(DoubleVector vector1, DoubleVector vector2)
        {
            var resultDimension = (vector1.Dimension <= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = 0.0;
            for (var i = 0; i < resultDimension; i++)
                result += vector1[i] * vector2[i];
            return result;
        }

        #endregion

        #region Norms, norming

        /// <summary>
        /// Returns p-norm or Holder-space norm
        /// </summary>
        /// <param name="p">Index of Holder-space. (For Eucledian space p=2)</param>
        /// <returns></returns>
        public double PNorm(double p)
        {
            if (p < 1) throw 
                    new ArgumentOutOfRangeException(nameof(p), "Argument cannot be less than 1");
            var result = 0.0;
            foreach(var coordinate in _array)
            {
                result += Math.Pow(Math.Abs(coordinate),p);
            }
            return Math.Pow(result, 1 / p);
        }

        /// <summary>
        /// Returns maximum norm or Chebishev norm
        /// </summary>
        /// <returns></returns>
        public double MaxNorm()
        {
            var result = 0.0;
            foreach (var coordinate in _array)
            {
                result = (Math.Abs(coordinate) > result) ? Math.Abs(coordinate) : result;
            }
            return result;
        }

        /// <summary>
        /// Norming vector by p-norm
        /// </summary>
        /// <param name="p">Index of Holder-space. (For Eucledian space p=2)</param>
        public void PNorming(double p)
        {
            if (p < 1) throw
                    new ArgumentOutOfRangeException(nameof(p), "Argument cannot be less than 1");
            if (!IfZero)
                for (var i = 0; i < _dimension; i++) _array[i] /= PNorm(p);
        }

        /// <summary>
        /// Returns maximum norm as default
        /// </summary>
        public double Norm { get => MaxNorm(); }

        /// <summary>
        /// Returns euclidean norm
        /// </summary>
        public double EuclideanNorm { get => PNorm(2); }

        /// <summary>
        /// Returns true if vector is near zero (with maximum norm)
        /// </summary>
        public bool IfZero { get => Norm < Constants.DoublePrecision; }

        /// <summary>
        /// Norming vector by maximum norm
        /// </summary>
        /// <param name="p"></param>
        public void Norming()
        {
            if (!IfZero)
                for (var i = 0; i < _dimension; i++) _array[i] /= MaxNorm();
        }

        /// <summary>
        /// Norming vector by eucledian norm
        /// </summary>
        public void EucledianNorming()
        {
            if (!IfZero)
                for (var i = 0; i < _dimension; i++) _array[i] /= PNorm(2);
        }

        /// <summary>
        /// Returns normed vector with p-norm
        /// </summary>
        /// <param name="p">Index of Holder-space. (For Eucledian space p=2)</param>
        public DoubleVector PNormed(double p)
        {
            if (p < 1) throw
                    new ArgumentOutOfRangeException(nameof(p), "Argument cannot be less than 1");
            var result = new DoubleVector(_array);
            result.PNorming(p);
            return result;
        }

        /// <summary>
        /// Returns norm vector with maximum norm
        /// </summary>
        /// <returns></returns>
        public DoubleVector Normed()
        {
            var result = new DoubleVector(_array);
            result.Norming();
            return result;
        }

        /// <summary>
        /// Returns norm vector with Eucledian norm
        /// </summary>
        /// <returns></returns>
        public DoubleVector EucledianNormed()
        {
            var result = new DoubleVector(_array);
            result.EucledianNorming();
            return result;
        }

        #endregion

        #region Comparasion operators and methods

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var temp = obj as DoubleVector;
            if ((object)temp == null) return false;
            return (temp - this).IfZero;
        }

        public override int GetHashCode()
        {
            return _dimension.GetHashCode() ^ _array.GetHashCode();
        }

        public static bool operator ==(DoubleVector vector1, DoubleVector vector2)
        {
            return vector1.Equals(vector2);
        }

        public static bool operator !=(DoubleVector vector1, DoubleVector vector2)
        {
            return !vector1.Equals(vector2);
        }

        #endregion

    }
}
