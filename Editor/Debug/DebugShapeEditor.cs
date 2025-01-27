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

#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace StarForge.Utils.Editor
{
    /// <summary>
    /// Custom editor for the <see cref="DebugShape"/> class, providing a user interface in the Unity Editor.
    /// </summary>
    [CustomEditor(typeof(DebugShape))]
    public class DebugShapeEditor : UnityEditor.Editor
    {
        private DebugShape _debugShape;

        private SerializedProperty _useGizmos;
        private SerializedProperty _shapeType;
        private SerializedProperty _shapeColor;
        private SerializedProperty _cubeSize;
        private SerializedProperty _cubeOffset;
        private SerializedProperty _sphereRadius;
        private SerializedProperty _sphereOffset;
        private SerializedProperty _lineStart;
        private SerializedProperty _lineEnd;

        /// <summary>
        /// Called when the editor is enabled. Initializes the serialized properties.
        /// </summary>
        private void OnEnable()
        {
            _debugShape = (DebugShape)target;
            GetComponentsFromDebugShape();
        }

        /// <summary>
        /// Draws the custom inspector GUI.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawComponents();
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Retrieves the serialized properties from the <see cref="DebugShape"/> component.
        /// </summary>
        private void GetComponentsFromDebugShape()
        {
            _useGizmos = serializedObject.FindProperty("useGizmos");
            _shapeType = serializedObject.FindProperty("shapeType");
            _shapeColor = serializedObject.FindProperty("shapeColor");
            _cubeSize = serializedObject.FindProperty("cubeSize");
            _cubeOffset = serializedObject.FindProperty("cubeOffset");
            _sphereRadius = serializedObject.FindProperty("sphereRadius");
            _sphereOffset = serializedObject.FindProperty("sphereOffset");
            _lineStart = serializedObject.FindProperty("lineStart");
            _lineEnd = serializedObject.FindProperty("lineEnd");
        }

        /// <summary>
        /// Draws the components of the custom inspector.
        /// </summary>
        private void DrawComponents()
        {
            EditorGUILayout.LabelField("General Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_useGizmos);
            if (!_useGizmos.boolValue)
                GUI.enabled = false;

            EditorGUILayout.PropertyField(_shapeType);
            EditorGUILayout.PropertyField(_shapeColor);
            EditorGUILayout.Space();

            switch (_shapeType.intValue)
            {
                case 0:
                    EditorGUILayout.LabelField("Cube Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_cubeSize);
                    EditorGUILayout.PropertyField(_cubeOffset);
                    break;
                case 1:
                    EditorGUILayout.LabelField("Sphere Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_sphereRadius);
                    EditorGUILayout.PropertyField(_sphereOffset);
                    break;
                case 2:
                    EditorGUILayout.LabelField("Line Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_lineStart);
                    EditorGUILayout.PropertyField(_lineEnd);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_shapeType.intValue > 1)
                return;

            EditorGUILayout.Space();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Fill Transform", GUILayout.Width(225), GUILayout.Height(22.5f)))
            {
                _debugShape.FillTransform();
                SceneView.RepaintAll();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }
    }
}

#endif