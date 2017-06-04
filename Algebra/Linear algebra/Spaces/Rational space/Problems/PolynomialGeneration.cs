using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Spaces.Rational_space.Objects;

namespace Algebra.Linear_algebra.Spaces.Rational_space.Problems
{
    public static class PolynomialGeneration
    {
        public static Polynomial Legendre(int degree)
        {
            var lastResult = new Polynomial(1);
            var firstResult = new Polynomial(0);
            if (degree == 0) return firstResult;
            if (degree == 1) return lastResult;
            Polynomial result;
            for(var i = 2; i <= degree; i++)
            {
                result = (new Rational(2 * i - 1, i)) * Polynomial.Shift(lastResult) - 
                    (new Rational(i - 1, i)) * firstResult;
                firstResult = new Polynomial(lastResult.Coefficients);
                lastResult = new Polynomial(result.Coefficients);
            }
            return lastResult;
        }
        public static Polynomial Chebishev1(int degree)
        {
            var lastResult = new Polynomial(1);
            var firstResult = new Polynomial(0);
            if (degree == 0) return firstResult;
            if (degree == 1) return lastResult;
            Polynomial result;
            for (var i = 2; i <= degree; i++)
            {
                result = (new Rational(2 , 1)) * Polynomial.Shift(lastResult) -
                    firstResult;
                firstResult = new Polynomial(lastResult.Coefficients);
                lastResult = new Polynomial(result.Coefficients);
            }
            return lastResult;
        }

        public static Polynomial Chebishev2(int degree)
        {
            var lastResult = new Polynomial((Rational)0,2);
            var firstResult = new Polynomial(0);
            if (degree == 0) return firstResult;
            if (degree == 1) return lastResult;
            Polynomial result;
            for (var i = 2; i <= degree; i++)
            {
                result = (new Rational(2, 1)) * Polynomial.Shift(lastResult) -
                    firstResult;
                firstResult = new Polynomial(lastResult.Coefficients);
                lastResult = new Polynomial(result.Coefficients);
            }
            return lastResult;
        }

        public static Polynomial HermitePhysics(int degree)
        {
            var lastResult = new Polynomial((Rational)0, 2);
            var firstResult = new Polynomial(0);
            if (degree == 0) return firstResult;
            if (degree == 1) return lastResult;
            Polynomial result;
            for (var i = 2; i <= degree; i++)
            {
                result = (new Rational(2, 1)) * Polynomial.Shift(lastResult) -
                    (new Rational(2*(i-1), 1))*firstResult;
                firstResult = new Polynomial(lastResult.Coefficients);
                lastResult = new Polynomial(result.Coefficients);
            }
            return lastResult;
        }

        public static Polynomial HermiteProbability(int degree)
        {
            var lastResult = new Polynomial(1);
            var firstResult = new Polynomial(0);
            if (degree == 0) return firstResult;
            if (degree == 1) return lastResult;
            Polynomial result;
            for (var i = 2; i <= degree; i++)
            {
                result = Polynomial.Shift(lastResult) -
                    (new Rational(i - 1, 1)) * firstResult;
                firstResult = new Polynomial(lastResult.Coefficients);
                lastResult = new Polynomial(result.Coefficients);
            }
            return lastResult;
        }
    }
}
