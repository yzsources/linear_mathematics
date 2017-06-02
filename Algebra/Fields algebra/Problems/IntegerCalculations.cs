using System;
using System.Collections.Generic;

namespace Algebra.Fields_algebra.Problems
{
    public static class IntegerCalculations
    {
        #region GCD algorythms
        /// <summary>
        /// Greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int element1, int element2)
        {
            if (element1 == 0 && element2 == 0) throw
                    new ArgumentException("Both elements cannot be equal to zero");
            var tempResult = 0;
            var remainder1 = (Math.Abs(element1) > Math.Abs(element2)) ? Math.Abs(element1) : Math.Abs(element2);
            var remainder2 = (Math.Abs(element1) > Math.Abs(element2)) ? Math.Abs(element2) : Math.Abs(element1);
            if (remainder2 == 0) return remainder1;
            do
            {
                tempResult = remainder1 % remainder2;
                if (tempResult != 0)
                {
                    remainder1 = remainder2;
                    remainder2 = tempResult;
                }
            } while (tempResult!=0);
            return remainder2;
        }

        /// <summary>
        /// Greatest common divisor by Eucledean algorithm
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public static int BinaryAlgorithm(int element1, int element2)
        {
            if (element1 == 0 && element2 == 0) throw
                    new ArgumentException("Both elements cannot be equal to zero");
            var result = 1;
            var tempElement1 = Math.Abs(element1);
            var tempElement2 = Math.Abs(element2);
            var countShl = 0;
            var stop = false;
            do
            {
                if (tempElement1 == 0)
                {
                    result = tempElement2;
                    stop = true;
                }
                else
                {
                    if (tempElement2 == 0)
                    {
                        result = tempElement1;
                        stop = true;
                    }
                    else
                    {
                        if (tempElement1 == tempElement2)
                        {
                            result = tempElement1;
                            stop = true;
                        }
                        else
                        {
                            if (tempElement1 == 1 || tempElement2 == 1)
                            {
                                result = 1;
                                stop = true;
                            }
                            else
                            {
                                if (tempElement1 % 2 == 0)
                                {
                                    if(tempElement2 % 2 == 0)
                                    {
                                        countShl++;
                                        tempElement1 = tempElement1 >> 1;
                                        tempElement2 = tempElement2 >> 1;
                                    }
                                    else
                                    {
                                        tempElement1 = tempElement1 >> 1;
                                    }
                                }
                                else
                                {
                                    if(tempElement2 % 2 == 0)
                                    {
                                        tempElement2 = tempElement2 >> 1;
                                    }
                                    else
                                    {
                                        if (tempElement1 < tempElement2)
                                        {
                                            tempElement2 = (tempElement2 - tempElement1) >> 1;
                                        }
                                        else
                                        {
                                            tempElement1 = (tempElement1 - tempElement2) >> 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } while (!stop);
            return result << countShl;
        }
        #endregion

        /// <summary>
        /// Greatest common divisor by Euclidean algorithm
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public static int GCD(int element1, int element2, Func<int, int, int> gcdAlgorithm)
            => gcdAlgorithm(element1, element2);
        /// <summary>
        /// Least common multiple
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <param name="gcdAlgorithm"></param>
        /// <returns></returns>
        public static int LCM(int element1, int element2, Func<int,int,int> gcdAlgorithm)
        {
            if (element1 == 0 || element2 == 0) throw
                         new ArgumentException("Elements cannot be equal to zero");
            return Math.Abs(element1 * element2) / gcdAlgorithm(element1, element2);
        }

        public static UInt64 Pow(int number, int exponent, Func<int, int, UInt64> exponentiationAlgorithm)
            => exponentiationAlgorithm(number, exponent);
        public static List<bool> ToBinary(int number)
        {
            var result = new List<bool>();
            var tempNumber = number;
            do
            {
                result.Add(tempNumber % 2 == 1);
                tempNumber >>= 1;
            } while (tempNumber!=0);
            return result;
        }

        #region Power algorythms
        public static UInt64 FactorialAlgorithm(int number, int exponent)
        {
            if (exponent < 0) throw 
                    new ArgumentOutOfRangeException(nameof(exponent),"Exponent must not be negative");
            var result =(UInt64) 1;
            for (var i = 0; i < exponent; i++) result *=(UInt64)number;
            return result;
        }

        public static UInt64 BySquaringAlgorithm(int number, int exponent)
        {
            if (exponent< 0) throw 
                    new ArgumentOutOfRangeException(nameof(exponent),"Exponent must not be negative");
            var binaryDecomposition = ToBinary(exponent);
            binaryDecomposition.Reverse();
            var cyphersCount = binaryDecomposition.Count;
            var result = (UInt64)number;
            for (var i = 2; i<=cyphersCount; i++)
            {
                result *= result;
               if (binaryDecomposition[i-1]) result *=(UInt64) number;
            }
            return result;
        }
        #endregion
}
}
