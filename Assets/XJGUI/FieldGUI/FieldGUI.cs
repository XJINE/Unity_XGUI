using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUI
    {
        #region Enum

        public enum FieldType
        {
            Int,
            Ints,
            Float,
            Floats,
            Vector2,
            Vector2s,
            Vector3,
            Vector3s,
            Vector4,
            Vector4s,
            Bool,
            Enum,
            Unsupported
        }

        #endregion Enum

        #region Field

        protected readonly List<FieldGUIBase> fieldGUIs = new List<FieldGUIBase>();

        #endregion Field

        #region Constructor

        public FieldGUI(System.Object data)
        {
            GenerateGUIs(data);
        }

        #endregion Constructor

        #region Method

        private void GenerateGUIs(System.Object data)
        {
            FieldInfo[] fieldInfos = data.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                return;
            }

            FieldInfo fieldInfo;
            FieldGUIInfo fieldAttribute;

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                fieldInfo = fieldInfos[i];
                fieldAttribute = GenerateAttribute(fieldInfo);

                if (fieldAttribute.HideInGUI)
                {
                    continue;
                }

                FieldGUIBase gui = GenerateGUI(data, fieldInfo, fieldAttribute);

                this.fieldGUIs.Add(gui);
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

        private FieldGUIBase GenerateGUI(System.Object data, FieldInfo info, FieldGUIInfo attribute)
        {
            FieldType fieldType = GetFieldType(info);

            switch (fieldType)
            {
                case FieldType.Int:
                    return new FieldGUIComponents.IntGUI(data, info, attribute);
                case FieldType.Float:
                    return new  FieldGUIComponents.FloatGUI(data, info, attribute);
                //case FieldType.Vector2:
                //    return new  FieldGUIComponents.Vector2GUI(data, info, attribute);
                //case FieldType.Vector3:
                //    return new  FieldGUIComponents.Vector3GUI(data, info, attribute);
                //case FieldType.Vector4:
                //    return new  FieldGUIComponents.Vector4GUI(data, info, attribute);
                //case FieldType.Bool:
                //    return new  FieldGUIComponents.BoolGUI(data, info, attribute);
                case FieldType.Enum:
                    Type enumTypeGUI = typeof(FieldGUIComponents.EnumGUI<>);
                    Type genericType = enumTypeGUI.MakeGenericType(info.FieldType);
                    return (FieldGUIBase)Activator.CreateInstance(genericType, data, info, attribute);
                    //case FieldType.Vector2Array:
                    //    return new  FieldGUIComponents.Vector2ArrayGUI(data, info, attribute);
                    //case FieldType.Unsupported:
                    //    {
                    //        if (attribute.IPv4)
                    //        {
                    //            return new  FieldGUIComponents.IPv4GUI(data, info, attribute);
                    //        }

                    //        return new  FieldGUIComponents.UnSupportedGUI(data, info, attribute);
                    //    }
                    //default:
                    //    return new  FieldGUIComponents.UnSupportedGUI(data, info, attribute);
            }

            return null;
        }

        public void Show()
        {
            for (int i = 0; i < this.fieldGUIs.Count; i++)
            {
                this.fieldGUIs[i].Show();
            }
        }

        protected void Save()
        {
            foreach (FieldGUIBase fieldGUI in this.fieldGUIs)
            {
                //fieldGUI.Save();
            }
        }

        protected void Load()
        {
            foreach (FieldGUIBase fieldGUI in this.fieldGUIs)
            {
                //fieldGUI.Load();
            }
        }

        protected static FieldType GetFieldType(FieldInfo info)
        {
            Type type = info.FieldType;

            if (type.IsPrimitive)
            {
                if (type == typeof(int))
                {
                    return FieldType.Int;
                }

                if (type == typeof(float))
                {
                    return FieldType.Float;
                }

                if (type == typeof(bool))
                {
                    return FieldType.Bool;
                }

                return FieldType.Unsupported;
            }

            if (type.IsEnum)
            {
                return FieldType.Enum;
            }

            if (type.IsValueType)
            {
                if (type == typeof(Vector2))
                {
                    return FieldType.Vector2;
                }

                if (type == typeof(Vector3))
                {
                    return FieldType.Vector3;
                }

                if (type == typeof(Vector4))
                {
                    return FieldType.Vector4;
                }
            }

            if (type.IsArray)
            {
                type = type.GetElementType();

                if (type == typeof(Vector2))
                {
                    return FieldType.Vector2s;
                }
            }

            return FieldType.Unsupported;
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