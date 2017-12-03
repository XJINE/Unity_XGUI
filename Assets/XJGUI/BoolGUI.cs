using UnityEngine;

namespace XJGUI
{
    public class BoolGUI : ComponentBaseGUI<bool>
    {
        #region Method

        public override bool Show()
        {
            XJGUILayout.HorizontalLayout(()=>
            {
                base.ShowTitle();

                GUILayout.FlexibleSpace();

                base.value = GUILayout.Toggle(base.value, "");
            });

            return base.value;
        }

        #endregion Method
    }
}