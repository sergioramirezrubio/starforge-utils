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

using UnityEditor;
using UnityEngine;

namespace StarForge.Utils
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
    {
        private static readonly Texture2D _requiredIcon = EditorGUIUtility.IconContent("console.erroricon").image as Texture2D;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();

            Rect fieldRect = new(position.x, position.y, position.width - 20, position.height);
            EditorGUI.PropertyField(fieldRect, property, label);

            // If the field is required but unassigned, show the icon
            if (IsFieldUnassigned(property))
            {
                Rect iconRect = new(position.xMax - 18, fieldRect.y, 16, 16);
                GUI.Label(iconRect, new GUIContent(_requiredIcon, "This field is required and is either missing or empty!"));
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(property.serializedObject.targetObject);

                // Force a repaint of the hierarchy
                EditorApplication.RepaintHierarchyWindow();
            }

            EditorGUI.EndProperty();
        }

        private static bool IsFieldUnassigned(SerializedProperty property)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.ObjectReference => property.objectReferenceValue == null ||
                                                          (property.objectReferenceValue is ScriptableObject so && IsScriptableObjectEmpty(so)),
                SerializedPropertyType.ExposedReference => property.exposedReferenceValue == null,
                SerializedPropertyType.AnimationCurve => property.animationCurveValue == null || property.animationCurveValue.length == 0,
                SerializedPropertyType.String => string.IsNullOrEmpty(property.stringValue),
                SerializedPropertyType.Integer => property.intValue == 0,
                SerializedPropertyType.Boolean => !property.boolValue,
                SerializedPropertyType.Float => property.floatValue == 0f,
                SerializedPropertyType.Color => property.colorValue == default,
                SerializedPropertyType.LayerMask => property.intValue == 0,
                SerializedPropertyType.Enum => property.enumValueIndex == 0,
                SerializedPropertyType.Vector2 => property.vector2Value == default,
                SerializedPropertyType.Vector3 => property.vector3Value == default,
                SerializedPropertyType.Vector4 => property.vector4Value == default,
                SerializedPropertyType.Rect => property.rectValue == default,
                SerializedPropertyType.ArraySize => property.arraySize == 0,
                SerializedPropertyType.Character => property.intValue == 0,
                SerializedPropertyType.Bounds => property.boundsValue == default,
                SerializedPropertyType.Gradient => property.gradientValue == null,
                SerializedPropertyType.Quaternion => property.quaternionValue == default,
                SerializedPropertyType.FixedBufferSize => property.fixedBufferSize == 0,
                SerializedPropertyType.Vector2Int => property.vector2IntValue == default,
                SerializedPropertyType.Vector3Int => property.vector3IntValue == default,
                SerializedPropertyType.RectInt => property.rectIntValue == default,
                SerializedPropertyType.BoundsInt => property.boundsIntValue == default,
                SerializedPropertyType.ManagedReference => property.managedReferenceValue == null,
                SerializedPropertyType.Hash128 => property.hash128Value == default,
                SerializedPropertyType.RenderingLayerMask => property.uintValue == 0,
                _ => true
            };
        }

        private static bool IsScriptableObjectEmpty(ScriptableObject so)
        {
            SerializedObject serializedObject = new(so);
            SerializedProperty property = serializedObject.GetIterator();

            while (property.NextVisible(true))
            {
                if (property.name != "m_Script" && property.propertyType != SerializedPropertyType.Generic)
                {
                    if (!IsFieldUnassigned(property))
                        return false;
                }
            }

            return true;
        }
    }
}
