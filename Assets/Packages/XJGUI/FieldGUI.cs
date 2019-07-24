using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI<T> : Element<T>
    {
        #region Class

        private class TypeInfo
        {
            public Type type;
            public bool isIList;
        }

        private class FieldGUIInfo
        {
            public FieldInfo fieldInfo;
            public TypeInfo  typeInfo;
            public GUIInfo   guiInfo;
            public object    gui;
        }

        #endregion Class

        #region Field

        List<FieldGUIInfo> fieldGUIInfos = new List<FieldGUIInfo>();

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
                var fieldInfo  = fieldInfos[i];
                var typeInfo   = GetTypeInfo(fieldInfo);
                var guiInfo    = GetGUIInfo(fieldInfo);
                var headerInfo = GetHeaderInfo(fieldInfo);

                if (guiInfo.Hide)
                {
                    continue;
                }

                this.fieldGUIInfos.Add(new FieldGUIInfo()
                {
                    fieldInfo = fieldInfo,
                    typeInfo  = typeInfo,
                    guiInfo   = guiInfo,
                    gui       = GenerateGUI(typeInfo, guiInfo)
                });
            }
        }

        private static TypeInfo GetTypeInfo(FieldInfo fieldInfo)
        {
            TypeInfo typeInfo = new TypeInfo()
            {
                type = fieldInfo.FieldType,
                isIList = false
            };

            if (typeInfo.type.IsArray)
            {
                typeInfo.type = typeInfo.type.GetElementType();
                typeInfo.isIList = true;
            }
            else if(typeInfo.type.IsGenericType && (typeInfo.type.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                Type[] types = typeInfo.type.GetGenericArguments();

                if (types.Length == 1)
                {
                    typeInfo.type = types[0];
                    typeInfo.isIList = true;
                }
            }

            return typeInfo;
        }

        private static GUIInfo GetGUIInfo(FieldInfo fieldInfo)
        {
            GUIInfo guiInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(GUIInfo)) as GUIInfo;
                    guiInfo = guiInfo ?? new GUIInfo();
                    guiInfo.Title = guiInfo.Title ?? GetTitleCase(fieldInfo.Name);

            return guiInfo;
        }

        private static string GetHeaderInfo(FieldInfo fieldInfo)
        {
            HeaderAttribute header = Attribute.GetCustomAttribute
                (fieldInfo, typeof(HeaderAttribute)) as HeaderAttribute;

            return header?.header;
        }

        private static object GenerateGUI(TypeInfo typeInfo, GUIInfo guiInfo)
        {
            if (typeInfo == null) { return new UnSupportedGUI(); }
            if (typeInfo.isIList) { return new UnSupportedGUI(); }

            if (typeInfo.type == typeof(bool))       { return new BoolGUI      (); }
            if (typeInfo.type == typeof(int))        { return new IntGUI       (); }
            if (typeInfo.type == typeof(float))      { return new FloatGUI     (); }
            if (typeInfo.type == typeof(Vector2))    { return new Vector2GUI   (); }
            if (typeInfo.type == typeof(Vector3))    { return new Vector3GUI   (); }
            if (typeInfo.type == typeof(Vector4))    { return new Vector4GUI   (); }
            if (typeInfo.type == typeof(Vector2Int)) { return new Vector2IntGUI(); }
            if (typeInfo.type == typeof(Vector3Int)) { return new Vector3IntGUI(); }
            if (typeInfo.type == typeof(Color))      { return new ColorGUI     (); }
            if (typeInfo.type == typeof(Matrix4x4))  { return new Matrix4x4GUI (); }
            if (typeInfo.type == typeof(string))
            {
                if (guiInfo.IPv4) { return new IPv4GUI   (); }
                else              { return new StringGUI (); }
            }
            if (typeInfo.type.IsEnum)
            {
                return Activator.CreateInstance
                (typeof(EnumGUI<>).MakeGenericType(typeInfo.type));
            }

            // 構造体, クラス, リストを考慮しない。

            return null;
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

        public override T Show(T value)
        {
            foreach (var info in this.fieldGUIInfos)
            {
                info.fieldInfo.SetValue(value, ShowGUI[info.typeInfo.type](value, info));
            }

            return value;

            //this.fieldGUIGroups[0].Panel.Title = base.Title ?? base.Value.GetType().Name;
            //this.fieldGUIGroups[0].Panel.Show(() =>
            //{
            //    foreach (FieldGUIBase gui in this.fieldGUIGroups[0].GUI)
            //    {
            //        if (gui.Unsupported && this.HideUnsupportedGUI)
            //        {
            //            continue;
            //        }

            //        gui.Show();
            //    }

            //    for (int i = 1; i < this.fieldGUIGroups.Count; i++)
            //    {
            //        this.fieldGUIGroups[i].Panel.Show(() =>
            //        {
            //            foreach (FieldGUIBase gui in this.fieldGUIGroups[i].GUI)
            //            {
            //                if (gui.Unsupported && this.HideUnsupportedGUI)
            //                {
            //                    continue;
            //                }

            //                gui.Show();
            //            }
            //        });
            //    }
            //});

            //return this.Value;
        }

        private static readonly Dictionary<Type, Func<object, FieldGUIInfo, object>> ShowGUI
        = new Dictionary<Type, Func<object, FieldGUIInfo, object>>()
        {
            { typeof(bool),       (value, info) => { return ((BoolGUI)       info.gui).Show((bool)       info.fieldInfo.GetValue(value)); } },
            { typeof(int),        (value, info) => { return ((IntGUI)        info.gui).Show((int)        info.fieldInfo.GetValue(value)); } },
            { typeof(float),      (value, info) => { return ((FloatGUI)      info.gui).Show((float)      info.fieldInfo.GetValue(value)); } },
            { typeof(Vector2),    (value, info) => { return ((Vector2GUI)    info.gui).Show((Vector2)    info.fieldInfo.GetValue(value)); } },
            { typeof(Vector3),    (value, info) => { return ((Vector3GUI)    info.gui).Show((Vector3)    info.fieldInfo.GetValue(value)); } },
            { typeof(Vector4),    (value, info) => { return ((Vector4GUI)    info.gui).Show((Vector4)    info.fieldInfo.GetValue(value)); } },
            { typeof(Vector2Int), (value, info) => { return ((Vector2IntGUI) info.gui).Show((Vector2Int) info.fieldInfo.GetValue(value)); } },
            { typeof(Vector3Int), (value, info) => { return ((Vector3IntGUI) info.gui).Show((Vector3Int) info.fieldInfo.GetValue(value)); } },
            { typeof(Color),      (value, info) => { return ((ColorGUI)      info.gui).Show((Color)      info.fieldInfo.GetValue(value)); } },
            { typeof(Matrix4x4),  (value, info) => { return ((Matrix4x4GUI)  info.gui).Show((Matrix4x4)  info.fieldInfo.GetValue(value)); } },
            { typeof(string),     (value, info) =>
            {
                if(info.guiInfo.IPv4) return ((IPv4GUI)   info.gui).Show((string) info.fieldInfo.GetValue(value));
                else                  return ((StringGUI) info.gui).Show((string) info.fieldInfo.GetValue(value));
            }},
        };

        #endregion Method
    }
}