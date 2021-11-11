using UnityEngine;

namespace XGUI
{
    public class BoolGUI : ElementGUI<bool>
    {
        #region Constructor

        public BoolGUI() { }

        public BoolGUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        public override bool Show(bool value)
        {
            const string emptyText = "";

            XGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle(base.Title == null);

                GUILayout.FlexibleSpace();

                value = GUILayout.Toggle(value, emptyText);
            });

            return value;
        }

        #endregion Method
    }
}