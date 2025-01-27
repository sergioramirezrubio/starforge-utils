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
    /// Provides extension methods for the <see cref="Vector2"/> struct.
    /// </summary>
    public static class Vector2Extension
    {
        /// <summary>
        /// Adds specified values to the x and y components of a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector2">The original <see cref="Vector2"/>.</param>
        /// <param name="x">The value to add to the x component.</param>
        /// <param name="y">The value to add to the y component.</param>
        /// <returns>A new <see cref="Vector2"/> with the added values.</returns>
        public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0) {
            return new Vector2(vector2.x + x, vector2.y + y);
        }

        /// <summary>
        /// Sets specified values to the x and y components of a <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector2">The original <see cref="Vector2"/>.</param>
        /// <param name="x">The value to set to the x component.</param>
        /// <param name="y">The value to set to the y component.</param>
        /// <returns>A new <see cref="Vector2"/> with the set values.</returns>
        public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null) {
            return new Vector2(x ?? vector2.x, y ?? vector2.y);
        }

        /// <summary>
        /// Determines whether the current <see cref="Vector2"/> is within a specified range from another <see cref="Vector2"/>.
        /// </summary>
        /// <param name="current">The current <see cref="Vector2"/>.</param>
        /// <param name="target">The target <see cref="Vector2"/> to compare against.</param>
        /// <param name="range">The range value to compare against.</param>
        /// <returns>True if the current <see cref="Vector2"/> is within the specified range from the target <see cref="Vector2"/>; otherwise, false.</returns>
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Divides two <see cref="Vector2"/> objects component-wise.
        /// </summary>
        /// <param name="v0">The <see cref="Vector2"/> object to be divided.</param>
        /// <param name="v1">The <see cref="Vector2"/> object to divide by.</param>
        /// <returns>A new <see cref="Vector2"/> resulting from the component-wise division.</returns>
        public static Vector2 ComponentDivide(this Vector2 v0, Vector2 v1) {
            return new Vector2(
                v1.x != 0 ? v0.x / v1.x : v0.x,
                v1.y != 0 ? v0.y / v1.y : v0.y);
        }

        /// <summary>
        /// Converts a <see cref="Vector3"/> to a <see cref="Vector2"/> by discarding the y component.
        /// </summary>
        /// <param name="v3">The <see cref="Vector3"/> to convert.</param>
        /// <returns>A <see cref="Vector2"/> with the x and z values of the <see cref="Vector3"/>.</returns>
        public static Vector2 ToVector2(this Vector3 v3) {
            return new Vector2(v3.x, v3.z);
        }

        /// <summary>
        /// Computes a random point within an annulus (a ring-shaped area) based on minimum and maximum radius values around a central <see cref="Vector2"/> point.
        /// </summary>
        /// <param name="origin">The center <see cref="Vector2"/> point of the annulus.</param>
        /// <param name="minRadius">The minimum radius of the annulus.</param>
        /// <param name="maxRadius">The maximum radius of the annulus.</param>
        /// <returns>A random <see cref="Vector2"/> point within the specified annulus.</returns>
        public static Vector2 RandomPointInAnnulus(this Vector2 origin, float minRadius, float maxRadius) {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);

            Vector2 position = direction * distance;
            return origin + position;
        }
    }
}