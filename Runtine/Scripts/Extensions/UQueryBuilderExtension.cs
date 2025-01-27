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
using UnityEngine.UIElements;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for the <see cref="UQueryBuilder{T}"/> class.
    /// </summary>
    public static class UQueryBuilderExtension
    {
        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key and returns an ordered sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the key selector.</typeparam>
        /// <param name="query">The elements to be sorted.</param>
        /// <param name="keySelector">A function to extract a sort key from an element.</param>
        /// <param name="default">The comparer to compare keys.</param>
        /// <returns>An ordered sequence of elements.</returns>
        public static IEnumerable<T> OrderBy<T, TKey>(this UQueryBuilder<T> query, Func<T, TKey> keySelector, Comparer<TKey> @default)
            where T : VisualElement {
            return query.ToList().OrderBy(keySelector, @default);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a numeric key and returns an ordered sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <param name="query">The elements to be sorted.</param>
        /// <param name="keySelector">A function to extract a numeric key from an element.</param>
        /// <returns>An ordered sequence of elements.</returns>
        public static IEnumerable<T> SortByNumericValue<T>(this UQueryBuilder<T> query, Func<T, float> keySelector)
            where T : VisualElement {
            return query.OrderBy(keySelector, Comparer<float>.Default);
        }

        /// <summary>
        /// Returns the first element of a sequence, or a default value if no element is found.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <param name="query">The elements to search in.</param>
        /// <returns>The first element in the sequence, or a default value if no element is found.</returns>
        public static T FirstOrDefault<T>(this UQueryBuilder<T> query)
            where T : VisualElement {
            return query.ToList().FirstOrDefault();
        }

        /// <summary>
        /// Counts the number of elements in the sequence that satisfy the condition specified by the predicate function.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the sequence.</typeparam>
        /// <param name="query">The sequence of elements to be processed.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The number of elements that satisfy the condition specified by the predicate function.</returns>
        public static int CountWhere<T>(this UQueryBuilder<T> query, Func<T, bool> predicate)
            where T : VisualElement {
            return query.ToList().Count(predicate);
        }
    }
}