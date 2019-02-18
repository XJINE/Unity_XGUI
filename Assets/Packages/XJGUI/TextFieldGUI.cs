using UnityEngine;

namespace XJGUI
{
    public abstract class TextFieldGUI<T> : ElementGUI<T>
    {
        #region Property

        public virtual float FieldWidth { get; set; }

        protected virtual string Text { get; set; }

        protected virtual GUIStyle TextFieldStyle
        {
            //alignment = TextAnchor.MiddleRight
            get { return new GUIStyle(GUI.skin.textField); }
        }

        protected virtual GUILayoutOption TextFieldLayout
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

        protected virtual void ShowTextField()
        {
            this.Text = GUILayout.TextField(this.Text, this.TextFieldStyle, this.TextFieldLayout);
        }

        #endregion Method
    }
}