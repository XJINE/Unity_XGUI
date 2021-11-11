using UnityEngine;

namespace XGUI
{
    public abstract class TextFieldGUI<T> : ElementGUI<T>
    {
        #region Property

        public virtual float Width { get; set; }

        private static GUIStyle _fieldStyle;
        protected virtual GUIStyle FieldStyle
        {
            get
            {
                _fieldStyle ??= new GUIStyle(GUI.skin.textField);
                return _fieldStyle;
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