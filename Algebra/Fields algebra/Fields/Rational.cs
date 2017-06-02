using Algebra.Fields_algebra.Problems;
using System;

namespace Algebra.Fields_algebra.Fields
{
    public class Rational
    {
        #region Private
        private int _numerator;
        private int _denominator;
        private static Func<int, int, int> _gcdAlgorithm = IntegerCalculations.EuclideanAlgorithm;
        private static Func<int, int, UInt64> _exponentiationAlgorythm = IntegerCalculations.BySquaringAlgorithm;
        private void _reduct()
        {
            var gcd = _gcdAlgorithm(_numerator, _denominator);
            var sign = (_numerator >= 0) ^ (_denominator > 0);
            _numerator = (sign) ? -Math.Abs(_numerator) / gcd : Math.Abs(_numerator) / gcd;
            _denominator = Math.Abs(_denominator) / gcd;
        }
        #endregion

        #region Constructors and gcd algorithm settings
        public Rational()
        {
            _numerator = 0;
            _denominator = 1;
        }
        public Rational(int integerNumber)
        {
            _numerator = integerNumber;
            _denominator = 1;
        }
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0) throw
                       new DivideByZeroException("Denominator cannot be equal to zero");
            _numerator = numerator;
            _denominator = denominator;
            _reduct();
        }
        public static void SetGCDAlgorithm(Func<int, int, int> gcdAlgorithm)
        {
            _gcdAlgorithm = gcdAlgorithm;
        }
        public static void SetExponentiationAlgorithm(Func<int,int,UInt64> exponentiationAlgorythm)
        {
            _exponentiationAlgorythm = exponentiationAlgorythm;
        }
        #endregion

        #region Properties
        public int Numerator { get => _numerator; }
        public int Denominator { get => _denominator; }
        #endregion

        #region Static math functions
        public static int Sign(Rational number) => Math.Sign(number._numerator);
        public static Rational Floor(Rational number) => new Rational(
            (number._numerator >= 0) ? number._numerator / number._denominator
            : ((-number._numerator) / number._denominator -
            (((-number._numerator) % number._denominator == 0) ? 1 : 0)
            ));
        public static Rational Ceiling(Rational number) => new Rational(
            (number._numerator <= 0) ? (-number._numerator) / number._denominator
            : number._numerator / number._denominator +
            ((number._numerator % number._denominator == 0) ? 1 : 0)
            );
        public static Rational Fractional(Rational number) => number -
            ((number._numerator >= 0) ? Floor(number) : Ceiling(number));
        public static Rational Abs(Rational number) =>
            (number._numerator >= 0) ? new Rational(number._numerator, number._denominator) :
            new Rational(-number._numerator, number._denominator);
        public static Rational Sqr(Rational number) => number * number;
        public static Rational Pow(Rational number, int exponent) =>
            (exponent > 0) ? new Rational((int)_exponentiationAlgorythm(number._numerator, Math.Abs(exponent)),
                (int)_exponentiationAlgorythm(number._denominator, Math.Abs(exponent))) :
            1 / new Rational((int)_exponentiationAlgorythm(number._numerator, Math.Abs(exponent)),
                (int)_exponentiationAlgorythm(number._denominator, Math.Abs(exponent)));

        #endregion

        #region Converters
        public double ToDouble() => (double)_numerator / _denominator;
        public override string ToString() => _numerator.ToString() + " / " + _denominator.ToString();
        public static explicit operator double(Rational number) => number.ToDouble();
        public static explicit operator Rational(int number) => new Rational(number);
        #endregion

        #region Arithmetic operators
        public static Rational operator - (Rational number) 
            => new Rational(-number._numerator,number._denominator);
        public static Rational operator +(Rational number1, Rational number2) =>
            new Rational(number1._numerator * number2._denominator
        + number2._numerator * number1._denominator,
        number1._denominator * number2._denominator
        );
        public static Rational operator +(Rational number1, int number2) =>
            new Rational(number1._numerator
                + number2 * number1._denominator, number1._denominator
                );
        public static Rational operator +(int number1, Rational number2) =>
            new Rational(number1 * number2._denominator
                + number2._numerator, number2._denominator
                );
        public static Rational operator -(Rational number1, Rational number2) =>
            new Rational(number1._numerator * number2._denominator
        - number2._numerator * number1._denominator,
        number1._denominator * number2._denominator
        );
        public static Rational operator -(Rational number1, int number2) =>
            new Rational(number1._numerator
        - number2 * number1._denominator, number1._denominator
        );
        public static Rational operator -(int number1, Rational number2) =>
            new Rational(number1 * number2._denominator
                - number2._numerator, number2._denominator
                );
        public static Rational operator *(Rational number1, Rational number2) =>
            new Rational(number1._numerator * number2._numerator,
        number1._denominator * number2._denominator
        );
        public static Rational operator *(Rational number1, int number2) =>
            new Rational(number1._numerator * number2, number1._denominator);
        public static Rational operator *(int number1, Rational number2) =>
            new Rational(number2._numerator * number1, number2._denominator);
        public static Rational operator /(Rational number1, Rational number2)
        {
            if (number2._numerator == 0) throw new DivideByZeroException("Division by zero");
            return new Rational(number1._numerator * number2._denominator,
                number1._denominator * number2._numerator);
        }
        public static Rational operator /(Rational number1, int number2)
        {
            if (number2 == 0) throw new DivideByZeroException("Division by zero");
            return new Rational(number1._numerator, number1._denominator * number2);
        }
        public static Rational operator /(int number1, Rational number2)
        {
            if (number2._numerator == 0) throw new DivideByZeroException("Division by zero");
            return new Rational(number2._denominator * number1, number2._numerator);
        }
        #endregion

        #region Comparasion operators and methods
        public override int GetHashCode() => _numerator.GetHashCode() ^ _denominator.GetHashCode();
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            var temp = obj as Rational;
            if ((object)temp != null)
                return (temp._numerator == _numerator) && (temp._denominator == _denominator);
            temp = (Rational)((int)obj);
            if ((object)temp != null)
                return (temp._numerator == _numerator) && (temp._denominator == _denominator);
            return false;
        }
        public static bool operator ==(Rational number1, Rational number2) => number1.Equals(number2);
        public static bool operator !=(Rational number1, Rational number2) => !number1.Equals(number2);
        public static bool operator ==(Rational number1, int number2) => number1.Equals(number2);
        public static bool operator !=(Rational number1, int number2) => !number1.Equals(number2);
        public static bool operator ==(int number1, Rational number2) => number2.Equals(number1);
        public static bool operator !=(int number1, Rational number2) => !number2.Equals(number1);
        public static bool operator >(Rational number1, Rational number2) =>
            number1._numerator * number2._denominator > number2._numerator * number1._denominator;
        public static bool operator <(Rational number1, Rational number2) =>
            number1._numerator * number2._denominator < number2._numerator * number1._denominator;
        public static bool operator >=(Rational number1, Rational number2) =>
            number1._numerator * number2._denominator >= number2._numerator * number1._denominator;
        public static bool operator <=(Rational number1, Rational number2) =>
            number1._numerator * number2._denominator <= number2._numerator * number1._denominator;
        public static bool operator >(Rational number1, int number2) =>
            number1._numerator > number2 * number1._denominator;
        public static bool operator <(Rational number1, int number2) =>
            number1._numerator < number2 * number1._denominator;
        public static bool operator >=(Rational number1, int number2) =>
            number1._numerator >= number2 * number1._denominator;
        public static bool operator <=(Rational number1, int number2) =>
            number1._numerator <= number2 * number1._denominator;
        public static bool operator >(int number1, Rational number2) =>
            number1 * number2._denominator > number2._numerator;
        public static bool operator <(int number1, Rational number2) =>
            number1 * number2._denominator < number2._numerator;
        public static bool operator >=(int number1, Rational number2) =>
            number1 * number2._denominator >= number2._numerator;
        public static bool operator <=(int number1, Rational number2) =>
            number1 * number2._denominator <= number2._numerator;
        public static bool operator >(Rational number1, double number2) => (double)number1 > number2;
        public static bool operator <(Rational number1, double number2) => (double)number1 < number2;
        public static bool operator >=(Rational number1, double number2) => (double)number1 >= number2;
        public static bool operator <=(Rational number1, double number2) => (double)number1 <= number2;
        public static bool operator >(double number1, Rational number2) => number1 > (double)number2;
        public static bool operator <(double number1, Rational number2) => number1 < (double)number2;
        public static bool operator >=(double number1, Rational number2) => number1 >= (double)number2;
        public static bool operator <=(double number1, Rational number2) => number1 <= (double)number2;
        #endregion

    }
}
