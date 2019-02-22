using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI : Element<object>
    {
        #region Enum

        protected enum FieldGUIType
        {
            Bool,
            Int,
            Float,
            Vector2,
            Vector3,
            Vector4,
            Color,
            Vector2Int,
            Vector3Int,
            String,
            Enum,
            Unsupported
        }

        #endregion Enum

        #region Field

        protected readonly List<FieldGUIBase> fieldGUIs = new List<FieldGUIBase>();

        protected readonly FoldoutPanel foldoutPanel = new FoldoutPanel();

        #endregion Field

        #region Property

        public bool HideUnsupportedGUI { get; set; }

        public bool Foldout
        {
            get { return this.foldoutPanel.Value;  }
            set { this.foldoutPanel.Value = value; }
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

        public FieldGUI() : base()
        {
            this.HideUnsupportedGUI = XJGUILayout.DefaultHideUnsupportedGUI;
            this.Foldout = XJGUILayout.DefaultFieldGUIFoldout;
        }

        #endregion constructor

        #region Method

        private void GenerateGUIs(object data)
        {
            FieldInfo[] fieldInfos = data.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                return;
            }

            FieldInfo fieldInfo;
            FieldGUIInfo guiInfo;

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                fieldInfo = fieldInfos[i];
                guiInfo = GetFieldGUIInfo(fieldInfo);

                if (guiInfo.Hide)
                {
                    continue;
                }

                FieldGUIBase gui = GenerateGUI(data, fieldInfo, guiInfo);

                this.fieldGUIs.Add(gui);
            }
        }

        private static FieldGUIInfo GetFieldGUIInfo(FieldInfo fieldInfo)
        {
            FieldGUIInfo guiInfo = Attribute.GetCustomAttribute(fieldInfo, typeof(FieldGUIInfo)) as FieldGUIInfo;

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

        private static FieldGUIBase GenerateGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            FieldGUI.GetFieldGUIType(data, fieldInfo, out Type type, out bool typeIsIList);

            if (typeIsIList) { return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo); }

            if (type == typeof(bool))       { return new FieldGUIs.BoolGUI      (data, fieldInfo, guiInfo); }
            if (type == typeof(int))        { return new FieldGUIs.IntGUI       (data, fieldInfo, guiInfo); }
            if (type == typeof(float))      { return new FieldGUIs.FloatGUI     (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector2))    { return new FieldGUIs.Vector2GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector3))    { return new FieldGUIs.Vector3GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector4))    { return new FieldGUIs.Vector4GUI   (data, fieldInfo, guiInfo); }
            if (type == typeof(Vector2Int)) { return new FieldGUIs.Vector2IntGUI(data, fieldInfo, guiInfo); }
            if (type == typeof(Vector3Int)) { return new FieldGUIs.Vector3IntGUI(data, fieldInfo, guiInfo); }
            if (type == typeof(Color))      { return new FieldGUIs.ColorGUI     (data, fieldInfo, guiInfo); }
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

            return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo);
        }

        protected static void GetFieldGUIType(object data, FieldInfo fieldInfo, out Type type, out bool typeIsIList)
        {
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
            this.foldoutPanel.Title = base.Title ?? base.Value.GetType().Name;
            this.foldoutPanel.Show(() =>
            {
                for (int i = 0; i < this.fieldGUIs.Count; i++)
                {
                    if (this.fieldGUIs[i].Unsupported && this.HideUnsupportedGUI)
                    {
                        continue;
                    }

                    this.fieldGUIs[i].Show();
                }
            });

            return this.Value;
        }

        #endregion Method
    }
}