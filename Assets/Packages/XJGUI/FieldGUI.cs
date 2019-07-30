using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI<T> : Element<T>
    {
        #region Class

        private class FieldGUIInfo
        {
            public FieldInfo    fieldInfo;
            public TypeInfo     typeInfo;
            public GUIAttribute guiInfo;
            public object       gui;
        }

        private class GUIGroup
        {
            public FoldoutPanel       panel = new FoldoutPanel();
            public List<FieldGUIInfo> infos = new List<FieldGUIInfo>();
        }

        #endregion Class

        #region Field

        private readonly List<GUIGroup> guiGroups = new List<GUIGroup>()
        {
            new GUIGroup()
        };

        #endregion Field

        #region Property

        public bool HideUnsupportedGUI { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUI() : base() { }

        public FieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.HideUnsupportedGUI = XJGUILayout.DefaultHideUnsupportedGUI;

            GenerateGUIs(typeof(T));
        }

        private void GenerateGUIs(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                return;
            }

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                FieldInfo    fieldInfo  = fieldInfos[i];
                TypeInfo     typeInfo   = TypeInfo.GetTypeInfo(fieldInfo.FieldType);
                GUIAttribute guiInfo    = GetGUIInfo(fieldInfo);
                string       headerInfo = GetHeaderInfo(fieldInfo);
                Vector2      rangeInfo  = GetRangeInfo(fieldInfo);

                if (headerInfo != null)
                {
                    var newGroup = new GUIGroup();
                    newGroup.panel.Title = headerInfo;
                    this.guiGroups.Add(newGroup);
                }

                var gui = GenerateGUI(fieldInfo, typeInfo, guiInfo, rangeInfo);

                this.guiGroups[this.guiGroups.Count - 1].infos.Add
                (new FieldGUIInfo()
                {
                    fieldInfo = fieldInfo,
                    typeInfo  = typeInfo,
                    guiInfo   = guiInfo,
                    gui       = gui
                });
            }
        }

        private static GUIAttribute GetGUIInfo(FieldInfo fieldInfo)
        {
            GUIAttribute guiInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(GUIAttribute)) as GUIAttribute;
                    guiInfo = guiInfo ?? new GUIAttribute();
                    guiInfo.Title = guiInfo.Title ?? GetTitleCase(fieldInfo.Name);

            return guiInfo;
        }

        protected static string GetTitleCase(string title)
        {
            if (title == null)
            {
                return title;
            }

            int textLength = title.Length;

            if (textLength == 0)
            {
                return title;
            }

            if (textLength == 1)
            {
                return new string(new char[]
                {
                    char.ToUpper(title[0])
                });
            }

            for (int i = 0; i < textLength - 1; i++)
            {
                if ((char.IsLower(title[i]) && (char.IsUpper(title[i + 1]) || char.IsDigit(title[i + 1])))
                 || (char.IsDigit(title[i]) && char.IsUpper(title[i + 1])))
                {
                    title = title.Insert(i + 1, " ");
                }
            }

            return char.ToUpper(title[0]) + title.Substring(1);

            // NOTE:
            // Following case is not good. Only first character becomes uppercase.
            // return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        private static string GetHeaderInfo(FieldInfo fieldInfo)
        {
            HeaderAttribute headerAttribute = Attribute.GetCustomAttribute
                (fieldInfo, typeof(HeaderAttribute)) as HeaderAttribute;

            return headerAttribute?.header;
        }

        private static Vector2 GetRangeInfo(FieldInfo fieldInfo)
        {
            RangeAttribute rangeAttribute = Attribute.GetCustomAttribute
                (fieldInfo, typeof(RangeAttribute)) as RangeAttribute;

            return rangeAttribute == null ? new Vector2(float.NaN, float.NaN)
                                          : new Vector2(rangeAttribute.min, rangeAttribute.max);
        }

        private static object GenerateGUI(FieldInfo fieldInfo, TypeInfo typeInfo, GUIAttribute guiInfo, Vector2 rangeInfo)
        {
            Type   type  = typeInfo.type;
            string title = guiInfo.Title ?? fieldInfo.Name;
            float  min   = rangeInfo.x;
            float  max   = rangeInfo.y;
            float  width = guiInfo.Width;

            if (typeInfo == null) { return new UnSupportedGUI() { Title = title }; }

            NEED TO IMPLEMENT

            if (typeInfo.isIList) { return new UnSupportedGUI() { Title = title }; }

            if (type == typeof(bool))
            {
                return new BoolGUI()
                {
                    Title = title
                };
            }
            if (type == typeof(int))
            {
                return new IntGUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueInt : (int)min,
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueInt : (int)max
                };
            }
            if (type == typeof(float))
            {
                return new FloatGUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueFloat : min,
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueFloat : max
                };
            }
            if (type == typeof(Vector2))
            {
                return new Vector2GUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueVector2
                                                    : new Vector2(min, min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueVector2
                                                    : new Vector2(max, max)
                };
            }
            if (type == typeof(Vector3))
            {
                return new Vector3GUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueVector3
                                                    : new Vector3(min, min, min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueVector3
                                                    : new Vector3(max, max, max)
                };
            }
            if (type == typeof(Vector4))
            {
                return new Vector4GUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueVector4
                                                    : new Vector4(min, min, min, min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueVector4
                                                    : new Vector4(max, max, max, max)
                };
            }
            if (type == typeof(Vector2Int))
            {
                return new Vector2IntGUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueVector2Int
                                                    : new Vector2Int((int)min, (int)min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueVector2Int
                                                    : new Vector2Int((int)max, (int)max)
                };
            }
            if (type == typeof(Vector3Int))
            {
                return new Vector3IntGUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueVector3Int
                                                    : new Vector3Int((int)min, (int)min, (int)min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueVector3Int
                                                    : new Vector3Int((int)max, (int)max, (int)max)
                };
            }
            if (type == typeof(Color))
            {
                return new ColorGUI ()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueColor
                                                    : new Color(min, min, min, min),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueColor
                                                    : new Color(max, max, max, max)
                };
            }
            if (type == typeof(Matrix4x4))
            {
                return new Matrix4x4GUI
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthValue : width,
                    MinValue   = float.IsNaN(min)   ? XJGUILayout.DefaultMinValueMatrix4x4 
                                                    : new Matrix4x4(new Vector4(min, min, min, min),
                                                                    new Vector4(min, min, min, min),
                                                                    new Vector4(min, min, min, min),
                                                                    new Vector4(min, min, min, min)),
                    MaxValue   = float.IsNaN(max)   ? XJGUILayout.DefaultMaxValueMatrix4x4
                                                    : new Matrix4x4(new Vector4(max, max, max, max),
                                                                    new Vector4(max, max, max, max),
                                                                    new Vector4(max, max, max, max),
                                                                    new Vector4(max, max, max, max)),
                };
            }
            if (type == typeof(string))
            {
                if (guiInfo.IPv4)
                {
                    return new IPv4GUI()
                    {
                        Title = title
                    };
                }

                return new StringGUI()
                {
                    Title      = title,
                    FieldWidth = float.IsNaN(width) ? XJGUILayout.DefaultFieldWidthString : width,
                };
            }
            if (typeInfo.type.IsEnum)
            {
                object enumGUI = Activator.CreateInstance(typeof(EnumGUI<>).MakeGenericType(fieldInfo.FieldType), title);
                float buttonWidth = float.IsNaN(width) ? XJGUILayout.DefaultButtonWidth : width;

                Type enumGUIType = enumGUI.GetType();
                enumGUIType.GetProperty("Title").SetValue(enumGUI, title);
                enumGUIType.GetProperty("ButtonWidth").SetValue(enumGUI, buttonWidth);

                return enumGUI;
            }

            return Activator.CreateInstance(typeof(FieldGUI<>).MakeGenericType(fieldInfo.FieldType), title);

            //return new UnSupportedGUI() { Title = title };
        }

        public override T Show(T value)
        {
            // CAUTION:
            // Because struct couldn't set a value directly, the value needs to be boxed.

            object boxedValue = value;

            this.guiGroups[0].panel.Title = base.Title ?? typeof(T).ToString();
            this.guiGroups[0].panel.Show(() =>
            {
                ShowGUIs(boxedValue, guiGroups[0].infos);

                for (int i = 1; i < this.guiGroups.Count; i++)
                {
                    this.guiGroups[i].panel.Show(() =>
                    {
                        ShowGUIs(boxedValue, guiGroups[i].infos);
                    });
                }
            });

            return (T)boxedValue;
        }

        private void ShowGUIs(object value, List<FieldGUIInfo> infos)
        {
            foreach (var info in infos)
            {
                if (info.guiInfo.Hide) { continue; }

                if (ShowGUI.ContainsKey(info.typeInfo.type))
                {
                    info.fieldInfo.SetValue(value, ShowGUI[info.typeInfo.type](value, info));
                }
                else // if User struct or class
                {
                    info.fieldInfo.SetValue(value,
                    info.gui.GetType().GetMethod("Show").Invoke
                    (info.gui, new object[] { info.fieldInfo.GetValue(value) }));
                }
            }
        }

        private static readonly Dictionary<Type, Func<object, FieldGUIInfo, object>> ShowGUI
        = new Dictionary<Type, Func<object, FieldGUIInfo, object>>()
        {
            { typeof(bool),       (v, i) => { return ((BoolGUI)       i.gui).Show((bool)       i.fieldInfo.GetValue(v)); } },
            { typeof(int),        (v, i) => { return ((IntGUI)        i.gui).Show((int)        i.fieldInfo.GetValue(v)); } },
            { typeof(float),      (v, i) => { return ((FloatGUI)      i.gui).Show((float)      i.fieldInfo.GetValue(v)); } },
            { typeof(Vector2),    (v, i) => { return ((Vector2GUI)    i.gui).Show((Vector2)    i.fieldInfo.GetValue(v)); } },
            { typeof(Vector3),    (v, i) => { return ((Vector3GUI)    i.gui).Show((Vector3)    i.fieldInfo.GetValue(v)); } },
            { typeof(Vector4),    (v, i) => { return ((Vector4GUI)    i.gui).Show((Vector4)    i.fieldInfo.GetValue(v)); } },
            { typeof(Vector2Int), (v, i) => { return ((Vector2IntGUI) i.gui).Show((Vector2Int) i.fieldInfo.GetValue(v)); } },
            { typeof(Vector3Int), (v, i) => { return ((Vector3IntGUI) i.gui).Show((Vector3Int) i.fieldInfo.GetValue(v)); } },
            { typeof(Color),      (v, i) => { return ((ColorGUI)      i.gui).Show((Color)      i.fieldInfo.GetValue(v)); } },
            { typeof(Matrix4x4),  (v, i) => { return ((Matrix4x4GUI)  i.gui).Show((Matrix4x4)  i.fieldInfo.GetValue(v)); } },
            { typeof(string),     (v, i) =>
            {
                if(i.guiInfo.IPv4) return ((IPv4GUI)   i.gui).Show((string) i.fieldInfo.GetValue(v));
                else               return ((StringGUI) i.gui).Show((string) i.fieldInfo.GetValue(v));
            }},
        };

        #endregion Method
    }
}