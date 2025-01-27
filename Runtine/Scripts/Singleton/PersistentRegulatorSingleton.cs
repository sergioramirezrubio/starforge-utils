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
    /// <summary>
    /// Persistent Regulator Singleton will destroy any other older components of the same type if it finds on awake.
    /// This class ensures that only one instance of the singleton exists and persists across scene loads.
    /// </summary>
    /// <typeparam name="T">The type of the singleton.</typeparam>
    public abstract class PersistentRegulatorSingleton<T> : MonoBehaviour where T : Component
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
        /// Gets the time when the singleton was initialized.
        /// </summary>
        public float InitializationTime { get; private set; }

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
                        GameObject go = new(typeof(T).Name + " Auto-Generated")
                        {
                            hideFlags = HideFlags.HideAndDontSave
                        };
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

            DestroyOtherInstances();

            if (_instance is null)
            {
                // Create new instance
                InitializationTime = Time.time;
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Destroys any other instances of the singleton that are older than the current instance.
        /// </summary>
        private void DestroyOtherInstances()
        {
            T[] oldInstances = FindObjectsByType<T>(FindObjectsSortMode.None);
            foreach (T old in oldInstances)
            {
                if (old.GetComponent<PersistentRegulatorSingleton<T>>().InitializationTime < InitializationTime)
                    Destroy(old.gameObject);
            }
        }
    }
}