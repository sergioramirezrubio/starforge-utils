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

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for the <see cref="Vector3"/> struct.
    /// </summary>
    public static class Vector3Extension
    {
        /// <summary>
        /// Sets specified values to the x, y, and z components of a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">The original <see cref="Vector3"/>.</param>
        /// <param name="x">The value to set to the x component.</param>
        /// <param name="y">The value to set to the y component.</param>
        /// <param name="z">The value to set to the z component.</param>
        /// <returns>A new <see cref="Vector3"/> with the set values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Adds specified values to the x, y, and z components of a <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">The original <see cref="Vector3"/>.</param>
        /// <param name="x">The value to add to the x component.</param>
        /// <param name="y">The value to add to the y component.</param>
        /// <param name="z">The value to add to the z component.</param>
        /// <returns>A new <see cref="Vector3"/> with the added values.</returns>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        /// <summary>
        /// Determines whether the current <see cref="Vector3"/> is within a specified range from another <see cref="Vector3"/>.
        /// </summary>
        /// <param name="current">The current <see cref="Vector3"/>.</param>
        /// <param name="target">The target <see cref="Vector3"/> to compare against.</param>
        /// <param name="range">The range value to compare against.</param>
        /// <returns>True if the current <see cref="Vector3"/> is within the specified range from the target <see cref="Vector3"/>; otherwise, false.</returns>
        public static bool InRangeOf(this Vector3 current, Vector3 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Divides two <see cref="Vector3"/> objects component-wise.
        /// </summary>
        /// <param name="v0">The <see cref="Vector3"/> object to be divided.</param>
        /// <param name="v1">The <see cref="Vector3"/> object to divide by.</param>
        /// <returns>A new <see cref="Vector3"/> resulting from the component-wise division.</returns>
        public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1) {
            return new Vector3(
                v1.x != 0 ? v0.x / v1.x : v0.x,
                v1.y != 0 ? v0.y / v1.y : v0.y,
                v1.z != 0 ? v0.z / v1.z : v0.z);
        }

        /// <summary>
        /// Converts a <see cref="Vector2"/> to a <see cref="Vector3"/> with a y value of 0.
        /// </summary>
        /// <param name="v2">The <see cref="Vector2"/> to convert.</param>
        /// <returns>A <see cref="Vector3"/> with the x and z values of the <see cref="Vector2"/> and a y value of 0.</returns>
        public static Vector3 ToVector3(this Vector2 v2) {
            return new Vector3(v2.x, 0, v2.y);
        }

        /// <summary>
        /// Computes a random point within an annulus (a ring-shaped area) based on minimum and maximum radius values around a central <see cref="Vector3"/> point.
        /// </summary>
        /// <param name="origin">The center <see cref="Vector3"/> point of the annulus.</param>
        /// <param name="minRadius">The minimum radius of the annulus.</param>
        /// <param name="maxRadius">The maximum radius of the annulus.</param>
        /// <returns>A random <see cref="Vector3"/> point within the specified annulus.</returns>
        public static Vector3 RandomPointInAnnulus(this Vector3 origin, float minRadius, float maxRadius) {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);

            Vector3 position = new Vector3(direction.x, 0, direction.y) * distance;
            return origin + position;
        }
    }
}