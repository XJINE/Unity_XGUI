using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XGUI
{
    // NOTE:
    // FieldGUI has some bad points.
    // - It takes high cost to set the Min/Max or any other properties.
    //    - Using string key is bad. It occurs some human error and it needs to know the field name.
    // - Its difficult to remove some fields.
    //    - Even if it has some unexpected fields in parent class.

    // NOTE:
    // Introduce custom GUI attribute is not good.
    // - Its difficult to add attribute into parent class field.
    // - Such class cant reuse in another projects.
    //     - The dependencies becomes strong.
    
    [ObsoleteAttribute]
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

        #endregion Class

        #region Field

        private readonly List<FieldGUIInfo> _guiInfos = new ();
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
            GenerateGUI();
        }

        private void GenerateGUI()
        {
            var fieldInfos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (fieldInfos.Length == 0)
            {
                _unsupportedGUI = new UnSupportedGUI
                {
                    Title = base.Title ?? typeof(T).ToString()
                };

                return;
            }

            foreach (var fieldInfo in fieldInfos)
            {
                // var guiType = typeof(ElementGUI<>).MakeGenericType(fieldInfo.FieldType);
                var gui = ReflectionHelper.GenerateGUI(fieldInfo.FieldType, true);

                _guiInfos.Add(new FieldGUIInfo(fieldInfo, gui));
            }
            
            Debug.Log("HERE : " + fieldInfos.Length);
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

        public override T Show(T value)
        {
            if (IsUnSupported)
            {
                _unsupportedGUI.Show(0);
                return value;
            }

            // CAUTION:
            // Because struct couldn't set a value directly, the value needs to be boxed.

            object boxedValue = value;

            foreach (var info in _guiInfos)
            {
                var guiType = info.GUI.GetType();

                // if (HideUnsupportedGUI)
                // {
                //     var property = guiType.GetProperty("IsUnSupported");
                //
                //     if (property != null && (bool)(property.GetValue(info.GUI)))
                //     {
                //         continue;
                //     }
                // }

                var showMethod     = guiType.GetMethod("Show");
                var showMethodArgs = new [] { info.FiledInfo.GetValue(boxedValue) };
                var returnValue    = showMethod.Invoke(info.GUI, showMethodArgs);

                info.FiledInfo.SetValue(boxedValue, returnValue);
            }

            return (T)boxedValue;
        }

        #region SetProperty

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
            foreach (var info in _guiInfos)
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

        #endregion SetProperty

        #endregion Method
    }
}