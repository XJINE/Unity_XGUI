using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGUI
{
    public class FlexListGUI<TElement, TList> : ElementGUI<TList>
                               where TList    : IList<TElement>
    {
        #region Field

        private const float ButtonWidth = 30;

        private readonly FoldoutPanel _foldoutPanel = new ();
        private readonly ScrollPanel  _scrollPanel  = new ();
        private readonly List<(ElementGUI<TElement> gui, FoldoutPanel foldOutPanel)> _guiList = new ();

        private Type _guiType;

        public bool FoldoutList = true;
        public bool Reorderable = true;
        public bool Resizable   = true;
        public bool BoxSkin     = true;

        #endregion Field

        #region Property

        public override string Title
        {
            get => _foldoutPanel.Title;
            set => _foldoutPanel.Title = value;
        }

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

        public override TList Show(TList value)
        {
            var valueCount = value == null ? 0 : value.Count;
            var guiCount   = _guiList.Count;

            while (valueCount < guiCount)
            {
                guiCount -= 1;
                _guiList.RemoveAt(guiCount);
            }

            while (valueCount > guiCount)
            {
                guiCount += 1;

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

                _guiList.Add((gui, new FoldoutPanel()));
            }

            var addList    = new List<int>();
            var removeList = new List<int>();

            var panelAction = new Action(() =>
            {
                if (valueCount == 0)
                {
                    // NOTE:
                    // Show dummy buttons to keep UI layout.

                    XGUILayout.HorizontalLayout(() =>
                    {
                        GUILayout.Label("No Element");
                        GUILayout.FlexibleSpace(); // To Align Right

                        GUI.enabled = false;
                        GUILayout.Button("∧", GUILayout.Width(ButtonWidth));
                        GUILayout.Button("∨", GUILayout.Width(ButtonWidth));
                        if (!typeof(TList).IsArray)
                        {
                            GUI.enabled = Resizable;
                            if (GUILayout.Button("+", GUILayout.Width(ButtonWidth)))
                            {
                                addList.Add(0);
                            }
                            GUI.enabled = false;
                            GUILayout.Button("-", GUILayout.Width(ButtonWidth));
                        }
                        GUI.enabled = true;
                    });
                }
                else
                {
                    for (var i = 0; i < valueCount; i++)
                    {
                        var (gui, foldoutPanel) = _guiList[i];

                        // foldoutPanel.Title = i + " : Element";
                        foldoutPanel.Title = i + " : " + GetTypeFromValue(value[i]);

                        foldoutPanel.ButtonFieldAction = () =>
                        {
                            XGUILayout.HorizontalLayout(() =>
                            {
                                GUILayout.FlexibleSpace(); // To Align Right
                        
                                GUI.enabled = i > 0 && Reorderable;
                                if (GUILayout.Button("∧", GUILayout.Width(ButtonWidth)))
                                {
                                    (value[i], value[i - 1]) = (value[i - 1], value[i]);
                                }
                        
                                GUI.enabled = i < valueCount - 1 && Reorderable;
                                if (GUILayout.Button("∨", GUILayout.Width(ButtonWidth)))
                                {
                                    (value[i], value[i + 1]) = (value[i + 1], value[i]);
                                }
                        
                                if (!typeof(TList).IsArray)
                                {
                                    GUI.enabled = Resizable;
                                    if (GUILayout.Button("+", GUILayout.Width(ButtonWidth))) { addList   .Add(i); }
                                    if (GUILayout.Button("-", GUILayout.Width(ButtonWidth))) { removeList.Add(i); }
                                }
                        
                                GUI.enabled = true;
                            });
                        };

                        foldoutPanel.Show(() =>
                        {
                            value[i] = gui.Show(value[i]);
                            Updated = Updated || gui.Updated;
                        });
                    }
                }
            });

            if (FoldoutList)
            {
                _foldoutPanel.Title = Title;
                _scrollPanel .Title = null;

                _foldoutPanel.BoxSkin = BoxSkin;
                _scrollPanel.BoxSkin  = false;

                _foldoutPanel.Show(() =>
                {
                    _scrollPanel.Show(panelAction);
                });
            }
            else
            {
                _scrollPanel.BoxSkin = BoxSkin;
                _scrollPanel.Title   = Title;

                _scrollPanel.Show(panelAction);
            }

            foreach (var i in addList)
            {
                var elementType = typeof(TElement);
                var newInstance = (TElement)(elementType.IsArray ? Array.CreateInstance(elementType.GetElementType(), 0)
                                                                 : Activator.CreateInstance(elementType));

                value.Insert(i == 0 ? i : i + 1, newInstance);
            }

            foreach (var i in removeList)
            {
                value.RemoveAt(i);
            }

            Updated = Updated || addList.Count != 0 || removeList.Count != 0;

            return value;
        }

        private static string GetTypeFromValue(TElement value)
        {
            if (value.GetType().IsEnum)
            {
                return value.ToString();
            }

            return value switch
            {
                string     v => v.ToString(),
                int        v => v.ToString(),
                float      v => v.ToString("F6"),
                Vector2    v => v.ToString("F2"),
                Vector3    v => v.ToString("F2"),
                Vector4    v => v.ToString("F1"),
                Color      v => v.ToString("F1"),
                Vector2Int v => v.ToString(),
                Vector3Int v => v.ToString(),
                Matrix4x4  v => "(" + v.m00 + "," + v.m10 + "," + v.m20 + "," + v.m30 + ")",
                           _ => "Element"
            };
        }

        #endregion Method
    }
}