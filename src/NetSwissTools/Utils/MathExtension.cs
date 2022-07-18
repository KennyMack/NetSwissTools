using NetSwissTools.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Utils
{
    public static class MathExtension
    {
        /// <summary>
        /// An alterantive to the divide by zero error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        /// <returns>Returns 0 if the divisor is 0</returns>
        public static decimal DivideBy(this decimal dividend, decimal divisor) =>
            Convert.ToDecimal(
            DivideByCalculator(Convert.ToDouble(dividend), Convert.ToDouble(divisor)));

        /// <summary>
        /// An alterantive to the divide by zero error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        /// <returns>Returns 0 if the divisor is 0</returns>
        public static double DivideBy(this double dividend, double divisor) =>
            DivideByCalculator(dividend, divisor);

        private static double DivideByCalculator(this double dividend, double divisor)
        {
            try
            {
                return dividend == 0 || divisor == 0 ? 0 : (double)(dividend / (dynamic)divisor);
            }
            catch (Exception)
            {
            }
            return 0;
        }

        /// <summary>
        /// Calculate the standard deviation of array
        /// </summary>
        /// <param name="data">array of values</param>
        /// <returns>Return the value of the standard deviation</returns>
        public static double StandardDeviation(double[] data)
        {
            try
            {
                var Max = data.Length;

                if (Max == 0)
                    return 0;

                double DataAverage = Average(data);

                double TotalVariance = 0;
                for (int i = 0; i < Max; i++)
                    TotalVariance += Math.Pow(data[i] - DataAverage, 2);

                return Math.Sqrt(TotalVariance.DivideBy(Max));
            }
            catch (Exception)
            {
                throw new NetToolException("Can't calculate the standard deviation.");
            }
        }

        /// <summary>
        /// Calculate the average value of array
        /// </summary>
        /// <param name="data">Array of values</param>
        /// <param name="Ceil">if true round the value up</param>
        /// <returns>Return the average value</returns>
        public static int Average(int[] data, bool Ceil = true)
        {
            try
            {
                var DataCalc = new double[data.Length];
                for (int i = 0, length = data.Length; i < length; i++)
                    DataCalc[i] = Convert.ToDouble(data[i]);

                var result = AverageCalculator(DataCalc);

                if (Ceil)
                    return (int)Math.Ceiling(result);
                else
                    return (int)Math.Floor(result);
            }
            catch (Exception)
            {
                throw new NetToolException("Can't calculate the average value.");
            }
        }

        /// <summary>
        /// Calculate the average value of array
        /// </summary>
        /// <param name="data">Array of values</param>
        /// <returns>Return the average value</returns>
        public static decimal Average(decimal[] data)
        {
            var DataCalc = new double[data.Length];

            for (int i = 0, length = data.Length; i < length; i++)
                DataCalc[i] = Convert.ToDouble(data[i]);

            return Convert.ToDecimal(AverageCalculator(DataCalc));
        }


        /// <summary>
        /// Calculate the average value of array
        /// </summary>
        /// <param name="data">Array of values</param>
        /// <returns>Return the average value</returns>
        public static double Average(double[] data) =>
            AverageCalculator(data);

        private static double AverageCalculator(double[] data)
        {
            try
            {
                double DataTotal = 0;

                for (int i = 0; i < data.Length; i++)
                    DataTotal += data[i];

                return DataTotal.DivideBy(data.Length);
            }
            catch (Exception)
            {
                throw new NetToolException("Can't calculate the average value.");
            }
        }

        public static bool IsDivisibleBy(this int value, int divisor) =>
            value % divisor == 0;

        public static bool IsDivisibleBy(this double value, double divisor) =>
            value % divisor == 0;

        public static bool IsDivisibleBy(this decimal value, decimal divisor) =>
            value % divisor == 0;
    }
}
