// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for mathematical operations.
    /// </summary>
    public static class MathfExtension
    {
        #region Min

#if ENABLED_UNITY_MATHEMATICS
        /// <summary>
        /// Returns the smaller of two half-precision floating-point numbers.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>The smaller of the two values.</returns>
        public static half Min(half a, half b) {
            return (a < b) ? a : b;
        }

        /// <summary>
        /// Returns the smallest value in a set of half-precision floating-point numbers.
        /// </summary>
        /// <param name="values">The set of values to compare.</param>
        /// <returns>The smallest value in the set.</returns>
        public static half Min(params half[] values) {
            int num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] < num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>The smaller of the two values.</returns>
        public static double Min(double a, double b)
        {
            return (a < b) ? a : b;
        }

        /// <summary>
        /// Returns the smallest value in a set of double-precision floating-point numbers.
        /// </summary>
        /// <param name="values">The set of values to compare.</param>
        /// <returns>The smallest value in the set.</returns>
        public static double Min(params double[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            double num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] < num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        #endregion

        #region Max

#if ENABLED_UNITY_MATHEMATICS
        /// <summary>
        /// Returns the larger of two half-precision floating-point numbers.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>The larger of the two values.</returns>
        public static half Max(half a, half b) {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Returns the largest value in a set of half-precision floating-point numbers.
        /// </summary>
        /// <param name="values">The set of values to compare.</param>
        /// <returns>The largest value in the set.</returns>
        public static half Max(params half[] values) {
            int num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] > num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns>The larger of the two values.</returns>
        public static double Max(double a, double b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Returns the largest value in a set of double-precision floating-point numbers.
        /// </summary>
        /// <param name="values">The set of values to compare.</param>
        /// <returns>The largest value in the set.</returns>
        public static double Max(params double[] values)
        {
            int num = values.Length;
            if (num == 0)
            {
                return 0f;
            }

            double num2 = values[0];
            for (int i = 1; i < num; i++)
            {
                if (values[i] > num2)
                {
                    num2 = values[i];
                }
            }

            return num2;
        }

        #endregion
    }
}