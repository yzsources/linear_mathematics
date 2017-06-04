using Algebra.Fields_algebra.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Linear_algebra.Spaces.Rational_space.Objects
{
    public class Polynomial
    {
        #region Private
        private int _degree;
        private Vector _coefficients;
        #endregion
        public int Degree { get => _degree; }
        public Vector Coefficients { get => _coefficients; }

        #region Constructors
        public Polynomial(int degree)
        {
            _degree = degree;
            _coefficients = new Vector(degree + 1);
            _coefficients[degree] = (Rational)1;
        }
        public Polynomial(List<Rational> preassignedCoefficients)
        {
            if (preassignedCoefficients == null) throw
                    new ArgumentNullException(nameof(preassignedCoefficients), "List cannot be NULL");
            if (preassignedCoefficients.Count < 1) throw
                       new ArgumentOutOfRangeException(nameof(preassignedCoefficients),
                       "Number of list elements must be positive");
            _degree = preassignedCoefficients.Count-1;
            _coefficients = new Vector(preassignedCoefficients);
        }

        public Polynomial(params Rational[] preassignedCoefficients)
        {
            if (preassignedCoefficients == null) throw
                    new ArgumentNullException(nameof(preassignedCoefficients), "Array cannot be NULL");
            if (preassignedCoefficients.Length < 1) throw
           new ArgumentOutOfRangeException(nameof(preassignedCoefficients),
           "Number of array elements must be positive");
            _degree = preassignedCoefficients.Length-1;
            _coefficients = new Vector(preassignedCoefficients);
        }

        public Polynomial(params Object[] preassignedCoefficients)
        {
            if (preassignedCoefficients == null) throw
                    new ArgumentNullException(nameof(preassignedCoefficients), "Array cannot be NULL");
            if (preassignedCoefficients.Length < 1) throw
           new ArgumentOutOfRangeException(nameof(preassignedCoefficients),
           "Number of array elements must be positive");
            _degree = preassignedCoefficients.Length - 1;
            _coefficients = new Vector(preassignedCoefficients);
        }

        public Polynomial(Vector coefficients)
        {
            _degree= coefficients.Dimension - 1;
            _coefficients = new Vector(coefficients.ToArray());
        }
        #endregion
        #region Converters

        #endregion
        #region Functions
        public double DoubleArgumentFunction(double argument)
        {
            var result = 0.0;
            var argPower = 1.0;
            for(var i = 0; i <= _degree; i++)
            {
                result += (double)_coefficients[i] * argPower;
                argPower *= argument;
            }
            return result;
        }
        #endregion

        public static Polynomial Shift(Polynomial polynomial)
        {
            var newCoefficients = new Vector(polynomial.Degree+2);
            newCoefficients[0] = (Rational)0;
            for (var i = 0; i <= polynomial.Degree; i++)
                newCoefficients[i + 1] = polynomial._coefficients[i];
            return new Polynomial(newCoefficients);
        }
        public static Polynomial operator + (Polynomial polynomial1, Polynomial polynomial2) =>
            new Polynomial(polynomial1._coefficients+polynomial2._coefficients);
        public static Polynomial operator - (Polynomial polynomial1, Polynomial polynomial2) =>
            new Polynomial(polynomial1._coefficients - polynomial2._coefficients);
        public static Polynomial operator * (Rational coefficient, Polynomial polynomial) => 
            new Polynomial(coefficient*polynomial._coefficients);
    }
}
