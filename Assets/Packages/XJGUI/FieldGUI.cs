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
            public object    gui;

            public FieldGUIInfo(FieldInfo info, object gui)
            {
                this.info = info;
                this.gui  = gui;
            }
        }

        private class GUIGroup
        {
            public FoldoutPanel       panel = new FoldoutPanel();
            public List<FieldGUIInfo> infos = new List<FieldGUIInfo>();

            public string Title
            {
                get => this.panel.Title;
                set => this.panel.Title = value;
            }
        }

        #endregion Class

        #region Field

        private readonly List<GUIGroup> guiGroups = new List<GUIGroup>() { new GUIGroup() };

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

                GUIAttribute guiAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(GUIAttribute)) as GUIAttribute;
                guiAttribute = guiAttribute ?? new GUIAttribute();
                guiAttribute.Title = guiAttribute.Title ?? GetTitleCase(fieldInfo.Name);

                if (Attribute.GetCustomAttribute(fieldInfo, typeof(RangeAttribute)) is RangeAttribute rangeAttribute)
                {
                    guiAttribute.MinValue = float.IsNaN(guiAttribute.MinValue) ? rangeAttribute.min : guiAttribute.MinValue;
                    guiAttribute.MaxValue = float.IsNaN(guiAttribute.MaxValue) ? rangeAttribute.max : guiAttribute.MaxValue;
                }

                if (Attribute.GetCustomAttribute(fieldInfo, typeof(HeaderAttribute)) is HeaderAttribute headerAttribute)
                {
                    this.guiGroups.Add(new GUIGroup() { Title = headerAttribute.header });
                }

                if (guiAttribute.Hide)
                {
                    continue;
                }

                object gui = ReflectionHelper.Generate(typeInfo,
                                                       guiAttribute.Title,
                                                       guiAttribute.MinValue,
                                                       guiAttribute.MaxValue,
                                                       guiAttribute.Width);

                this.guiGroups[this.guiGroups.Count - 1].infos.Add(new FieldGUIInfo(fieldInfo, gui));
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