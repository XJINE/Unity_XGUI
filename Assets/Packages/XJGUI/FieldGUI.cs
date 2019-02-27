using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI : Element<object>
    {
        #region Field

        protected class FieldGUIGroup
        {
            public FoldoutPanel       Panel { get; private set; } = new FoldoutPanel();
            public List<FieldGUIBase> GUIs  { get; private set; } = new List<FieldGUIBase>();
        }

        protected readonly List<FieldGUIGroup> fieldGUIGroups = new List<FieldGUIGroup>()
        {
            new FieldGUIGroup()
        };

        #endregion Field

        #region Property

        public bool HideUnsupportedGUI { get; set; }

        public bool Foldout
        {
            get { return this.fieldGUIGroups[0].Panel.Value;  }
            set { this.fieldGUIGroups[0].Panel.Value = value; }
        }

        public override object Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                GenerateGUIs(value);
                base.Value = value;
            }
        }

        #endregion Property

        #region Constructor

        public FieldGUI() : base() { }

        public FieldGUI(string title) : base(title) { }

        public FieldGUI(object value) : base(null, value) { }

        public FieldGUI(string title, object value) : base(title, value) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            this.HideUnsupportedGUI = XJGUILayout.DefaultHideUnsupportedGUI;
            this.Foldout            = XJGUILayout.DefaultFieldGUIFoldout;
        }

        private void GenerateGUIs(object data)
        {
            // NOTE:
            // Must be reset first.

            if (this.fieldGUIGroups.Count > 1)
            {
                this.fieldGUIGroups.RemoveRange(1, this.fieldGUIGroups.Count);
            }
            this.fieldGUIGroups[0].GUIs.Clear();

            FieldInfo[] fieldInfos = data.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                return;
            }

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                FieldInfo    fieldInfo  = fieldInfos[i];
                FieldGUIInfo guiInfo    = GetFieldGUIInfo(fieldInfo);
                string       headerInfo = GetFieldHeaderInfo(fieldInfo);

                if (guiInfo.Hide)
                {
                    continue;
                }

                if (headerInfo != null)
                {
                    FieldGUIGroup fieldGUIGroup = new FieldGUIGroup();
                    fieldGUIGroup.Panel.Title = headerInfo;
                    this.fieldGUIGroups.Add(fieldGUIGroup);
                }

                this.fieldGUIGroups[this.fieldGUIGroups.Count - 1].GUIs
                    .Add(GenerateGUI(data, fieldInfo, guiInfo));
            }
        }

        private static FieldGUIInfo GetFieldGUIInfo(FieldInfo fieldInfo)
        {
            FieldGUIInfo guiInfo = Attribute.GetCustomAttribute
                (fieldInfo, typeof(FieldGUIInfo)) as FieldGUIInfo;

            if (guiInfo == null)
            {
                guiInfo = new FieldGUIInfo();
                guiInfo.Title = FieldGUI.GetTitleCase(fieldInfo.Name);

                return guiInfo;
            }

            if (guiInfo.Title == null)
            {
                guiInfo.Title = FieldGUI.GetTitleCase(fieldInfo.Name);
            }

            return guiInfo;
        }

        private static string GetFieldHeaderInfo(FieldInfo fieldInfo)
        {
            HeaderAttribute header = Attribute.GetCustomAttribute
                (fieldInfo, typeof(HeaderAttribute)) as HeaderAttribute;

            return header?.header;
        }

        private static FieldGUIBase GenerateGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            FieldGUI.GetFieldGUIType(data, fieldInfo, out Type type, out bool typeIsIList);

            if (data == null || typeIsIList) { return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo); }

            if (type == typeof(bool))       { return new FieldGUIs.BoolGUI      (data, fieldInfo, guiInfo); }
            if (type == typeof(int))        { return new FieldGUIs.IntGUI       (data, fieldInfo, guiInfo); }
            if (type == typeof(float))      { return new FieldGUIs.FloatGUI     (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector2))    { return new FieldGUIs.Vector2GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector3))    { return new FieldGUIs.Vector3GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector4))    { return new FieldGUIs.Vector4GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector2Int)) { return new FieldGUIs.Vector2IntGUI(data, fieldInfo, guiInfo); }
            if (type == typeof(Vector3Int)) { return new FieldGUIs.Vector3IntGUI(data, fieldInfo, guiInfo); }
            if (type == typeof(Color))      { return new FieldGUIs.ColorGUI     (data, fieldInfo, guiInfo); }
            if (type == typeof(Matrix4x4))  { return new FieldGUIs.Matrix4x4GUI (data, fieldInfo, guiInfo); }
            if (type == typeof(bool))       { return new FieldGUIs.BoolGUI      (data, fieldInfo, guiInfo); }
            if (type == typeof(string))
            {
                if (guiInfo.IPv4) { return new FieldGUIs.IPv4GUI  (data, fieldInfo, guiInfo); }
                else              { return new FieldGUIs.StringGUI(data, fieldInfo, guiInfo); }
            }
            if (type.IsEnum)
            {
                return (FieldGUIBase)Activator.CreateInstance
                (typeof(FieldGUIs.EnumGUI<>).MakeGenericType(fieldInfo.FieldType), data, fieldInfo, guiInfo);
            }
            //if (type.IsValueType) // Means any other struct.
            //{
            //    return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo);
            //}

            return new FieldGUIs.FieldGUI(data, fieldInfo, guiInfo);
        }

        protected static void GetFieldGUIType(object data, FieldInfo fieldInfo, out Type type, out bool typeIsIList)
        {
            if (data == null)
            {
                type = null;
                typeIsIList = false;
                return;
            }

            type = fieldInfo.FieldType;
            typeIsIList = false;

            if (!(fieldInfo.GetValue(data) is System.Collections.IList))
            {
                return;
            }

            if (type.IsArray)
            {
                type = type.GetElementType();
                typeIsIList = true;
            }
            else
            {
                Type[] types = type.GetGenericArguments();

                if (types.Length == 1)
                {
                    type = types[0];
                    typeIsIList = true;
                }
            }
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

        public override object Show()
        {
            this.fieldGUIGroups[0].Panel.Title = base.Title ?? base.Value.GetType().Name;
            this.fieldGUIGroups[0].Panel.Show(() =>
            {
                foreach (FieldGUIBase gui in this.fieldGUIGroups[0].GUIs)
                {
                    if (gui.Unsupported && this.HideUnsupportedGUI)
                    {
                        continue;
                    }

                    gui.Show();
                }

                for (int i = 1; i < this.fieldGUIGroups.Count; i++)
                {
                    this.fieldGUIGroups[i].Panel.Show(() =>
                    {
                        foreach (FieldGUIBase gui in this.fieldGUIGroups[i].GUIs)
                        {
                            if (gui.Unsupported && this.HideUnsupportedGUI)
                            {
                                continue;
                            }

                            gui.Show();
                        }
                    });
                }
            });

            return this.Value;
        }

        #endregion Method
    }
}