using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI : Element<object>
    {
        #region Class

        protected class FieldGUIGroup 
        {
            public readonly FoldoutPanel foldoutPanel = new FoldoutPanel();
            public readonly List<FieldGUIBase> fieldGUIs = new List<FieldGUIBase>();
        }

        #endregion Class

        #region Enum

        public enum FieldGUIType
        {
            Bool,
            Int,
            Float,
            Vector2,
            Vector3,
            Vector4,
            Color,
            String,
            Enum,
            Unsupported
        }

        #endregion Enum

        #region Field

        protected readonly List<FieldGUIBase> fieldGUIs = new List<FieldGUIBase>();

        protected readonly List<FieldGUIGroup> fieldGUIGroups = new List<FieldGUIGroup>();

        #endregion Field

        #region Property

        public bool HideUnsupportedGUI { get; set; }

        public ReadOnlyCollection<FieldGUIBase> GUIs
        {
            get;
            private set;
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
                this.GUIs = new ReadOnlyCollection<FieldGUIBase>(this.fieldGUIs);
                base.Value = value;
            }
        }

        #endregion Property

        #region Constructor

        public FieldGUI() : base()
        {
            this.HideUnsupportedGUI = XJGUILayout.DefaultHideUnsupportedGUI;
            this.fieldGUIGroups.Add(new FieldGUIGroup());
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
            FieldGUIInfo fieldGUIInfo;

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                fieldInfo    = fieldInfos[i];
                fieldGUIInfo = GenerateAttribute(fieldInfo);

                if (fieldGUIInfo.Hide)
                {
                    continue;
                }

                FieldGUIBase gui = GenerateGUI(data, fieldInfo, fieldGUIInfo);

                this.fieldGUIs.Add(gui);

                FieldGUIGroup lastGroup = this.fieldGUIGroups[this.fieldGUIGroups.Count - 1];

                if (lastGroup.foldoutPanel.Title == fieldGUIInfo.Group)
                {
                    lastGroup.fieldGUIs.Add(gui);
                }
                else
                {
                    lastGroup = new FieldGUIGroup();
                    lastGroup.foldoutPanel.Title = fieldGUIInfo.Group;
                    lastGroup.fieldGUIs.Add(gui);

                    this.fieldGUIGroups.Add(lastGroup);
                }
            }
        }

        private FieldGUIInfo GenerateAttribute(FieldInfo fieldInfo)
        {
            FieldGUIInfo attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(FieldGUIInfo)) as FieldGUIInfo;

            if (attribute == null)
            {
                attribute = new FieldGUIInfo();
                attribute.Title = FieldGUI.GetTitleCase(fieldInfo.Name);

                return attribute;
            }

            if (attribute.Title == null)
            {
                attribute.Title = FieldGUI.GetTitleCase(fieldInfo.Name);
            }

            return attribute;
        }

        private FieldGUIBase GenerateGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            Type guiType;
            Type genericType;

            FieldGUIType fieldGUIType = GetFieldGUIType(data, fieldInfo);

            switch (fieldGUIType)
            {
                case FieldGUIType.Bool:     return new FieldGUIs.BoolGUI    (data, fieldInfo, guiInfo);
                case FieldGUIType.Int:      return new FieldGUIs.IntGUI     (data, fieldInfo, guiInfo);
                case FieldGUIType.Float:    return new FieldGUIs.FloatGUI   (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector2:  return new FieldGUIs.Vector2GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector3:  return new FieldGUIs.Vector3GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector4:  return new FieldGUIs.Vector4GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Color:    return new FieldGUIs.ColorGUI   (data, fieldInfo, guiInfo);
                case FieldGUIType.String:
                    if (guiInfo.IPv4)       return new FieldGUIs.IPv4GUI    (data, fieldInfo, guiInfo);
                    else                    return new FieldGUIs.StringGUI  (data, fieldInfo, guiInfo);
                case FieldGUIType.Enum:
                    guiType = typeof(FieldGUIs.EnumGUI<>);
                    genericType = guiType.MakeGenericType(fieldInfo.FieldType);
                    return (FieldGUIBase)Activator.CreateInstance(genericType, data, fieldInfo, guiInfo);

                default: return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo);
            }
        }

        protected static FieldGUIType GetFieldGUIType(object data, FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;

            if (fieldType.IsPrimitive)
            {
                if (fieldType == typeof(bool))  { return FieldGUIType.Bool;  }
                if (fieldType == typeof(int))   { return FieldGUIType.Int;   }
                if (fieldType == typeof(float)) { return FieldGUIType.Float; }
            }

            if (fieldType.IsValueType)
            {
                if (fieldType == typeof(Vector2)) { return FieldGUIType.Vector2; }
                if (fieldType == typeof(Vector3)) { return FieldGUIType.Vector3; }
                if (fieldType == typeof(Vector4)) { return FieldGUIType.Vector4; }
                if (fieldType == typeof(Color))   { return FieldGUIType.Color;   }
            }

            if (fieldType == typeof(string)) { return FieldGUIType.String; }
            if (fieldType.IsEnum)            { return FieldGUIType.Enum;   }

            return FieldGUIType.Unsupported;

            // NOTE:
            // Future work.
            // 
            //if (!(fieldInfo.GetValue(data) is IList)) { return FieldGUIType.Unsupported; }
            //
            //if (fieldType.IsArray)
            //{
            //    fieldType = fieldType.GetElementType();
            //}
            //else
            //{
            //    Type[] types = fieldType.GetGenericArguments();
            //
            //    if (types.Length == 1)
            //    {
            //        fieldType = types[0];
            //    }
            //}
            //
            //if (fieldType.IsPrimitive)
            //{
            //    if (fieldType == typeof(int))   { return FieldGUIType.Ints;   }
            //    if (fieldType == typeof(float)) { return FieldGUIType.Floats; }
            //    if (fieldType == typeof(bool))  { return FieldGUIType.Bools;  }
            //}
            //
            //if (fieldType.IsValueType)
            //{
            //    if (fieldType == typeof(Vector2)) { return FieldGUIType.Vector2s; }
            //    if (fieldType == typeof(Vector3)) { return FieldGUIType.Vector3s; }
            //    if (fieldType == typeof(Vector4)) { return FieldGUIType.Vector4s; }
            //    if (fieldType == typeof(Color))   { return FieldGUIType.Colors;   }
            //}
            //
            //if (fieldType == typeof(string)) { return FieldGUIType.Strings; }
            //if (fieldType.IsEnum)            { return FieldGUIType.Enums;   }
            //
            //return FieldGUIType.Unsupported;
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
            base.ShowTitle();

            for (int i = 0; i < this.fieldGUIGroups.Count; i++)
            {
                FieldGUIGroup fieldGUIGroup = this.fieldGUIGroups[i];

                Action action = () => 
                {
                    for (int j = 0; j < fieldGUIGroup.fieldGUIs.Count; j++)
                    {
                        if (fieldGUIGroup.fieldGUIs[j].Unsupported && this.HideUnsupportedGUI)
                        {
                            continue;
                        }

                        fieldGUIGroup.fieldGUIs[j].Show();
                    }
                };

                if (fieldGUIGroup.foldoutPanel.Title == null)
                {
                    action();
                }
                else 
                {
                    fieldGUIGroup.foldoutPanel.Show(action);
                }
            }

            return this.Value;
        }

        #endregion Method
    }
}