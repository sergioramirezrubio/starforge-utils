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

using System.Collections.Generic;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for IEnumerator&lt;T&gt;.
    /// </summary>
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Converts an IEnumerator&lt;T&gt; to an IEnumerable&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerator.</typeparam>
        /// <param name="e">An instance of IEnumerator&lt;T&gt;.</param>
        /// <returns>An IEnumerable&lt;T&gt; with the same elements as the input instance.</returns>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> e) {
            while (e.MoveNext()) {
                yield return e.Current;
            }
        }
    }
}