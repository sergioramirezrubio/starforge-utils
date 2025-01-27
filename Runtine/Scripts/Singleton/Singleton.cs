// MIT License
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
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// The instance of the singleton.
        /// </summary>
        protected static T _instance;

        /// <summary>
        /// Gets a value indicating whether an instance of the singleton exists.
        /// </summary>
        public static bool HasInstance => _instance is not null;

        /// <summary>
        /// Tries to get the instance of the singleton.
        /// </summary>
        /// <returns>The instance if it exists; otherwise, null.</returns>
        public static T TryGetInstance() => HasInstance ? _instance : null;

        /// <summary>
        /// Gets the instance of the singleton, creating it if it does not already exist.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    // Try to find the instance
                    _instance = FindAnyObjectByType<T>();

                    if (_instance is null)
                    {
                        // Create a new instance
                        GameObject go = new(typeof(T).Name + " Auto-Generated");
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        /// <summary>
        /// Initializes the singleton instance.
        /// </summary>
        private void InitializeSingleton()
        {
            if (!Application.isPlaying)
                return;

            _instance = this as T;
        }
    }
}
