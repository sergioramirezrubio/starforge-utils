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

using System.Linq;
using UnityEngine;

namespace StarForge.Utils
{
    /// <summary>
    /// FpsCounter to use in editor. The object will be destroyed in production environment.
    /// </summary>
    public class FpsCounter : PersistentSingleton<FpsCounter>
    {
        private const int MOBILE_FRAME_RATE = 30;
        private const int DESKTOP_FRAME_RATE = 60;
        private const int UNLIMITED_FRAME_RATE = -1;
        private const int BUFFER_SIZE = 50;

        [Header("Game Version")]
        [SerializeField] private bool showGameVersion = true;

        [Header("FPS")]
        [SerializeField] private bool showFPS = true;
        [SerializeField] private EFrameRates targetFps;

        [Header("Text")]
        [Range(18, 100)]
        [SerializeField] private int fontSize;

        // FPS calculation
        private int _currentFpsIndex;
        private float[] _deltaTimeBuffer;
        private float _fpsValue;

        /// <summary>
        /// Enum representing different frame rate targets.
        /// </summary>
        private enum EFrameRates
        {
            Mobile = 0,
            Desktop = 10,
            Unlimited = 20
        }
        
        protected override void Awake()
        {
#if UNITY_EDITOR
            base.Awake();

            _deltaTimeBuffer = new float[BUFFER_SIZE];

            Application.targetFrameRate = targetFps switch
            {
                EFrameRates.Mobile => MOBILE_FRAME_RATE,
                EFrameRates.Desktop => DESKTOP_FRAME_RATE,
                EFrameRates.Unlimited => UNLIMITED_FRAME_RATE,
                _ => UNLIMITED_FRAME_RATE,
            };
#else
        Destroy(gameObject);
#endif
        }
        
        private void Update()
        {
            if (showFPS)
            {
                _deltaTimeBuffer[_currentFpsIndex] = Time.deltaTime;
                _currentFpsIndex = (_currentFpsIndex + 1) % _deltaTimeBuffer.Length;
                _fpsValue = Mathf.RoundToInt(CalculateFps());
            }
        }
        
        private void OnGUI()
        {
            UpdateGameVersionText();
            UpdateFpsText();
        }

        /// <summary>
        /// Calculates the current FPS based on the delta time buffer.
        /// </summary>
        /// <returns>The calculated FPS.</returns>
        private float CalculateFps()
        {
            return _deltaTimeBuffer.Length / _deltaTimeBuffer.Sum();
        }

        /// <summary>
        /// Updates the game version text on the screen.
        /// </summary>
        private void UpdateGameVersionText()
        {
            if (!showGameVersion)
            {
                return;
            }

            GUIStyle gameVersionStyle = new()
            {
                fontSize = fontSize,
                alignment = TextAnchor.LowerRight,
                normal = { textColor = Color.white }
            };

            const float labelWidth = 100.0f;
            const float labelHeight = 50.0f;
            float posX = Screen.width - labelWidth - 10;
            float posY = Screen.height - labelHeight - 10;
            Rect position = new(posX, posY, labelWidth, labelHeight);

            GUI.Label(position, $"{Application.productName} v{Application.version}\n{Application.companyName}", gameVersionStyle);
        }

        /// <summary>
        /// Updates the FPS text on the screen.
        /// </summary>
        private void UpdateFpsText()
        {
            if (!showFPS)
            {
                return;
            }

            GUIStyle fpsStyle = new()
            {
                fontSize = fontSize,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.UpperLeft,
                normal =
                {
                    textColor = _fpsValue switch
                    {
                        >= 60.0f => Color.green,
                        >= 30.0f => Color.yellow,
                        _ => Color.red
                    }
                }
            };

            GUI.Label(new Rect(10, 10, 200, 30), $"FPS: {_fpsValue:0.0}", fpsStyle);
        }
    }
}
