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

        private readonly List<FieldGUIInfo> infos = new List<FieldGUIInfo>();

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

                this.infos.Add(new FieldGUIInfo()
                {
                    fieldInfo = fieldInfo,
                    typeInfo  = typeInfo,
                    guiInfo   = guiInfo,
                    gui       = GenerateGUI(fieldInfo, typeInfo, guiInfo)
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
            HeaderAttribute header = Attribute.GetCustomAttribute
                (fieldInfo, typeof(HeaderAttribute)) as HeaderAttribute;

            return header?.header;
        }

        private static object GenerateGUI(FieldInfo fieldInfo, TypeInfo typeInfo, GUIInfo guiInfo)
        {
            Type   type  = typeInfo.type;
            string title = guiInfo.Title ?? fieldInfo.Name;
            float  min   = guiInfo.Min;
            float  max   = guiInfo.Max;

            if (typeInfo == null) { return new UnSupportedGUI() { Title = title }; }
            if (typeInfo.isIList) { return new UnSupportedGUI() { Title = title }; }

            if (type == typeof(bool))       { return new BoolGUI      () { Title = title }; }
            if (type == typeof(int))        { return new IntGUI       () { Title = title }; }
            if (type == typeof(float))      { return new FloatGUI     () { Title = title }; }
            if (type == typeof(Vector2))    { return new Vector2GUI   () { Title = title }; }
            if (type == typeof(Vector3))    { return new Vector3GUI   () { Title = title }; }
            if (type == typeof(Vector4))    { return new Vector4GUI   () { Title = title }; }
            if (type == typeof(Vector2Int)) { return new Vector2IntGUI() { Title = title }; }
            if (type == typeof(Vector3Int)) { return new Vector3IntGUI() { Title = title }; }
            if (type == typeof(Color))      { return new ColorGUI     () { Title = title }; }
            if (type == typeof(Matrix4x4))  { return new Matrix4x4GUI () { Title = title }; }
            if (type == typeof(string))
            {
                if (guiInfo.IPv4) { return new IPv4GUI   () { Title = title }; }
                else              { return new StringGUI () { Title = title }; }
            }
            if (typeInfo.type.IsEnum)
            {
                return new EnumGUI() { Title = title };
            }

            // 構造体, クラス, リストを考慮しない。

            return null;
        }

        public override T Show(T value)
        {
            foreach (var info in this.infos)
            {
                if (info.guiInfo.Hide) { continue; }

                Type type = info.typeInfo.type.IsEnum ? typeof(Enum) : info.typeInfo.type;

                info.fieldInfo.SetValue(value, ShowGUI[type](value, info));
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
            { typeof(Enum),       (v, i) => { return ((EnumGUI)       i.gui).Show((Enum)       i.fieldInfo.GetValue(v)); } },
            { typeof(string),     (v, i) =>
            {
                if(i.guiInfo.IPv4) return ((IPv4GUI)   i.gui).Show((string) i.fieldInfo.GetValue(v));
                else               return ((StringGUI) i.gui).Show((string) i.fieldInfo.GetValue(v));
            }},
        };

        #endregion Method
    }
}