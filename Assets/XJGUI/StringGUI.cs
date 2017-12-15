using UnityEngine;

namespace XJGUI
{
    public class StringGUI : ElementGUI<string>
    {
        #region Field

        protected float textFieldWidth;

        #endregion Field

        #region Property

        public float FieldWidth
        {
            get { return this.textFieldWidth; }
            set { this.textFieldWidth = value; }
        }

        #endregion Property

        #region Constructor

        public StringGUI()
        {
            this.textFieldWidth = XJGUILayout.DefaultFieldWidthString;
        }

        #endregion Constructor

        #region Method

        public override string Show()
        {
            XJGUILayout.HorizontalLayout(() => 
            {
                // NOTE:
                // Set blank title to align text-field to right.

                string tempTitle = base.Title;

                if (this.FieldWidth > 0 && base.Title == null)
                {
                    base.Title = "";
                }

                base.ShowTitle();

                base.Value = GUILayout.TextField
                    (base.Value, this.FieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                                          : GUILayout.Width(this.FieldWidth));

                base.Title = tempTitle;
            });

            return base.Value;
        }

        #endregion Method
    }
}