using UnityEngine;

namespace XJGUI
{
    public class StringGUI : ElementGUI<string>
    {
        #region Field

        #endregion Field

        #region Method

        public override string Show()
        {
            XJGUILayout.HorizontalLayout(() => 
            {
                base.ShowTitle();
                base.Value = GUILayout.TextField(base.Value);
            });

            return base.Value;
        }

        #endregion Method
    }
}