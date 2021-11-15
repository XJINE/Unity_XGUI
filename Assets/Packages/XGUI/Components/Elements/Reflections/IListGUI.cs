using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public class IListGUI<TItem, TList> : ElementGUI<TList> where TList : IList<TItem>
    {
        #region Field

        private readonly List<ElementGUI<TItem>> _guis  = new ();
        private readonly FoldoutPanel _foldoutPanel = new ();
        private readonly ScrollPanel  _scrollPanel  = new ();

        private Type _guiType;

        #endregion Field

        #region Property

        public override string Title
        {
            get => _foldoutPanel.Title;
            set => _foldoutPanel.Title = value;
        }

        // CAUTION:
        // TItem gets IList or unsupported value in sometimes.
        // So it cant define MinValue/MaxValue type.

        private object _minValue;
        public object MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                foreach (var gui in _guis) { ReflectionHelper.SetProperty(gui, "MinValue", value); }
            }
        }

        private object _maxValue;
        public object MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                foreach (var gui in _guis) { ReflectionHelper.SetProperty(gui, "MaxValue", value); }
            }
        }

        private int _digits = XGUILayout.DefaultDigits;
        public int Digits
        {
            get => _digits;
            set
            {
                _digits = value;
                foreach (var gui in _guis) { ReflectionHelper.SetProperty(gui, "Digits", value); }
            }
        }

        private bool _slider = XGUILayout.DefaultSlider;
        public bool Slider
        {
            get => _slider;
            set
            {
                _slider = value;
                foreach (var gui in _guis) { ReflectionHelper.SetProperty(gui, "Slider", value); }
            }
        }

        public float Width
        {
            get => _scrollPanel.Width;
            set => _scrollPanel.Width = value;
        }
        
        public float Height
        {
            get => _scrollPanel.Height;
            set => _scrollPanel.Height = value;
        }

        public float MinWidth
        {
            get => _scrollPanel.MinWidth;
            set => _scrollPanel.MinWidth = value;
        }

        public float MinHeight
        {
            get => _scrollPanel.MinHeight;
            set => _scrollPanel.MinHeight = value;
        }

        public float MaxWidth
        {
            get => _scrollPanel.MaxWidth;
            set => _scrollPanel.MaxWidth = value;
        }

        public float MaxHeight
        {
            get => _scrollPanel.MaxHeight;
            set => _scrollPanel.MaxHeight = value;
        }

        #endregion Property

        #region Constructor

        public IListGUI() { }

        public IListGUI(string title) : base(title) { }

        public IListGUI(string title, object minValue, object maxValue) : base(title)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public IListGUI(string title, object minValue, object maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }

        public IListGUI(string title, float minValue, float maxValue) : base(title)
        {
            // NOTE:
            // Setup Min/Max with float value is only available in Constructor.

            var type = typeof(TItem);
            MinValue = ReflectionHelper.GetMinValue(type, minValue);
            MaxValue = ReflectionHelper.GetMaxValue(type, maxValue);
        }

        public IListGUI(string title, float minValue, float maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }
        
        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            _guiType = ReflectionHelper.GetGUIType(typeof(TItem));
        }

        public override TList Show(TList values)
        {
            _foldoutPanel.Show(() =>
            {
                _scrollPanel.Show(() =>
                {
                    var valuesCount = values != null ? values.Count : 0;
                    var guisCount   = _guis.Count;
                    var countDiff   = guisCount - valuesCount;

                    if (valuesCount == 0)
                    {
                        GUILayout.Label("No Element");
                        return;
                    }

                    if (0 < countDiff)
                    {
                        _guis.RemoveRange(guisCount - 1 - countDiff, countDiff);
                    }
                    else
                    {
                        for (var i = 0; i < -countDiff; i++)
                        {
                            // CAUTION:
                            // _minValue and _maxValue are defined as object.
                            // If do not check null, they will get 0.
                            // And if do not so, they get default GUI values.

                            var gui = (ElementGUI<TItem>)(_guiType == null ? new UnSupportedGUI()
                                                                           : Activator.CreateInstance(_guiType));
                            gui.Title = "Element " + (guisCount + i);

                            if (_minValue != null) { ReflectionHelper.SetProperty(gui, "MinValue", _minValue); }
                            if (_maxValue != null) { ReflectionHelper.SetProperty(gui, "MaxValue", _maxValue); }
                                                     ReflectionHelper.SetProperty(gui, "Digits",   _digits);
                                                     ReflectionHelper.SetProperty(gui, "Slider",   _slider);
                            
                            _guis.Add(gui);
                        }
                    }

                    for (var i = 0; i < valuesCount; i++)
                    {
                        values[i] = _guis[i].Show(values[i]);
                    }
                });

            });

            return values;
        }

        #endregion Method
    }
}