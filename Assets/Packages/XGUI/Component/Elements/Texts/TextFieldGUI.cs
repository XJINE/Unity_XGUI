using UnityEngine;

namespace XGUI
{
    public abstract class TextFieldGUI<T> : Element<T>
    {
        #region Property

        public virtual float Width { get; set; }

        protected virtual GUIStyle FieldStyle => new GUIStyle(GUI.skin.textField);

        protected GUILayoutOption FieldLayout =>
            Width <= 0 ? GUILayout.ExpandWidth(true)
                       : GUILayout.Width(Width);

        #endregion Property

        #region Constructor

        protected TextFieldGUI() { }

        protected TextFieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void ShowTitle(bool dummyTitle = false)
        {
            base.ShowTitle(Width > 0 && base.Title == null);
        }

        protected string ShowTextField(string text)
        {
            return GUILayout.TextField(text, FieldStyle, FieldLayout);
        }

        #endregion Method
    }
}