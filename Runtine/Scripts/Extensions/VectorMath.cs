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
    /// Provides various mathematical operations for vectors.
    /// </summary>
    public static class VectorMath
    {
        /// <summary>
        /// Calculates the signed angle between two vectors on a plane defined by a normal vector.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <param name="planeNormal">The normal vector of the plane on which to calculate the angle.</param>
        /// <returns>The signed angle between the vectors in degrees.</returns>
        public static float GetAngle(Vector3 vector1, Vector3 vector2, Vector3 planeNormal)
        {
            float angle = Vector3.Angle(vector1, vector2);
            float sign = Mathf.Sign(Vector3.Dot(planeNormal, Vector3.Cross(vector1, vector2)));
            return angle * sign;
        }

        /// <summary>
        /// Calculates the dot product of a vector and a normalized direction.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="direction">The direction vector to project onto.</param>
        /// <returns>The dot product of the vector and the direction.</returns>
        public static float GetDotProduct(Vector3 vector, Vector3 direction) =>
            Vector3.Dot(vector, direction.normalized);

        /// <summary>
        /// Removes the component of a vector that is in the direction of a given vector.
        /// </summary>
        /// <param name="vector">The vector from which to remove the component.</param>
        /// <param name="direction">The direction vector whose component should be removed.</param>
        /// <returns>The vector with the specified direction removed.</returns>
        public static Vector3 RemoveDotVector(Vector3 vector, Vector3 direction)
        {
            direction.Normalize();
            return vector - direction * Vector3.Dot(vector, direction);
        }

        /// <summary>
        /// Extracts and returns the component of a vector that is in the direction of a given vector.
        /// </summary>
        /// <param name="vector">The vector from which to extract the component.</param>
        /// <param name="direction">The direction vector to extract along.</param>
        /// <returns>The component of the vector in the direction of the given vector.</returns>
        public static Vector3 ExtractDotVector(Vector3 vector, Vector3 direction)
        {
            direction.Normalize();
            return direction * Vector3.Dot(vector, direction);
        }

        /// <summary>
        /// Rotates a vector onto a plane defined by a normal vector using a specified up direction.
        /// </summary>
        /// <param name="vector">The vector to be rotated onto the plane.</param>
        /// <param name="planeNormal">The normal vector of the target plane.</param>
        /// <param name="upDirection">The current 'up' direction used to determine the rotation.</param>
        /// <returns>The vector after being rotated onto the specified plane.</returns>
        public static Vector3 RotateVectorOntoPlane(Vector3 vector, Vector3 planeNormal, Vector3 upDirection)
        {
            // Calculate rotation
            Quaternion rotation = Quaternion.FromToRotation(upDirection, planeNormal);

            // Apply rotation to vector
            vector = rotation * vector;

            return vector;
        }

        /// <summary>
        /// Projects a given point onto a line defined by a starting position and direction vector.
        /// </summary>
        /// <param name="lineStartPosition">The starting position of the line.</param>
        /// <param name="lineDirection">The direction vector of the line, which should be normalized.</param>
        /// <param name="point">The point to project onto the line.</param>
        /// <returns>The projected point on the line closest to the original point.</returns>
        public static Vector3 ProjectPointOntoLine(Vector3 lineStartPosition, Vector3 lineDirection, Vector3 point)
        {
            Vector3 projectLine = point - lineStartPosition;
            float dotProduct = Vector3.Dot(projectLine, lineDirection);

            return lineStartPosition + lineDirection * dotProduct;
        }

        /// <summary>
        /// Increments a vector toward a target vector at a specified speed over a given time interval.
        /// </summary>
        /// <param name="currentVector">The current vector to be incremented.</param>
        /// <param name="speed">The speed at which to move towards the target vector.</param>
        /// <param name="deltaTime">The time interval over which to move.</param>
        /// <param name="targetVector">The target vector to approach.</param>
        /// <returns>The new vector incremented toward the target vector by the specified speed and time interval.</returns>
        public static Vector3 IncrementVectorTowardTargetVector(Vector3 currentVector, float speed, float deltaTime, Vector3 targetVector)
        {
            return Vector3.MoveTowards(currentVector, targetVector, speed * deltaTime);
        }
    }
}