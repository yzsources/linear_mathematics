using Algebra.Fields_algebra.Fields;
using System;
using System.Collections.Generic;

namespace Algebra.Linear_algebra.Spaces.Rational_space.Objects
{
    public class Vector
    {
        #region private

        /// <summary>
        /// Number of coodinates
        /// </summary>
        private int _dimension;

        /// <summary>
        /// Array of coordinates
        /// </summary>
        private Rational[] _array;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with preassigned dimension. Coordinates are zero-filled.
        /// </summary>
        /// <param name="dimension">Number of coordinates</param>
        public Vector(int dimension)
        {
            if (dimension < 1) throw
                    new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            _dimension = dimension;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = (Rational)0;
        }

        /// <summary>
        /// Constructor with preassigned dimension. First coordinates are preassigned, other coordinates are zero-filled.
        /// </summary>
        /// <param name="dimension">Number of coordinates</param>
        /// <param name="coordinates">Array of preassigned coordinates</param>
        public Vector(int dimension, params Rational[] preassignedCoordinates)
        {
            if (dimension < 1) throw
                    new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            if (preassignedCoordinates == null) throw
                       new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            _dimension = dimension;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] =
                    (preassignedCoordinates.Length > i) 
                    ? preassignedCoordinates[i].Clone() as Rational : (Rational)0;
        }


        /// <summary>
        /// Constructor with preassigned dimension. First coordinates are preassigned, other coordinates are zero-filled.
        /// </summary>
        /// <param name="dimension">Number of coordinates</param>
        /// <param name="coordinates">Array of preassigned coordinates</param>
        public Vector(int dimension, params Object[] preassignedCoordinates)
        {
            if (dimension < 1) throw
                    new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            if (preassignedCoordinates == null) throw
                       new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            _dimension = dimension;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++)
            {
                if (preassignedCoordinates[i].GetType() == typeof(Int32))
                {
                    _array[i] = (preassignedCoordinates.Length > i) 
                        ? (Rational)(int)preassignedCoordinates[i] : (Rational)0;
                }
                if (preassignedCoordinates[i].GetType() == typeof(Rational))
                {
                    _array[i] = (preassignedCoordinates.Length > i)
                        ? (Rational)preassignedCoordinates[i] : (Rational)0;
                }
            }    
        }

        /// <summary>
        /// Constructor with preassigned coordinates.
        /// </summary>
        /// <param name="preassignedCoordinates">List of preassigned coordinates</param>
        public Vector(List<Rational> preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                    new ArgumentNullException(nameof(preassignedCoordinates), "List cannot be NULL");
            if (preassignedCoordinates.Count < 1) throw
                       new ArgumentOutOfRangeException(nameof(preassignedCoordinates),
                       "Number of list elements must be positive");
            _dimension = preassignedCoordinates.Count;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = preassignedCoordinates[i].Clone() as Rational;
        }

        /// <summary>
        /// Constructor with preassigned coordinates.
        /// </summary>
        /// <param name="preassignedCoordinates">Array of preassigned coordinates</param>
        public Vector(params Rational[] preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                    new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            if (preassignedCoordinates.Length < 1) throw
           new ArgumentOutOfRangeException(nameof(preassignedCoordinates),
           "Number of array elements must be positive");
            _dimension = preassignedCoordinates.Length;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++) _array[i] = preassignedCoordinates[i].Clone() as Rational;
        }

        /// <summary>
        /// Constructor with preassigned coordinates.
        /// </summary>
        /// <param name="preassignedCoordinates">Array of preassigned coordinates</param>
        public Vector(params Object[] preassignedCoordinates)
        {
            if (preassignedCoordinates == null) throw
                    new ArgumentNullException(nameof(preassignedCoordinates), "Array cannot be NULL");
            if (preassignedCoordinates.Length < 1) throw
           new ArgumentOutOfRangeException(nameof(preassignedCoordinates),
           "Number of array elements must be positive");
            _dimension = preassignedCoordinates.Length;
            _array = new Rational[_dimension];
            for (var i = 0; i < _dimension; i++)
            {
                if(preassignedCoordinates[i].GetType()==typeof(Int32))
                    _array[i] =(Rational)(int)preassignedCoordinates[i];
                if (preassignedCoordinates[i].GetType() == typeof(Rational))
                    _array[i] = (Rational)preassignedCoordinates[i];
            }
        }

        #endregion

        #region Array methods

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < _dimension; i++) result +=
                    (_array[i].ToString() + ((i < _dimension - 1) ? "   " : ""));
            return result;
        }

        public int Dimension { get => _dimension; }

        public Rational Max
        {
            get
            {
                var result = _array[0].Clone() as Rational;
                foreach (var coordinate in _array)
                    if (result < coordinate) result = coordinate.Clone() as Rational;
                return result;
            }
        }

        public Rational Min
        {
            get
            {
                var result = _array[0].Clone() as Rational;
                foreach (var coordinate in _array)
                    if (result > coordinate) result = coordinate.Clone() as Rational;
                return result;
            }
        }

        public Rational this[int index]
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
                _array[index] = value.Clone() as Rational;
            }
        }

        public Rational[] ToArray() => _array;

        public List<Rational> ToList() => new List<Rational>(_array);

        public void ElementsReversion(int index1, int index2)
        {
            var temp = _array[index1].Clone() as Rational;
            _array[index1] = _array[index2].Clone() as Rational;
            _array[index2] = temp.Clone() as Rational;
        }

        #endregion

        #region Linear space and eucledian operations
        
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var resultDimension = (vector1.Dimension >= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = new Vector(resultDimension);
            for (var i = 0; i < resultDimension; i++)
                result[i] = ((i < vector1.Dimension) ? vector1[i] : (Rational)0) +
                    ((i < vector2.Dimension) ? vector2[i] : (Rational)0);
            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            var resultDimension = (vector1.Dimension >= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = new Vector(resultDimension);
            for (var i = 0; i < resultDimension; i++)
                result[i] = ((i < vector1.Dimension) ? vector1[i] : (Rational)0) -
                    ((i < vector2.Dimension) ? vector2[i] : (Rational)0);
            return result;
        }

        public static Vector operator *(Rational coefficient, Vector vector)
        {
            var result = new Vector(vector._array);
            for (var i = 0; i < result.Dimension; i++) result[i] *= coefficient;
            return result;
        }

        /// <summary>
        /// Returns inner product of two vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Rational operator *(Vector vector1, Vector vector2)
        {
            var resultDimension = (vector1.Dimension <= vector2.Dimension) ? vector1.Dimension : vector2.Dimension;
            var result = (Rational)0;
            for (var i = 0; i < resultDimension; i++)
                result += vector1[i] * vector2[i];
            return result;
        }

        #endregion

        #region Norms, norming

        /// <summary>
        /// Returns taxicab norm
        /// </summary>
        /// <returns></returns>
        public Rational TaxicabNorm()
        {
            var result = (Rational)0;
            foreach (var coordinate in _array)
            {
                result += Rational.Abs(coordinate);
            }
            return result;
        }

        /// <summary>
        /// Returns maximum norm or Chebishev norm
        /// </summary>
        /// <returns></returns>
        public Rational MaxNorm()
        {
            var result = (Rational)0;
            foreach (var coordinate in _array)
                if (Rational.Abs(coordinate) > result) result = Rational.Abs(coordinate);
            return result;
        }

        /// <summary>
        /// Norming vector by taxicab-norm
        /// </summary>
        public void TaxicabNorming()
        {
            if (!IfZero)
                for (var i = 0; i < _dimension; i++) _array[i] /= TaxicabNorm();
        }

        /// <summary>
        /// Returns maximum norm as default
        /// </summary>
        public Rational Norm { get => MaxNorm(); }


        /// <summary>
        /// Returns true if vector is near zero (with maximum norm)
        /// </summary>
        public bool IfZero { get => Norm == 0; }

        /// <summary>
        /// Norming vector by maximum norm
        /// </summary>
        public void Norming()
        {
            if (!IfZero)
                for (var i = 0; i < _dimension; i++) _array[i] /= MaxNorm();
        }


        /// <summary>
        /// Returns normed vector with taxicab norm
        /// </summary>
        public Vector TaxicabNormed()
        {
            var result = new Vector(_array);
            result.TaxicabNorming();
            return result;
        }

        /// <summary>
        /// Returns norm vector with maximum norm
        /// </summary>
        /// <returns></returns>
        public Vector Normed()
        {
            var result = new Vector(_array);
            result.Norming();
            return result;
        }


        #endregion

        #region Comparasion operators and methods

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var temp = obj as Vector;
            if ((object)temp == null) return false;
            return (temp - this).IfZero;
        }

        public override int GetHashCode()
        {
            return _dimension.GetHashCode() ^ _array.GetHashCode();
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return vector1.Equals(vector2);
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !vector1.Equals(vector2);
        }

        #endregion
    }
}
