using UnityEngine;

namespace XGUI
{
    public class BoolGUI : Element<bool>
    {
        #region Constructor

        public BoolGUI() : base() { }

        public BoolGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override bool Show(bool value)
        {
            XGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle(base.Title == null);

                GUILayout.FlexibleSpace();

                value = GUILayout.Toggle(value, "");
            });

            return value;
        }

        #endregion Method
    }
}