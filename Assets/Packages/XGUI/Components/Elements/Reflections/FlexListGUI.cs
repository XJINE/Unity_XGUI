using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public class FlexListGUI<TElement, TList> : ListBaseGUI<TElement, TList>
                               where TList    : IList<TElement>
    {
        #region Field

        private Type _guiType;

        #endregion Field

        #region Property

        // CAUTION:
        // TElement gets IList or unsupported value in sometimes.
        // So it can't define MinValue/MaxValue type.

        private object _minValue;
        public object MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                foreach (var gui in _guiList) { ReflectionHelper.SetProperty(gui, "MinValue", value); }
            }
        }

        private object _maxValue;
        public object MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                foreach (var gui in _guiList) { ReflectionHelper.SetProperty(gui, "MaxValue", value); }
            }
        }

        private int _digits = XGUILayout.DefaultDigits;
        public int Digits
        {
            get => _digits;
            set
            {
                _digits = value;
                foreach (var gui in _guiList) { ReflectionHelper.SetProperty(gui, "Digits", value); }
            }
        }

        private bool _slider = XGUILayout.DefaultSlider;
        public bool Slider
        {
            get => _slider;
            set
            {
                _slider = value;
                foreach (var gui in _guiList) { ReflectionHelper.SetProperty(gui, "Slider", value); }
            }
        }

        #endregion Property

        #region Constructor

        public FlexListGUI() { }

        public FlexListGUI(string title) : base(title) { }

        public FlexListGUI(string title, object minValue, object maxValue) : base(title)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public FlexListGUI(string title, object minValue, object maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }

        public FlexListGUI(string title, float minValue, float maxValue) : base(title)
        {
            // NOTE:
            // Setup Min/Max with float value is only available in Constructor.

            var type = typeof(TElement);
            MinValue = ReflectionHelper.GetMinValue(type, minValue);
            MaxValue = ReflectionHelper.GetMaxValue(type, maxValue);
        }

        public FlexListGUI(string title, float minValue, float maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }
        
        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            _guiType = ReflectionHelper.GetGUIType(typeof(TElement));
        }

        protected override ElementGUI<TElement> GenerateGUI()
        {
            // CAUTION:
            // _minValue and _maxValue are defined as object.
            // If do not check null, they will get 0.
            // And if do not so, they get default GUI values.

            var gui = (ElementGUI<TElement>)(_guiType == null ? new UnSupportedGUI()
                                                              : Activator.CreateInstance(_guiType));

            if (_minValue != null) { ReflectionHelper.SetProperty(gui, "MinValue", _minValue); }
            if (_maxValue != null) { ReflectionHelper.SetProperty(gui, "MaxValue", _maxValue); }
                                     ReflectionHelper.SetProperty(gui, "Digits",   _digits);
                                     ReflectionHelper.SetProperty(gui, "Slider",   _slider);
            return gui;
        }

        protected override string GetElementTitle(TElement value, ElementGUI<TElement> gui)
        {
            if (value.GetType().IsEnum)
            {
                return value.ToString();
            }

            var digitsObject = ReflectionHelper.GetProperty(gui, "Digits");
            var digitsFormat = "F" + (digitsObject == null ? 4 : (int)digitsObject);

            return value switch
            {
                string     v => v,
                int        v => v.ToString(),
                float      v => v.ToString(digitsFormat),
                Vector2    v => v.ToString(digitsFormat),
                Vector3    v => v.ToString(digitsFormat),
                Vector4    v => v.ToString(digitsFormat),
                Color      v => v.ToString(digitsFormat),
                Vector2Int v => v.ToString(),
                Vector3Int v => v.ToString(),
                Matrix4x4  v => "(" + v.m00.ToString(digitsFormat)
                              + "," + v.m10.ToString(digitsFormat)
                              + "," + v.m20.ToString(digitsFormat)
                              + "," + v.m30.ToString(digitsFormat)
                              + ")…",
                           _ => "Element"
            };
        }

        #endregion Method
    }
}