using UnityEngine;

namespace XJGUI
{
    public class StringGUI : ElementGUI<string>
    {
        #region Property

        public float FieldWidth { get; set; }

        #endregion Property

        #region Constructor

        public StringGUI()
        {
            base.Value      = XJGUILayout.DefaultValueString;
            this.FieldWidth = XJGUILayout.DefaultFieldWidth;
        }

        #endregion Constructor

        #region Method

        public override string Show()
        {
            XJGUILayout.HorizontalLayout(() => 
            {
                base.ShowTitle(this.FieldWidth > 0 && base.Title == null);

                base.Value = GUILayout.TextField
                    ((string)base.Value, this.FieldWidth <= 0 ? GUILayout.ExpandWidth(true)
                                                      : GUILayout.Width(this.FieldWidth));
            });

            return base.Value;
        }

        #endregion Method
    }
}