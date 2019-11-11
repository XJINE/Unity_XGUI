using UnityEngine;

namespace XGUI
{
    public abstract class TextFieldGUI<T> : Element<T>
    {
        #region Property

        public virtual float Width { get; set; }

        protected virtual GUIStyle FieldStyle
        {
            get { return new GUIStyle(GUI.skin.textField); }
        }

        protected virtual GUILayoutOption FieldLayout
        {
            get
            {
                return Width <= 0 ? GUILayout.ExpandWidth(true)
                                  : GUILayout.Width(Width);
            }
        }

        #endregion Property

        #region Constructor

        public TextFieldGUI() : base() { }

        public TextFieldGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void ShowTitle(bool dummyTitle = false)
        {
            base.ShowTitle(Width > 0 && base.Title == null);
        }

        protected virtual string ShowTextField(string text)
        {
            return GUILayout.TextField(text, this.FieldStyle, this.FieldLayout);
        }

        #endregion Method
    }
}