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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StarForge.Utils.Editor
{
    [InitializeOnLoad]
    public static class HierarchyIconDrawer
    {
        private static readonly Texture2D _requiredIcon = EditorGUIUtility.IconContent("console.erroricon").image as Texture2D;

        private static readonly Dictionary<Type, FieldInfo[]> _cachedFieldInfo = new();

        static HierarchyIconDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }

        static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is not GameObject gameObject) return;

            // Use GetComponentsInChildren to include components on children
            foreach (Component component in gameObject.GetComponents<Component>())
            {
                if (component == null) continue;

                FieldInfo[] fields = GetCachedFieldsWithRequiredAttribute(component.GetType());
                if (fields == null) continue;

                if (fields.Any(field => IsFieldUnassigned(field.GetValue(component))))
                {
                    Rect iconRect = new Rect(selectionRect.xMax - 20, selectionRect.y, 16, 16);
                    GUI.Label(iconRect, new GUIContent(_requiredIcon, "One or more required fields are missing or empty."));
                    break;
                }
            }
        }

        private static FieldInfo[] GetCachedFieldsWithRequiredAttribute(Type componentType)
        {
            if (_cachedFieldInfo.TryGetValue(componentType, out FieldInfo[] fields))
                return fields;
            
            fields = componentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            List<FieldInfo> requiredFields = new();

            foreach (FieldInfo field in fields)
            {
                bool isSerialized = field.IsPublic || field.IsDefined(typeof(SerializeField), false);
                bool isRequired = field.IsDefined(typeof(RequiredFieldAttribute), false);

                if (isSerialized && isRequired)
                {
                    requiredFields.Add(field);
                }
            }

            fields = requiredFields.ToArray();
            _cachedFieldInfo[componentType] = fields;
            return fields;
        }

        private static bool IsFieldUnassigned(object fieldValue)
        {
            if (fieldValue == null) 
                return true;

            if (fieldValue is string stringValue && string.IsNullOrEmpty(stringValue)) 
                return true;

            if (fieldValue is System.Collections.IEnumerable enumerable)
            {
                return enumerable.Cast<object>().Any(item => item == null);
            }

            return false;
        }
    }
}
