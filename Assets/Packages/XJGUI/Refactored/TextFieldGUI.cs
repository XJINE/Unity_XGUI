using UnityEngine;

namespace XJGUI
{
    public abstract class TextFieldGUI<T> : ElementGUI<T>
    {
        #region Property

        public virtual float FieldWidth { get; set; }

        protected virtual GUIStyle FieldStyle
        {
            get { return new GUIStyle(GUI.skin.textField); }
        }

        protected virtual GUILayoutOption FieldLayout
        {
            get
            {
                return this.FieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                            : GUILayout.Width(this.FieldWidth);
            }
        }

        #endregion Property

        #region Method

        protected override void ShowTitle(bool dummyTitle = false)
        {
            base.ShowTitle(this.FieldWidth > 0 && base.Title == null);
        }

        protected virtual string ShowTextField(string text)
        {
            return GUILayout.TextField(text, this.FieldStyle, this.FieldLayout);
        }

        #endregion Method
    }
}