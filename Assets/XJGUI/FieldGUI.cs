using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI
    {
        #region Enum

        public enum FieldGUIType
        {
            Bool,    Bools,
            Int,     Ints,
            Float,   Floats,
            Vector2, Vector2s,
            Vector3, Vector3s,
            Vector4, Vector4s,
            String,  Strings,
            Enum,
            Unsupported
        }

        #endregion Enum

        #region Field

        protected readonly List<FieldGUIBase> guis = new List<FieldGUIBase>();

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

        #endregion Property

        #region Constructor

        public FieldGUI(object data)
        {
            GenerateGUIs(data);

            this.GUIs = new ReadOnlyCollection<FieldGUIBase>(this.guis);
        }

        #endregion Constructor

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
            FieldGUIType guiType;

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                fieldInfo = fieldInfos[i];
                guiInfo = GenerateAttribute(fieldInfo);

                if (guiInfo.Hide)
                {
                    continue;
                }

                FieldGUIBase gui = GenerateGUI(data, fieldInfo, guiInfo, out guiType);

                this.guis.Add(gui);
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

        private FieldGUIBase GenerateGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo, out FieldGUIType fieldGUIType)
        {
            Type guiType;
            Type genericType;

            fieldGUIType = GetFieldGUIType(data, fieldInfo, guiInfo);

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
                case FieldGUIType.String:
                    if (guiInfo.IPv4)       return new FieldGUIs.IPv4GUI    (data, fieldInfo, guiInfo);
                    else                    return new FieldGUIs.StringGUI  (data, fieldInfo, guiInfo);
                case FieldGUIType.Strings:  return new FieldGUIs.StringsGUI (data, fieldInfo, guiInfo);
                case FieldGUIType.Enum:
                    guiType = typeof(FieldGUIs.EnumGUI<>);
                    genericType = guiType.MakeGenericType(fieldInfo.FieldType);
                    return (FieldGUIBase)Activator.CreateInstance(genericType, data, fieldInfo, guiInfo);

                default: return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiInfo);
            }
        }

        public void Show()
        {
            for (int i = 0; i < this.guis.Count; i++)
            {
                if (this.guis[i].IsUnsupported && this.HideUnsupportedGUI)
                {
                    continue;
                }

                this.guis[i].Show();
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
            }

            if (type == typeof(string))
            {
                return FieldGUIType.String;
            }

            if (type.IsEnum)
            {
                return FieldGUIType.Enum;
            }

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
                }

                if (type == typeof(string)) { return FieldGUIType.Strings; }
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
                if (char.IsLower(text[i]) && (char.IsUpper(text[i + 1]) || char.IsDigit(text[i + 1])))
                {
                    text = text.Insert(i + 1, " ");
                }
            }

            return char.ToUpper(text[0]) + text.Substring(1);

            // NOTE:
            // This is not good. Only first character becomes uppercase.
            // return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        #endregion Method
    }
}