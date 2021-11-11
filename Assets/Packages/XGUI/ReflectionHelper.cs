using System;
using System.Collections.Generic;
using UnityEngine;
using static XGUILayout;

namespace XGUI
{
    internal static class ReflectionHelper
    {
        #region Field

        private static readonly Type IListGUIType = typeof(IListGUI<,>);
        private static readonly Type EnumGUIType  = typeof(EnumGUI<>);
        private static readonly Type FieldGUIType = typeof(FieldGUI<>);

        internal static readonly Dictionary<Type, Type> GUIType = new ()
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

        internal static readonly Dictionary<Type, Func<float, object>> MinValue = new ()
        {
            { typeof(int),        (min) => float.IsNaN(min) ? DefaultMinValueInt        : (int)min},
            { typeof(float),      (min) => float.IsNaN(min) ? DefaultMinValueFloat      : min},
            { typeof(Vector2),    (min) => float.IsNaN(min) ? DefaultMinValueVector2    : new Vector2(min, min)},
            { typeof(Vector3),    (min) => float.IsNaN(min) ? DefaultMinValueVector3    : new Vector3(min, min, min)},
            { typeof(Vector4),    (min) => float.IsNaN(min) ? DefaultMinValueVector4    : new Vector4(min, min, min, min)},
            { typeof(Vector2Int), (min) => float.IsNaN(min) ? DefaultMinValueVector2Int : new Vector2Int((int)min, (int)min)},
            { typeof(Vector3Int), (min) => float.IsNaN(min) ? DefaultMinValueVector3Int : new Vector3Int((int)min, (int)min, (int)min)},
            { typeof(Color),      (min) => float.IsNaN(min) ? DefaultMinValueColor      : new Color(min, min, min, min)},
            { typeof(Matrix4x4),  (min) => float.IsNaN(min) ? DefaultMinValueMatrix4x4  : new Matrix4x4(new Vector4(min, min, min, min),
                                                                                                        new Vector4(min, min, min, min),
                                                                                                        new Vector4(min, min, min, min),
                                                                                                        new Vector4(min, min, min, min))}
        };

        internal static readonly Dictionary<Type, Func<float, object>> MaxValue = new ()
        {
            { typeof(int),        (max) => float.IsNaN(max) ? DefaultMaxValueInt        : (int)max},
            { typeof(float),      (max) => float.IsNaN(max) ? DefaultMaxValueFloat      : max},
            { typeof(Vector2),    (max) => float.IsNaN(max) ? DefaultMaxValueVector2    : new Vector2(max, max)},
            { typeof(Vector3),    (max) => float.IsNaN(max) ? DefaultMaxValueVector3    : new Vector3(max, max, max)},
            { typeof(Vector4),    (max) => float.IsNaN(max) ? DefaultMaxValueVector4    : new Vector4(max, max, max, max)},
            { typeof(Vector2Int), (max) => float.IsNaN(max) ? DefaultMaxValueVector2Int : new Vector2Int((int)max, (int)max)},
            { typeof(Vector3Int), (max) => float.IsNaN(max) ? DefaultMaxValueVector3Int : new Vector3Int((int)max, (int)max, (int)max)},
            { typeof(Color),      (max) => float.IsNaN(max) ? DefaultMaxValueColor      : new Color(max, max, max, max)},
            { typeof(Matrix4x4),  (max) => float.IsNaN(max) ? DefaultMaxValueMatrix4x4  : new Matrix4x4(new Vector4(max, max, max, max),
                                                                                          new Vector4(max, max, max, max),
                                                                                          new Vector4(max, max, max, max),
                                                                                          new Vector4(max, max, max, max))},
        };

        #endregion Field

        #region Method

        internal static Type GetGUIType(Type type)
        {
            Type guiType = null;

            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                guiType = IListGUIType.MakeGenericType(elementType, elementType.MakeArrayType());
            }
            else if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elementType = type.GetGenericArguments()[0];
                    guiType = IListGUIType.MakeGenericType(elementType, type);
                }
            }
            else if (type.IsEnum)
            {
                guiType = EnumGUIType.MakeGenericType(type); ;
            }
            else if (GUIType.ContainsKey(type))
            {
                guiType = GUIType[type];
            }

            return guiType;
        }

        public static object GenerateGUI(Type type)
        {
            var guiType = GetGUIType(type);

            return guiType == null ? new UnSupportedGUI()
                                   : Activator.CreateInstance(guiType);
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

            width = float.IsNaN(width) ? DefaultWidth : width;

            if (typeInfo.IsIList)
            {
                guiType = IListGUIType.MakeGenericType(typeInfo.Type);
            }
            else if (typeInfo.Type.IsEnum)
            {
                guiType = EnumGUIType.MakeGenericType(typeInfo.Type); ;
            }
            else if (GUIType.ContainsKey(typeInfo.Type))
            {
                guiType   = GUIType[typeInfo.Type];
                minObject = MinValue[typeInfo.Type].Invoke(min);
                maxObject = MaxValue[typeInfo.Type].Invoke(max);
            }
            else
            {
                guiType = FieldGUIType.MakeGenericType(typeInfo.Type);
            }

            var gui = Activator.CreateInstance(guiType);

            guiType.GetProperty("Title")?   .SetValue(gui, title);
            guiType.GetProperty("MinValue")?.SetValue(gui, minObject);
            guiType.GetProperty("MaxValue")?.SetValue(gui, maxObject);
            guiType.GetProperty("Width")?   .SetValue(gui, width);

            return gui;
        }

        #endregion Method
    }
}