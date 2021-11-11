using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // Introduce custom GUI attribute is not good.
    // - Its difficult to add attribute into parent class field.
    // - Such class cant reuse in another projects.
    //     - The dependencies becomes strong.

    public class FieldGUI<T> : ElementGUI<T>
    {
        #region Class

        private class FieldGUIInfo
        {
            public readonly FieldInfo FiledInfo;
            public readonly object    GUI;

            public FieldGUIInfo(FieldInfo info, object gui)
            {
                FiledInfo = info;
                GUI       = gui;
            }
        }

        private class GUIGroup
        {
            public readonly FoldoutPanel       Panel = new ();
            public readonly List<FieldGUIInfo> Infos = new ();

            public string Title
            {
                get => Panel.Title;
                set => Panel.Title = value;
            }
        }

        #endregion Class

        #region Field

        private readonly List<GUIGroup> _guiGroups = new () { new GUIGroup() };

        private UnSupportedGUI _unsupportedGUI;

        #endregion Field

        #region Property

        public bool IsUnSupported => _unsupportedGUI != null;

        public bool HideUnsupportedGUI { get; set; } = XGUILayout.DefaultHideUnsupportedGUI;

        #endregion Property

        #region Constructor

        public FieldGUI() { }

        public FieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            GenerateGUI(typeof(T));
            Foldout(true);
        }

        private void GenerateGUI(Type type)
        {
            var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfos.Length == 0)
            {
                _unsupportedGUI = new UnSupportedGUI();
                return;
            }

            foreach (var fieldInfo in fieldInfos)
            {
                var typeInfo = TypeInfo.GetTypeInfo(fieldInfo.FieldType);
                    typeInfo.Type = typeInfo.IsIList ? fieldInfo.FieldType : typeInfo.Type;

                var gui = ReflectionHelper.GenerateGUI(typeInfo, GetTitleCase(fieldInfo.Name));

                _guiGroups[_guiGroups.Count - 1].Infos.Add(new FieldGUIInfo(fieldInfo, gui));
            }
        }

        protected static string GetTitleCase(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return title;
            }

            switch (title.Length)
            {
                case 0:
                    return title;
                case 1:
                    return new string(new[]{char.ToUpper(title[0])});
            }

            for (var i = 0; i < title.Length - 1; i++)
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

        public void Foldout(bool open, bool all = false)
        {
            for (var i = 0; i < (all ? _guiGroups.Count : 1); i++)
            {
                _guiGroups[i].Panel.Value = open;
            }
        }

        public override T Show(T value)
        {
            if (IsUnSupported)
            {
                _unsupportedGUI.Title = base.Title ?? typeof(T).ToString();
                _unsupportedGUI.Show(0);
                return value;
            }

            // CAUTION:
            // Because struct couldn't set a value directly, the value needs to be boxed.

            object boxedValue = value;

            _guiGroups[0].Panel.Title = base.Title ?? typeof(T).ToString();
            _guiGroups[0].Panel.Show(() =>
            {
                ShowGUI(boxedValue, _guiGroups[0].Infos);

                for (var i = 1; i < _guiGroups.Count; i++)
                {
                    _guiGroups[i].Panel.Show(() =>
                    {
                        ShowGUI(boxedValue, _guiGroups[i].Infos);
                    });
                }
            });

            return (T)boxedValue;
        }

        private void ShowGUI(object value, List<FieldGUIInfo> infos)
        {
            foreach (var info in infos)
            {
                var guiType = info.GUI.GetType();

                if (HideUnsupportedGUI)
                {
                    var property = guiType.GetProperty("IsUnSupported");

                    if (property != null && (bool)(property.GetValue(info.GUI)))
                    {
                        continue;
                    }
                }

                var showMethod     = guiType.GetMethod("Show");
                var showMethodArgs = new [] { info.FiledInfo.GetValue(value) };

                info.FiledInfo.SetValue(value, showMethod.Invoke(info.GUI, showMethodArgs));
            }
        }

        public void SetMinValue(string fieldName, object value)
        {
            SetProperty(fieldName, "MinValue", value);
        }

        public void SetMaxValue(string fieldName, object value)
        {
            SetProperty(fieldName, "MaxValue", value);
        }

        public void SetDigits(string fieldName, int value)
        {
            SetProperty(fieldName, "Digits", value);
        }

        public void SetWidth(string fieldName, float value)
        {
            SetProperty(fieldName, "Width", value);
        }

        public void SetSlider(string fieldName, bool value)
        {
            SetProperty(fieldName, "Slider", value);
        }

        private void SetProperty(string fieldName, string propertyName, object value)
        {
            foreach (var guiGroup in _guiGroups)
            {
                foreach (var info in guiGroup.Infos)
                {
                    if (info.FiledInfo.Name != fieldName)
                    {
                        continue;
                    }

                    var property = info.GUI.GetType().GetProperty(propertyName);

                    if (property == null)
                    {
                        continue;
                    }

                    try
                    {
                        property.SetValue(info.GUI, value);
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                    }
                }
            }
        }

        #endregion Method
    }
}