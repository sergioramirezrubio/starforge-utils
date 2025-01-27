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

using System;
using System.Collections.Generic;
using System.Linq;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for arrays.
    /// </summary>
    public static class ArrayExtension
    {
        private static Random _rng;

        /// <summary>
        /// Returns a random element from the array.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to select a random element from.</param>
        /// <returns>A random element from the array.</returns>
        public static T GetRandom<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        /// <summary>
        /// Determines whether the array contains duplicate elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to check for duplicates.</param>
        /// <returns><c>true</c> if the array contains duplicates; otherwise, <c>false</c>.</returns>
        public static bool ContainsDuplicates<T>(this T[] array)
        {
            HashSet<T> seen = new();
            return array.Any(item => !seen.Add(item));
        }

        /// <summary>
        /// Determines whether an array is null or has no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to evaluate.</param>
        /// <returns><c>true</c> if the array is null or has no elements; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }

        /// <summary>
        /// Creates a new array that is a copy of the original array.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The original array to be copied.</param>
        /// <returns>A new array that is a copy of the original array.</returns>
        public static T[] Clone<T>(this T[] array)
        {
            T[] newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);
            return newArray;
        }

        /// <summary>
        /// Swaps two elements in the array at the specified indices.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="indexA">The index of the first element.</param>
        /// <param name="indexB">The index of the second element.</param>
        public static void Swap<T>(this T[] array, int indexA, int indexB)
        {
            (array[indexA], array[indexB]) = (array[indexB], array[indexA]);
        }

        /// <summary>
        /// Shuffles the elements in the array using the Durstenfeld implementation of the Fisher-Yates algorithm.
        /// This method modifies the input array in-place, ensuring each permutation is equally likely, and returns the array for method chaining.
        /// Reference: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to be shuffled.</param>
        /// <returns>The shuffled array.</returns>
        public static T[] Shuffle<T>(this T[] array)
        {
            _rng ??= new Random();
            int count = array.Length;
            while (count > 1)
            {
                --count;
                int index = _rng.Next(count + 1);
                (array[index], array[count]) = (array[count], array[index]);
            }
            return array;
        }
    }
}