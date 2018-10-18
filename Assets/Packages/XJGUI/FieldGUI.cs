using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI : ElementGUI<object>
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
            Bool,    Bools,
            Int,     Ints,
            Float,   Floats,
            Vector2, Vector2s,
            Vector3, Vector3s,
            Vector4, Vector4s,
            Color,   Colors,
            String,  Strings,
            Enum,    Enums,
            Unsupported
        }

        #endregion Enum

        #region Field

        protected readonly List<FieldGUIBase> fieldGUIs = new List<FieldGUIBase>();

        protected readonly List<FieldGUIGroup> fieldGUIGroups = new List<FieldGUIGroup>();

        protected bool hideUnsupportedGUI;

        #endregion Field

        #region Property

        public bool HideUnsupportedGUI
        {
            get { return this.hideUnsupportedGUI; }
            set { this.hideUnsupportedGUI = value; }
        }

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
            this.hideUnsupportedGUI = XJGUILayout.DefaultHideUnsupportedGUI;
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
                fieldInfo = fieldInfos[i];
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

        private FieldGUIInfo GenerateAttribute(FieldInfo info)
        {
            FieldGUIInfo attribute = Attribute.GetCustomAttribute(info, typeof(FieldGUIInfo)) as FieldGUIInfo;

            if (attribute == null)
            {
                attribute = new FieldGUIInfo();
                attribute.Title = FieldGUI.ToTitleCase(info.Name);

                return attribute;
            }

            if (attribute.Title == null)
            {
                attribute.Title = FieldGUI.ToTitleCase(info.Name);
            }

            return attribute;
        }

        private FieldGUIBase GenerateGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            Type guiType;
            Type genericType;

            FieldGUIType fieldGUIType = GetFieldGUIType(data, fieldInfo, guiInfo);

            switch (fieldGUIType)
            {
                case FieldGUIType.Bool:     return new FieldGUIs.BoolGUI    (data, fieldInfo, guiInfo);
                case FieldGUIType.Bools:    return new FieldGUIs.BoolsGUI   (data, fieldInfo, guiInfo);
                case FieldGUIType.Int:      return new FieldGUIs.IntGUI     (data, fieldInfo, guiInfo);
                case FieldGUIType.Ints:     return new FieldGUIs.IntsGUI    (data, fieldInfo, guiInfo);
                case FieldGUIType.Float:    return new FieldGUIs.FloatGUI   (data, fieldInfo, guiInfo);
                case FieldGUIType.Floats:   return new FieldGUIs.FloatsGUI  (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector2:  return new FieldGUIs.Vector2GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector2s: return new FieldGUIs.Vector2sGUI(data, fieldInfo, guiInfo);
                case FieldGUIType.Vector3:  return new FieldGUIs.Vector3GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector3s: return new FieldGUIs.Vector3sGUI(data, fieldInfo, guiInfo);
                case FieldGUIType.Vector4:  return new FieldGUIs.Vector4GUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Vector4s: return new FieldGUIs.Vector4sGUI(data, fieldInfo, guiInfo);
                case FieldGUIType.Color:    return new FieldGUIs.ColorGUI   (data, fieldInfo, guiInfo);
                case FieldGUIType.Colors:   return new FieldGUIs.ColorsGUI  (data, fieldInfo, guiInfo);
                case FieldGUIType.String:
                    if (guiInfo.IPv4)       return new FieldGUIs.IPv4GUI    (data, fieldInfo, guiInfo);
                    else                    return new FieldGUIs.StringGUI  (data, fieldInfo, guiInfo);
                case FieldGUIType.Strings:
                    if (guiInfo.IPv4)       return new FieldGUIs.IPv4sGUI   (data, fieldInfo, guiInfo);
                    else                    return new FieldGUIs.StringsGUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Enum:
                    guiType = typeof(FieldGUIs.EnumGUI<>);
                    genericType = guiType.MakeGenericType(fieldInfo.FieldType);
                    return (FieldGUIBase)Activator.CreateInstance(genericType, data, fieldInfo, guiInfo);
                case FieldGUIType.Enums:
                    guiType = typeof(FieldGUIs.EnumsGUI<>);
                    genericType = guiType.MakeGenericType(fieldInfo.FieldType.GetGenericArguments()[0]);
                    return (FieldGUIBase)Activator.CreateInstance(genericType, data, fieldInfo, guiInfo);
                default: return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo);
            }
        }

        protected static FieldGUIType GetFieldGUIType(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            Type type = fieldInfo.FieldType;

            if (type.IsPrimitive)
            {
                if (type == typeof(bool))  { return FieldGUIType.Bool;  }
                if (type == typeof(int))   { return FieldGUIType.Int;   }
                if (type == typeof(float)) { return FieldGUIType.Float; }
            }

            if (type.IsValueType)
            {
                if (type == typeof(Vector2)) { return FieldGUIType.Vector2; }
                if (type == typeof(Vector3)) { return FieldGUIType.Vector3; }
                if (type == typeof(Vector4)) { return FieldGUIType.Vector4; }
                if (type == typeof(Color))   { return FieldGUIType.Color;   }
            }

            if (type == typeof(string)) { return FieldGUIType.String; }
            if (type.IsEnum)            { return FieldGUIType.Enum;   }

            if (fieldInfo.GetValue(data) is IList)
            {
                if (type.IsArray)
                {
                    type = type.GetElementType();
                }
                else
                {
                    Type[] types = type.GetGenericArguments();

                    if (types.Length == 1)
                    {
                        type = types[0];
                    }
                }

                if (type.IsPrimitive)
                {
                    if (type == typeof(int))   { return FieldGUIType.Ints;   }
                    if (type == typeof(float)) { return FieldGUIType.Floats; }
                    if (type == typeof(bool))  { return FieldGUIType.Bools;  }
                }

                if (type.IsValueType)
                {
                    if (type == typeof(Vector2)) { return FieldGUIType.Vector2s; }
                    if (type == typeof(Vector3)) { return FieldGUIType.Vector3s; }
                    if (type == typeof(Vector4)) { return FieldGUIType.Vector4s; }
                    if (type == typeof(Color))   { return FieldGUIType.Colors;   }
                }

                if (type == typeof(string)) { return FieldGUIType.Strings; }
                if (type.IsEnum)            { return FieldGUIType.Enums;   }
            }

            return FieldGUIType.Unsupported;
        }

        protected static string ToTitleCase(string text)
        {
            if (text == null)
            {
                return text;
            }

            int textLength = text.Length;

            if (textLength == 0)
            {
                return text;
            }

            if (textLength == 1)
            {
                return new string(new char[]
                {
                    char.ToUpper(text[0])
                });
            }

            for (int i = 0; i < textLength - 1; i++)
            {
                if ((char.IsLower(text[i]) && (char.IsUpper(text[i + 1]) || char.IsDigit(text[i + 1])))
                 || (char.IsDigit(text[i]) && char.IsUpper(text[i + 1])))
                {
                    text = text.Insert(i + 1, " ");
                }
            }

            return char.ToUpper(text[0]) + text.Substring(1);

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