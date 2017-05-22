using System;

namespace linear_mathematics.Test_objects
{
    public class ComplexNumber : Abstract
    {
        private double _real;
        private double _imaginary;

        public double Real
        {
            get => _real;
            set => _real = value;
        }

        public double Imaginary
        {
            get => _imaginary;
            set => _imaginary = value;
        }



        public ComplexNumber(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }
        public override string ToString()
        {
            return Real.ToString() + " " + Imaginary.ToString();
        }

        public double Norm => Math.Sqrt(Real*Real+Imaginary*Imaginary);
        protected override Abstract Add(Abstract another) 
        {
            return new ComplexNumber(Real+((ComplexNumber)another).Real, Imaginary+((ComplexNumber)another).Imaginary);
        }
    }
}
