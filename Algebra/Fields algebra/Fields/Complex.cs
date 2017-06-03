using System;

namespace Algebra.Fields_algebra.Fields
{
    public class Complex: ICloneable
    {
        #region Private
        private double _real;
        private double _imaginary;
        #endregion

        #region ICloneable
        public object Clone() => new Complex(_real, _imaginary);
        #endregion

        #region Properties
        public double Real { get => _real; }
        public double Imaginary { get => _imaginary; }
        #endregion

        #region Constructors
        public Complex()
        {
            _real = _imaginary = 0;
        }
        public Complex(double real)
        {
            _real = real;
            _imaginary = 0;
        }
        public Complex(double firstDouble, double secondDouble, bool byRealImaginary=true)
        {
            if (byRealImaginary)
            {
                _real = firstDouble;
                _imaginary = secondDouble;
            }
            else
            {
                if (firstDouble < 0) throw
                           new ArgumentException(nameof(firstDouble), "For this case abs cannot be negative");
                if (firstDouble < Constants.DoublePrecision) _real = _imaginary = 0;
                else
                {
                    _real = firstDouble * Math.Cos(secondDouble);
                    _imaginary = firstDouble * Math.Sin(secondDouble);
                }
            }
        }
        #endregion

        #region Static math functions

        public static Complex Sqr(Complex number) => number * number;
        public static Complex Pow(Complex number, double exponent) =>
            new Complex(Math.Pow(number.Abs(), exponent), exponent * (number.Arg()), false);


        #endregion
        #region Non-static math functions
        public Complex Conjugate() => new Complex(_real,-_imaginary);
        public double Abs() =>
            Math.Sqrt(_real * _real + _imaginary * _imaginary);
        public double CosPart()
        {
            if (Abs() < Constants.DoublePrecision)
                throw new ArgumentException("Only for non-zero number");
            return _real / Abs();
        }
        public double SinPart()
        {
            if (Abs() < Constants.DoublePrecision)
                throw new ArgumentException("Only for non-zero number");
            return _imaginary / Abs();
        }
        public double Arg()
        {
            var result = Math.Asin(SinPart());
            if (_real >= 0) return result;
            return (_imaginary >= 0) ? Math.PI - result : -Math.PI - result;
        }
        #endregion

        #region Converters
        public override string ToString() 
            => _real.ToString() + ((_imaginary>0)?" + ":" - ") + (Math.Abs(_imaginary)).ToString() + "i";
        public static explicit operator Complex(double real) => new Complex(real);
        #endregion


        #region Arithmetic operators
        public static Complex operator -(Complex number) 
            => new Complex(-number._real,-number._imaginary); 
        public static Complex operator +(Complex number1, Complex number2) 
            => new Complex(number1._real+number2._real,number1._imaginary+number2._imaginary);
        public static Complex operator +(double number1, Complex number2)
            => new Complex(number1 + number2._real, number2._imaginary);
        public static Complex operator +(Complex number1, double number2)
            => new Complex(number1._real + number2, number1._imaginary);
        public static Complex operator -(Complex number1, Complex number2)
            => new Complex(number1._real - number2._real, number1._imaginary - number2._imaginary);
        public static Complex operator-(double number1, Complex number2)
            => new Complex(number1 - number2._real, number2._imaginary);
        public static Complex operator -(Complex number1, double number2)
            => new Complex(number1._real - number2, number1._imaginary);
        public static Complex operator *(Complex number1, Complex number2)
            => new Complex(number1._real*number2._real-number1._imaginary*number2._imaginary,
                number1._real*number2._imaginary+number1._imaginary*number2._real
                );
        public static Complex operator *(double number1, Complex number2) 
            => new Complex(number1*number2._real,number1*number2._imaginary);
        public static Complex operator *(Complex number1, double number2)
            => new Complex(number1._real * number2, number1._imaginary * number2);
        public static Complex operator /(Complex number1, double number2)
        {
            if (Math.Abs(number2) < Constants.DoublePrecision)
                throw new DivideByZeroException("Divison by zero");
            return new Complex(number1._real / number2, number1._imaginary / number2);
        }
        public static Complex operator /(double number1, Complex number2)
        {
            if (number2.Abs() < Constants.DoublePrecision)
                throw new DivideByZeroException("Divison by zero");
            return (number1 /(number2._real*number2._real+number2._imaginary*number2._imaginary)*
                (number2.Conjugate()));
        }
        public static Complex operator /(Complex number1, Complex number2)
        {
            if (number2.Abs() < Constants.DoublePrecision)
                throw new DivideByZeroException("Divison by zero");
            return number1 * (1 / number2);
        }
        #endregion

        #region Comparasion operators and methods
        public override int GetHashCode() => _real.GetHashCode() ^ _imaginary.GetHashCode();
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            var temp = obj as Complex;
            if ((object)temp != null)
                return (temp._real == _real) && (temp._imaginary == _imaginary);
            temp = (Complex)((double)obj);
            if ((object)temp != null)
                return (temp._real == _real) && (temp._imaginary == _imaginary);
            return false;
        }
        public static bool operator ==(Complex number1, Complex number2) => number1.Equals(number2);
        public static bool operator !=(Complex number1, Complex number2) => !number1.Equals(number2);
        public static bool operator ==(Complex number1, double number2) => number1.Equals(number2);
        public static bool operator !=(Complex number1, double number2) => !number1.Equals(number2);
        public static bool operator ==(double number1, Complex number2) => number2.Equals(number1);
        public static bool operator !=(double number1, Complex number2) => !number2.Equals(number1);

        #endregion
    }
}
