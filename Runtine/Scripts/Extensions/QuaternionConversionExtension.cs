// MIT License
// 
// Copyright (c) 2024 Sergio Ramirez
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
    /// Provides extension methods for converting between Unity and System.Numerics quaternions.
    /// </summary>
    public static class QuaternionConversionExtension
    {
        /// <summary>
        /// Converts a System.Numerics.Quaternion to a UnityEngine.Quaternion.
        /// </summary>
        /// <param name="quaternion">The System.Numerics.Quaternion to convert.</param>
        /// <returns>A UnityEngine.Quaternion representing the same rotation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToUnityQuaternion(this System.Numerics.Quaternion quaternion) {
            return new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }

        /// <summary>
        /// Converts a UnityEngine.Quaternion to a System.Numerics.Quaternion.
        /// </summary>
        /// <param name="quaternion">The UnityEngine.Quaternion to convert.</param>
        /// <returns>A System.Numerics.Quaternion representing the same rotation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Quaternion ToSystemQuaternion(this Quaternion quaternion) {
            return new System.Numerics.Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}