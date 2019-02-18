using UnityEngine;

namespace XJGUI
{
    public class BoolGUI : ElementGUI<bool>
    {
        #region Constructor

        public BoolGUI() : base()
        {
            base.Value = XJGUILayout.DefaultValueBool;
        }

        #endregion Constructor

        #region Method

        public override bool Show()
        {
            XJGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle(base.Title == null);

                GUILayout.FlexibleSpace();

                base.Value = GUILayout.Toggle((bool)base.Value, "");
            });

            return base.Value;
        }

        #endregion Method
    }
}