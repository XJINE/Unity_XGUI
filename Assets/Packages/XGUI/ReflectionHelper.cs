using System;
using System.Collections.Generic;
using UnityEngine;
using static XGUILayout;

namespace XGUI
{
    public static class ReflectionHelper
    {
        #region Field

        private static Type IListGUIType = typeof(IListGUI<>);
        private static Type EnumGUIType  = typeof(EnumGUI<>);
        private static Type FieldGUIType = typeof(FieldGUI<>);

        private static readonly Dictionary<Type, Type> GUIType = new Dictionary<Type, Type>()
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

        private static readonly Dictionary<Type, Func<float, object>> MinValue = new Dictionary<Type, Func<float, object>>()
        {
            { typeof(int),        (min) => { return float.IsNaN(min) ? DefaultMinValueInt        : (int)min;                                     } },
            { typeof(float),      (min) => { return float.IsNaN(min) ? DefaultMinValueFloat      : min;                                          } },
            { typeof(Vector2),    (min) => { return float.IsNaN(min) ? DefaultMinValueVector2    : new Vector2(min, min);                        } },
            { typeof(Vector3),    (min) => { return float.IsNaN(min) ? DefaultMinValueVector3    : new Vector3(min, min, min);                   } },
            { typeof(Vector4),    (min) => { return float.IsNaN(min) ? DefaultMinValueVector4    : new Vector4(min, min, min, min);              } },
            { typeof(Vector2Int), (min) => { return float.IsNaN(min) ? DefaultMinValueVector2Int : new Vector2Int((int)min, (int)min);           } },
            { typeof(Vector3Int), (min) => { return float.IsNaN(min) ? DefaultMinValueVector3Int : new Vector3Int((int)min, (int)min, (int)min); } },
            { typeof(Color),      (min) => { return float.IsNaN(min) ? DefaultMinValueColor      : new Color(min, min, min, min);                } },
            { typeof(Matrix4x4),  (min) => { return float.IsNaN(min) ? DefaultMinValueMatrix4x4  : new Matrix4x4(new Vector4(min, min, min, min),
                                                                                                                 new Vector4(min, min, min, min),
                                                                                                                 new Vector4(min, min, min, min),
                                                                                                                 new Vector4(min, min, min, min)); } },
        };

        private static readonly Dictionary<Type, Func<float, object>> MaxValue = new Dictionary<Type, Func<float, object>>()
        {
            { typeof(int),        (max) => { return float.IsNaN(max) ? DefaultMaxValueInt        : (int)max;                                     } },
            { typeof(float),      (max) => { return float.IsNaN(max) ? DefaultMaxValueFloat      : max;                                          } },
            { typeof(Vector2),    (max) => { return float.IsNaN(max) ? DefaultMaxValueVector2    : new Vector2(max, max);                        } },
            { typeof(Vector3),    (max) => { return float.IsNaN(max) ? DefaultMaxValueVector3    : new Vector3(max, max, max);                   } },
            { typeof(Vector4),    (max) => { return float.IsNaN(max) ? DefaultMaxValueVector4    : new Vector4(max, max, max, max);              } },
            { typeof(Vector2Int), (max) => { return float.IsNaN(max) ? DefaultMaxValueVector2Int : new Vector2Int((int)max, (int)max);           } },
            { typeof(Vector3Int), (max) => { return float.IsNaN(max) ? DefaultMaxValueVector3Int : new Vector3Int((int)max, (int)max, (int)max); } },
            { typeof(Color),      (max) => { return float.IsNaN(max) ? DefaultMaxValueColor      : new Color(max, max, max, max);                } },
            { typeof(Matrix4x4),  (max) => { return float.IsNaN(max) ? DefaultMaxValueMatrix4x4  : new Matrix4x4(new Vector4(max, max, max, max),
                                                                                                                 new Vector4(max, max, max, max),
                                                                                                                 new Vector4(max, max, max, max),
                                                                                                                 new Vector4(max, max, max, max)); } },
        };

        #endregion Field

        #region Method

        public static object Generate(TypeInfo typeInfo,
                                      string   title = null,
                                      float    min   = float.NaN,
                                      float    max   = float.NaN,
                                      float    width = float.NaN)
        {
            Type   guiType   = null;
            object minObject = null;
            object maxObject = null;

            width = float.IsNaN(width) ? DefaultWidth : width;

            if (typeInfo.isIList)
            {
                guiType = IListGUIType.MakeGenericType(typeInfo.type);
            }
            else if (typeInfo.type.IsEnum)
            {
                guiType = EnumGUIType.MakeGenericType(typeInfo.type); ;
            }
            else if (GUIType.ContainsKey(typeInfo.type))
            {
                guiType   = GUIType[typeInfo.type];
                minObject = MinValue.ContainsKey(typeInfo.type) ?
                            MinValue[typeInfo.type].Invoke(min) : minObject;
                maxObject = MaxValue.ContainsKey(typeInfo.type) ?
                            MaxValue[typeInfo.type].Invoke(max) : maxObject;
            }
            else
            {
                guiType = FieldGUIType.MakeGenericType(typeInfo.type);
            }

            object gui = Activator.CreateInstance(guiType);

            guiType.GetProperty("Title")?.SetValue(gui, title);
            guiType.GetProperty("MinValue")?.SetValue(gui, minObject);
            guiType.GetProperty("MaxValue")?.SetValue(gui, maxObject);
            guiType.GetProperty("Width")?.SetValue(gui, width);

            return gui;
        }

        #endregion Method
    }
}