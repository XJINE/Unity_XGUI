using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntGUI : FieldGUIElement<int>
    {
        #region Constructor

        public IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.IntGUI()
            {
                Title = base.GUIInfo.Title,

                FieldWidth = guiInfo.FieldWidth == null ?
                             XJGUILayout.DefaultFieldWidthValue : (float)guiInfo.FieldWidth,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueInt : (int)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueInt : (int)guiInfo.MaxValue,
            };
        }

        #endregion Constructor
    }
}