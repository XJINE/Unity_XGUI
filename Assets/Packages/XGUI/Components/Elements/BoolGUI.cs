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
            var previousValue = value;

            const string emptyText = "";

            XGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle(base.Title == null);

                GUILayout.FlexibleSpace();

                value = GUILayout.Toggle(value, emptyText);
            });

            Updated = previousValue != value;

            return value;
        }

        #endregion Method
    }
}