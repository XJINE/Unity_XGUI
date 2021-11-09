﻿using UnityEngine;

namespace XGUI
{
    public abstract class TextFieldGUI<T> : Element<T>
    {
        #region Property

        public virtual float Width { get; set; }

        private static GUIStyle _FieldStyle;
        protected virtual GUIStyle FieldStyle
        {
            get
            {
                _FieldStyle ??= new GUIStyle(GUI.skin.textField);
                return _FieldStyle;
            }
        }

        protected GUILayoutOption FieldLayout =>
            Width <= 0 ? GUILayout.ExpandWidth(true)
                       : GUILayout.Width(Width);

        #endregion Property

        #region Constructor

        protected TextFieldGUI() { }

        protected TextFieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void ShowTitle(bool blank = false)
        {
            base.ShowTitle(blank || (0 < Width && base.Title == null));
        }

        protected string ShowTextField(string text)
        {
            return GUILayout.TextField(text, FieldStyle, FieldLayout);
        }

        #endregion Method
    }
}