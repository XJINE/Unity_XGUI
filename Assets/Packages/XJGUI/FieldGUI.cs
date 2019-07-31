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
            public FieldInfo info;
            public object gui;
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

        #region Constructor

        public FieldGUI() : base() { }

        public FieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            GenerateGUI(typeof(T));
        }

        private void GenerateGUI(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                return;
            }

            for (var i = 0; i < fieldInfos.Length; i++)
            {
                FieldInfo fieldInfo = fieldInfos[i];
                TypeInfo  typeInfo  = TypeInfo.GetTypeInfo(fieldInfo.FieldType);

                typeInfo.type = typeInfo.isIList ? fieldInfo.FieldType : typeInfo.type;

                GUIAttribute guiInfo    = GetGUIInfo(fieldInfo);
                Vector2      rangeInfo  = GetRangeInfo(fieldInfo);
                string       headerInfo = GetHeaderInfo(fieldInfo);

                if (headerInfo != null)
                {
                    var newGroup = new GUIGroup();
                    newGroup.panel.Title = headerInfo;
                    this.guiGroups.Add(newGroup);
                }

                if (guiInfo.Hide)
                {
                    continue;
                }

                object gui = ReflectionHelper.Generate(typeInfo,
                                                       guiInfo.Title,
                                                       rangeInfo.x,
                                                       rangeInfo.y,
                                                       guiInfo.Width);

                this.guiGroups[this.guiGroups.Count - 1].infos.Add(new FieldGUIInfo()
                                                                  {
                                                                      info = fieldInfo,
                                                                      gui = gui
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

        public override T Show(T value)
        {
            // CAUTION:
            // Because struct couldn't set a value directly, the value needs to be boxed.

            object boxedValue = value;

            this.guiGroups[0].panel.Title = base.Title ?? typeof(T).ToString();
            this.guiGroups[0].panel.Show(() =>
            {
                ShowGUI(boxedValue, guiGroups[0].infos);

                for (int i = 1; i < this.guiGroups.Count; i++)
                {
                    this.guiGroups[i].panel.Show(() =>
                    {
                        ShowGUI(boxedValue, guiGroups[i].infos);
                    });
                }
            });

            return (T)boxedValue;
        }

        private void ShowGUI(object value, List<FieldGUIInfo> infos)
        {
            foreach (var info in infos)
            {
                info.info.SetValue(value, info.gui.GetType().GetMethod("Show")
                .Invoke(info.gui, new object[] { info.info.GetValue(value) }));
            }
        }

        #endregion Method
    }
}