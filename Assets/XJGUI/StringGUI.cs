using UnityEngine;

namespace XJGUI
{
    public class StringGUI : ElementGUI<string>
    {
        #region Field

        protected float textFieldWidth;

        #endregion Field

        #region Property

        public float TextFieldWidth
        {
            get { return this.textFieldWidth; }
            set { this.textFieldWidth = value; }
        }

        #endregion Property

        #region Constructor

        public StringGUI()
        {
            this.textFieldWidth = XJGUILayout.DefaultTextFieldWidthString;
        }

        #endregion Constructor

        #region Method

        public override string Show()
        {
            XJGUILayout.HorizontalLayout(() => 
            {
                base.ShowTitle();

                base.Value = GUILayout.TextField
                    (base.Value, this.TextFieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                                          : GUILayout.Width(this.TextFieldWidth));
            });

            return base.Value;
        }

        #endregion Method
    }
}