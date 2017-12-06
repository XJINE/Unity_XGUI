using UnityEngine;

namespace XJGUI
{
    public class BoolGUI : ElementBaseGUI<bool>
    {
        #region Method

        public override bool Show()
        {
            XJGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle();

                GUILayout.FlexibleSpace();

                base.Value = GUILayout.Toggle(base.Value, "");
            });

            return base.Value;
        }

        #endregion Method
    }
}