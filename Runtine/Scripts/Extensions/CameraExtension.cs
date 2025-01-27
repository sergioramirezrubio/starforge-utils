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

using UnityEngine;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for the Camera class.
    /// </summary>
    public static class CameraExtension
    {
        /// <summary>
        /// Calculates and returns viewport extents with an optional margin. Useful for calculating a frustum for culling.
        /// </summary>
        /// <param name="camera">The camera object this method extends.</param>
        /// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is (0.2, 0.2).</param>
        /// <returns>Viewport extents as a Vector2 after applying the margin.</returns>
        public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null)
        {
            Vector2 margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

            Vector2 result;
            float halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
            result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
            result.x = result.y * camera.aspect + margin.x;
            result.y += margin.y;
            return result;
        }
    }
}