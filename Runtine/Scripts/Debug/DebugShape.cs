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
using UnityEngine;

namespace StarForge.Utils
{
    /// <summary>
    /// Creates a debug shape gizmo in the desired position.
    /// </summary>
    public class DebugShape : MonoBehaviour
    {
        private static readonly Color _defaultColor = new(225.0f, 225.0f, 0.0f, 0.25f);

        private enum EShapeType
        {
            Cube = 0,
            Sphere = 1,
            Line = 2
        }

        [SerializeField] private bool useGizmos = true;
        [SerializeField] private EShapeType shapeType = EShapeType.Cube;
        [SerializeField] private Color shapeColor = _defaultColor;

        [SerializeField] private Vector3 cubeSize = new(1.0f, 1.0f, 1.0f);
        [SerializeField] private Vector3 cubeOffset = new(0.0f, 0.0f, 0.0f);

        [SerializeField] private float sphereRadius = 1.0f;
        [SerializeField] private Vector3 sphereOffset = new(0.0f, 0.0f, 0.0f);

        [SerializeField] private Vector3 lineStart = new(0.0f, 0.0f, 0.0f);
        [SerializeField] private Vector3 lineEnd = new(1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Draws the gizmo in the scene view.
        /// </summary>
        private void OnDrawGizmos()
        {
            if (!useGizmos)
            {
                return;
            }

            Gizmos.color = shapeColor;

            switch (shapeType)
            {
                case EShapeType.Cube:
                    Gizmos.DrawCube(transform.position + cubeOffset, cubeSize);
                    break;
                case EShapeType.Sphere:
                    Gizmos.DrawSphere(transform.position + sphereOffset, sphereRadius);
                    break;
                case EShapeType.Line:
                    Gizmos.DrawLine(transform.position + lineStart, transform.position + lineEnd);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Activates the gizmo drawing.
        /// </summary>
        public void Activate() => useGizmos = true;

        /// <summary>
        /// Deactivates the gizmo drawing.
        /// </summary>
        public void Deactivate() => useGizmos = false;

        /// <summary>
        /// Fills the transform properties based on the current shape type.
        /// </summary>
        public void FillTransform()
        {
            switch (shapeType)
            {
                case EShapeType.Cube:
                    SetCubeShape(transform.localScale, Vector3.zero, _defaultColor);
                    break;
                case EShapeType.Sphere:
                    SetSphereShape(Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z), Vector3.zero, _defaultColor);
                    break;
                case EShapeType.Line:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Sets the color of the shape.
        /// </summary>
        /// <param name="color">The color to set.</param>
        public void SetColor(Color color) => shapeColor = color;

        /// <summary>
        /// Sets the properties for a cube shape.
        /// </summary>
        /// <param name="size">The size of the cube.</param>
        /// <param name="offset">The offset of the cube.</param>
        /// <param name="color">The color of the cube (optional).</param>
        public void SetCubeShape(Vector3 size, Vector3 offset, Color? color = null)
        {
            shapeType = EShapeType.Cube;
            cubeSize = size;
            cubeOffset = offset;
            if (color != null)
                SetColor((Color)color);

            Activate();
        }

        /// <summary>
        /// Sets the properties for a sphere shape.
        /// </summary>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="offset">The offset of the sphere.</param>
        /// <param name="color">The color of the sphere (optional).</param>
        public void SetSphereShape(float radius, Vector3 offset, Color? color = null)
        {
            shapeType = EShapeType.Sphere;
            sphereRadius = radius;
            sphereOffset = offset;
            if (color != null)
                SetColor((Color)color);

            Activate();
        }

        /// <summary>
        /// Sets the properties for a line shape.
        /// </summary>
        /// <param name="start">The start point of the line.</param>
        /// <param name="end">The end point of the line.</param>
        /// <param name="color">The color of the line (optional).</param>
        public void SetLineShape(Vector3 start, Vector3 end, Color? color = null)
        {
            shapeType = EShapeType.Line;
            lineStart = start;
            lineEnd = end;
            if (color != null)
                SetColor((Color)color);

            Activate();
        }
    }
}