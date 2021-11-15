using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using static XGUILayout;

namespace XGUI
{
    internal static class ReflectionHelper
    {
        #region Field

        private static readonly Type IListGUIType = typeof(IListGUI<,>);
        private static readonly Type EnumGUIType  = typeof(EnumGUI<>);

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

        internal static object GenerateGUI(Type type)
        {
            var guiType = GetGUIType(type);

            return guiType == null ? new UnSupportedGUI()
                                   : Activator.CreateInstance(guiType);
        }
        
        internal static void SetProperty(object gui, string propertyName, object value)
        {
            var property = gui.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return;
            }

            try
            {
                property.SetValue(gui, value);
            }
            catch
            {
                // ignored
            }
        }

        internal static object GetProperty(object gui, string propertyName)
        {
            var property = gui.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return null;
            }

            try
            {
                return property.GetValue(gui);
            }
            catch
            {
                return null;
            }
        }

        internal static Type GetRootElementType(Type type)
        {
            if (type == null)
            {
                return null;
            }

            var tempType = type;

            while (true)
            {
                if (tempType.IsArray)
                {
                    tempType = tempType.GetElementType();
                }
                else if (tempType.IsGenericType)
                {
                    if (tempType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var genericTypes = tempType.GetGenericArguments();

                        if (genericTypes.Length == 0)
                        {
                            return null;
                        }

                        tempType = tempType.GetGenericArguments()[0];
                    }
                }
                else
                {
                    break;
                }
            }

            return tempType;
        }

        [return : MaybeNull]
        internal static object GetMinValue(Type type, float minValue)
        {
            var rootType = GetRootElementType(type);
            return MinValue.ContainsKey(rootType) ? MinValue[rootType].Invoke(minValue) : null;
        }

        [return : MaybeNull]
        internal static object GetMaxValue(Type type, float maxValue)
        {
            var rootType = GetRootElementType(type);
            return MaxValue.ContainsKey(rootType) ? MaxValue[rootType].Invoke(maxValue) : null;
        }

        #endregion Method
    }
}