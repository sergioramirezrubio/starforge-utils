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
    /// Provides extension methods for the Renderer class to enable or disable ZWrite for materials.
    /// </summary>
    public static class RendererExtension
    {
        private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        
        /// <summary>
        /// Enables ZWrite for materials in this Renderer that have a '_Color' property.
        /// This will allow the materials to write to the Z buffer, which could be used to affect how subsequent rendering is handled,
        /// for instance, ensuring correct layering of transparent objects.
        /// </summary>
        /// <param name="renderer">The Renderer whose materials' ZWrite property will be enabled.</param>
        public static void EnableZWrite(this Renderer renderer) {
            foreach (Material material in renderer.materials) {
                if (material.HasProperty(Color1)) {
                    material.SetInt(ZWrite, 1);
                    material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                }
            }
        }

        /// <summary>
        /// Disables ZWrite for materials in this Renderer that have a '_Color' property.
        /// This would stop the materials from writing to the Z buffer, which may be desirable in some cases to prevent subsequent
        /// rendering from being occluded, like in rendering of semi-transparent or layered objects.
        /// </summary>
        /// <param name="renderer">The Renderer whose materials' ZWrite property will be disabled.</param>
        public static void DisableZWrite(this Renderer renderer) {
            foreach (Material material in renderer.materials) {
                if (material.HasProperty(Color1)) {
                    material.SetInt(ZWrite, 0);
                    material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent + 100;
                }
            }
        }
    }
}