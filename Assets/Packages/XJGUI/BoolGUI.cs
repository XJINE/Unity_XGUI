using UnityEngine;

namespace XJGUI
{
    public class BoolGUI : Element<bool>
    {
        #region Constructor

        public BoolGUI() : base() { }

        public BoolGUI(string title) : base(title) { }

        public BoolGUI(string title, bool value) : base(title, value) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            base.Value = XJGUILayout.DefaultValueBool;
        }

        public override bool Show()
        {
            XJGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle(base.Title == null);

                GUILayout.FlexibleSpace();

                base.Value = GUILayout.Toggle(base.Value, "");
            });

            return base.Value;
        }

        #endregion Method
    }
}