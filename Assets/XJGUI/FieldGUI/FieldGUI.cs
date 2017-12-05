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
            FieldGUIAttribute guiAttribute;

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                fieldInfo = fieldInfos[i];
                guiAttribute = Attribute.GetCustomAttribute
                    (fieldInfo, typeof(FieldGUIAttribute)) as FieldGUIAttribute;

                if (guiAttribute == null)
                {
                    guiAttribute = new FieldGUIAttribute();
                    guiAttribute.Title = ToTitleCase(fieldInfo.Name);
                }

                if (guiAttribute.HideInGUI)
                {
                    continue;
                }

                FieldGUIBase gui = GenerateGUI(data, fieldInfo, guiAttribute);

                this.fieldGUIs.Add(gui);
            }
        }

        private FieldGUIBase GenerateGUI
            (System.Object data, FieldInfo fieldInfo, FieldGUIAttribute guiAttribute)
        {
            FieldType fieldType = GetFieldType(fieldInfo);

            switch (fieldType)
            {
                case FieldType.Int: return new FieldIntGUI(data, fieldInfo, guiAttribute);
                //case FieldType.Float:
                //    return new FieldGUIs.FloatGUI(data, fieldInfo, guiAttribute);
                //case FieldType.Vector2:
                //    return new FieldGUIs.Vector2GUI(data, fieldInfo, guiAttribute);
                //case FieldType.Vector3:
                //    return new FieldGUIs.Vector3GUI(data, fieldInfo, guiAttribute);
                //case FieldType.Vector4:
                //    return new FieldGUIs.Vector4GUI(data, fieldInfo, guiAttribute);
                //case FieldType.Bool:
                //    return new FieldGUIs.BoolGUI(data, fieldInfo, guiAttribute);
                //case FieldType.Enum:
                //    return new FieldGUIs.EnumGUI(data, fieldInfo, guiAttribute);
                //case FieldType.Vector2Array:
                //    return new FieldGUIs.Vector2ArrayGUI(data, fieldInfo, guiAttribute);
                //case FieldType.Unsupported:
                //    {
                //        if (guiAttribute.IPv4)
                //        {
                //            return new FieldGUIs.IPv4GUI(data, fieldInfo, guiAttribute);
                //        }

                //        return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiAttribute);
                //    }
                //default:
                //    return new FieldGUIs.UnSupportedGUI(data, fieldInfo, guiAttribute);
            }
        }

        public FieldType GetFieldType(FieldInfo fieldInfo)
        {
            Type type = fieldInfo.FieldType;

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

        public void Show()
        {
            for (int i = 0; i < this.fieldGUIs.Count; i++)
            {
                this.fieldGUIs[i].Show();
            }
        }

        public void Save()
        {
            foreach (FieldGUIBase fieldGUI in this.fieldGUIs)
            {
                fieldGUI.Save();
            }
        }

        public void Load()
        {
            foreach (FieldGUIBase fieldGUI in this.fieldGUIs)
            {
                fieldGUI.Load();
            }
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