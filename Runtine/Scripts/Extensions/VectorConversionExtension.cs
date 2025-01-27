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

using System.Runtime.CompilerServices;
using UnityEngine;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for converting between Unity's <see cref="Vector2"/> and <see cref="Vector3"/> and System.Numerics' <see cref="System.Numerics.Vector2"/> and <see cref="System.Numerics.Vector3"/>.
    /// </summary>
    public static class VectorConversionExtension
    {
        /// <summary>
        /// Converts a <see cref="System.Numerics.Vector2"/> to a Unity <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector">The <see cref="System.Numerics.Vector2"/> to convert.</param>
        /// <returns>A Unity <see cref="Vector2"/> with the same x and y values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToUnityVector(this System.Numerics.Vector2 vector) {
            return new Vector2(vector.X, vector.Y);
        }

        /// <summary>
        /// Converts a Unity <see cref="Vector2"/> to a <see cref="System.Numerics.Vector2"/>.
        /// </summary>
        /// <param name="vector">The Unity <see cref="Vector2"/> to convert.</param>
        /// <returns>A <see cref="System.Numerics.Vector2"/> with the same x and y values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Vector2 ToSystemVector(this Vector2 vector) {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }

        /// <summary>
        /// Converts a <see cref="System.Numerics.Vector3"/> to a Unity <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">The <see cref="System.Numerics.Vector3"/> to convert.</param>
        /// <returns>A Unity <see cref="Vector3"/> with the same x, y, and z values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToUnityVector(this System.Numerics.Vector3 vector) {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// Converts a Unity <see cref="Vector3"/> to a <see cref="System.Numerics.Vector3"/>.
        /// </summary>
        /// <param name="vector">The Unity <see cref="Vector3"/> to convert.</param>
        /// <returns>A <see cref="System.Numerics.Vector3"/> with the same x, y, and z values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Vector3 ToSystemVector(this Vector3 vector) {
            return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
        }
    }
}