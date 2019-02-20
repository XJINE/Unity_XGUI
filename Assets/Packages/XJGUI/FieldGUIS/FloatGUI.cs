using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatGUI : FieldGUIElement<float>
    {
        #region Constructor

        public FloatGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.FloatGUI()
            {
                Title    = base.GUIInfo.Title,
                MinValue = base.GUIInfo.MinValue,
                MaxValue = base.GUIInfo.MaxValue,
                Decimals = base.GUIInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}