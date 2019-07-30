using System;
using System.Collections.Generic;
using UnityEngine;

namespace XJGUI
{
    public static class GUIHelper
    {
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

        public static object GenerateGUI(TypeInfo typeInfo, string title, float min, float max, float width)
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

            object gui = Activator.CreateInstance(guiType);

            guiType = gui.GetType();
            guiType.GetProperty("Title")?.SetValue(gui, title);
            guiType.GetProperty("MinValue")?.SetValue(gui, min);
            guiType.GetProperty("MaxValue")?.SetValue(gui, max);
            guiType.GetProperty("Width")?.SetValue(gui, width);

            return gui;
        }

        public static void AddUserGUI(Type valueType, Type guiType)
        {
            TypeDictionary.Add(valueType, guiType);
        }

        public static void SetMinValue(object gui, float minValue)
        {
            object m = minValue;
            Type type = gui.GetType();
            bool minIsNaN = float.IsNaN(minValue);

                 if (type == typeof(int))        m = minIsNaN ? XJGUILayout.DefaultMinValueInt        : (int)minValue;
            else if (type == typeof(float))      m = minIsNaN ? XJGUILayout.DefaultMinValueFloat      : minValue;
            else if (type == typeof(Vector2))    m = minIsNaN ? XJGUILayout.DefaultMinValueVector2    : new Vector2(minValue, minValue);
            else if (type == typeof(Vector3))    m = minIsNaN ? XJGUILayout.DefaultMinValueVector3    : new Vector3(minValue, minValue, minValue);
            else if (type == typeof(Vector4))    m = minIsNaN ? XJGUILayout.DefaultMinValueVector4    : new Vector4(minValue, minValue, minValue, minValue);
            else if (type == typeof(Vector2Int)) m = minIsNaN ? XJGUILayout.DefaultMinValueVector2Int : new Vector2Int((int)minValue, (int)minValue);
            else if (type == typeof(Vector3Int)) m = minIsNaN ? XJGUILayout.DefaultMinValueVector3Int : new Vector3Int((int)minValue, (int)minValue, (int)minValue);
            else if (type == typeof(Color))      m = minIsNaN ? XJGUILayout.DefaultMinValueColor      : new Color(minValue, minValue, minValue, minValue);
            else if (type == typeof(Matrix4x4))  m = minIsNaN ? XJGUILayout.DefaultMinValueMatrix4x4  : new Matrix4x4(new Vector4(minValue, minValue, minValue, minValue),
                                                                                                        new Vector4(minValue, minValue, minValue, minValue),
                                                                                                        new Vector4(minValue, minValue, minValue, minValue),
                                                                                                        new Vector4(minValue, minValue, minValue, minValue));


        }

        public static object Show(object gui, object value)
        {
            return gui.GetType().GetMethod("Show").Invoke(gui, new object[] { value });
        }
    }
}