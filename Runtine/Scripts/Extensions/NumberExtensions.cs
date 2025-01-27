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

using UnityEngine;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for numerical operations.
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Calculates the percentage of a part relative to a whole.
        /// </summary>
        /// <param name="part">The part value.</param>
        /// <param name="whole">The whole value.</param>
        /// <returns>The percentage of the part relative to the whole.</returns>
        public static float PercentageOf(this int part, int whole) {
            if (whole == 0) return 0; // Handling division by zero
            return (float) part / whole;
        }

        /// <summary>
        /// Determines if two floating-point numbers are approximately equal.
        /// </summary>
        /// <param name="f1">The first floating-point number.</param>
        /// <param name="f2">The second floating-point number.</param>
        /// <returns>True if the numbers are approximately equal, otherwise false.</returns>
        public static bool Approx(this float f1, float f2) => Mathf.Approximately(f1, f2);

        /// <summary>
        /// Determines if an integer is odd.
        /// </summary>
        /// <param name="i">The integer to check.</param>
        /// <returns>True if the integer is odd, otherwise false.</returns>
        public static bool IsOdd(this int i) => i % 2 == 1;

        /// <summary>
        /// Determines if an integer is even.
        /// </summary>
        /// <param name="i">The integer to check.</param>
        /// <returns>True if the integer is even, otherwise false.</returns>
        public static bool IsEven(this int i) => i % 2 == 0;

        /// <summary>
        /// Ensures that an integer is at least a specified minimum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The value if it is greater than or equal to the minimum, otherwise the minimum value.</returns>
        public static int AtLeast(this int value, int min) => Mathf.Max(value, min);

        /// <summary>
        /// Ensures that an integer is at most a specified maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The value if it is less than or equal to the maximum, otherwise the maximum value.</returns>
        public static int AtMost(this int value, int max) => Mathf.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
        /// <summary>
        /// Ensures that a half-precision floating-point number is at least a specified minimum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The value if it is greater than or equal to the minimum, otherwise the minimum value.</returns>
        public static half AtLeast(this half value, half min) => MathfExtension.Max(value, min);

        /// <summary>
        /// Ensures that a half-precision floating-point number is at most a specified maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The value if it is less than or equal to the maximum, otherwise the maximum value.</returns>
        public static half AtMost(this half value, half max) => MathfExtension.Min(value, max);
#endif

        /// <summary>
        /// Ensures that a single-precision floating-point number is at least a specified minimum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The value if it is greater than or equal to the minimum, otherwise the minimum value.</returns>
        public static float AtLeast(this float value, float min) => Mathf.Max(value, min);

        /// <summary>
        /// Ensures that a single-precision floating-point number is at most a specified maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The value if it is less than or equal to the maximum, otherwise the maximum value.</returns>
        public static float AtMost(this float value, float max) => Mathf.Min(value, max);

        /// <summary>
        /// Ensures that a double-precision floating-point number is at least a specified minimum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The value if it is greater than or equal to the minimum, otherwise the minimum value.</returns>
        public static double AtLeast(this double value, double min) => MathfExtension.Max(value, min);

        /// <summary>
        /// Ensures that a double-precision floating-point number is at most a specified maximum value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The value if it is less than or equal to the maximum, otherwise the maximum value.</returns>
        public static double AtMost(this double value, double max) => MathfExtension.Min(value, max);
    }
}