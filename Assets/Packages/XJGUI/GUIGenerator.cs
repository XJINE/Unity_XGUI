using System;
using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public static class GUIHelper
    {
        #region Field

        private static Type IListGUIType = typeof(IListGUI<>);
        private static Type EnumGUIType  = typeof(EnumGUI<>);
        private static Type FieldGUIType = typeof(FieldGUI<>);

        private static readonly Dictionary<Type, Type> TypeDictionary = new Dictionary<Type, Type>()
        {
            { typeof(bool),       typeof(BoolGUI)       },
            { typeof(string),     typeof(StringGUI)     },
            { typeof(int),        typeof(IntGUI)        },
            { typeof(float)  ,    typeof(FloatGUI)      },
            { typeof(Vector2),    typeof(Vector2GUI)    },
            { typeof(Vector3),    typeof(Vector3GUI)    },
            { typeof(Vector4),    typeof(Vector4GUI)    },
            { typeof(Vector2Int), typeof(Vector2IntGUI) },
            { typeof(Vector3Int), typeof(Vector3IntGUI) },
            { typeof(Color),      typeof(ColorGUI)      },
            { typeof(Matrix4x4),  typeof(Matrix4x4GUI)  },
        };

        #endregion Field

        public static object GenerateGUI(TypeInfo typeInfo)
        {
            Type guiType = null;

            if (typeInfo.isIList)
            {
                guiType = IListGUIType.MakeGenericType(typeInfo.type);
            }
            else if (typeInfo.type.IsEnum)
            {
                guiType = EnumGUIType.MakeGenericType(typeInfo.type);;
            }
            else if (TypeDictionary.ContainsKey(typeInfo.type))
            {
                guiType = TypeDictionary[typeInfo.type];
            }
            else
            {
                guiType = FieldGUIType.MakeGenericType(typeInfo.type);;
            }

            return Activator.CreateInstance(guiType);
        }

        public static object GenerateGUI(TypeInfo typeInfo,
                                         string   title = null,
                                         float    min   = float.NaN,
                                         float    max   = float.NaN,
                                         float    width = float.NaN)
        {
            Type   guiType   = null;
            object minObject = null;
            object maxObject = null;

            width = float.IsNaN(width) ? width : XJGUILayout.DefaultWidth;

            if (typeInfo.isIList)
            {
                guiType = IListGUIType.MakeGenericType(typeInfo.type);
            }
            else if (typeInfo.type.IsEnum)
            {
                guiType = EnumGUIType.MakeGenericType(typeInfo.type);;
            }
            else if (typeInfo.type == typeof(bool))
            {
                guiType = typeof(BoolGUI);
            }
            else if (typeInfo.type == typeof(int))
            {
                guiType   = typeof(IntGUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueInt : (int)min;
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueInt : (int)max;
            }
            else if (typeInfo.type == typeof(float))
            {
                guiType   = typeof(FloatGUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueFloat : min;
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueFloat : max;
            }
            else if (typeInfo.type == typeof(Vector2))
            {
                guiType   = typeof(Vector2GUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueVector2 : new Vector2(min, min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueVector2 : new Vector2(max, max);
            }
            else if (typeInfo.type == typeof(Vector3))
            {
                guiType   = typeof(Vector3GUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueVector3 : new Vector3(min, min, min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueVector3 : new Vector3(max, max, max);
            }
            else if (typeInfo.type == typeof(Vector4))
            {
                guiType   = typeof(Vector4GUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueVector4 : new Vector4(min, min, min, min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueVector4 : new Vector4(max, max, max, max);
            }
            else if (typeInfo.type == typeof(Vector2Int))
            {
                guiType   = typeof(Vector2IntGUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueVector2Int : new Vector2Int((int)min, (int)min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueVector2Int : new Vector2Int((int)max, (int)max);
            }
            else if (typeInfo.type == typeof(Vector3Int))
            {
                guiType   = typeof(Vector3IntGUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueVector3Int : new Vector3Int((int)min, (int)min, (int)min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueVector3Int : new Vector3Int((int)max, (int)max, (int)max);
            }
            else if (typeInfo.type == typeof(Color))
            {
                guiType   = typeof(ColorGUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueColor : new Color(min, min, min, min);
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueColor : new Color(max, max, max, max);
            }
            else if (typeInfo.type == typeof(Matrix4x4))
            {
                guiType   = typeof(Matrix4x4GUI);
                minObject = float.IsNaN(min) ? XJGUILayout.DefaultMinValueMatrix4x4
                                             : new Matrix4x4(new Vector4(min, min, min, min),
                                                             new Vector4(min, min, min, min),
                                                             new Vector4(min, min, min, min),
                                                             new Vector4(min, min, min, min));
                maxObject = float.IsNaN(max) ? XJGUILayout.DefaultMaxValueMatrix4x4
                                             : new Matrix4x4(new Vector4(max, max, max, max),
                                                             new Vector4(max, max, max, max),
                                                             new Vector4(max, max, max, max),
                                                             new Vector4(max, max, max, max));
            }
            else
            {
                guiType = FieldGUIType.MakeGenericType(typeInfo.type);;
            }

            object gui = Activator.CreateInstance(guiType);

            guiType = gui.GetType();
            guiType.GetProperty("Title")?.SetValue(gui, title);
            guiType.GetProperty("MinValue")?.SetValue(gui, minObject);
            guiType.GetProperty("MaxValue")?.SetValue(gui, maxObject);
            guiType.GetProperty("Width")?.SetValue(gui, width);

            return gui;
        }
    }
}