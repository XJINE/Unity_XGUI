using System.Reflection;

namespace XJGUI.FieldGUIs
{
    // CAUTION
    // FieldGUI must not be initialize with GetValueFromInstance().
    // So set the value in constructor.

    public class FieldGUI : FieldGUIElement<object>
    {
        #region Constructor

        public FieldGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.FieldGUI()
            {
                Value = base.FieldInfo.GetValue(base.Data)
            };
        }

        #endregion Constructor

        #region Method

        protected override void GetValueFromInstance()
        {
            // Nothing to do.
        }

        protected override void SetValueToInstance()
        {
            // Nothing to do.
        }

        #endregion Method
    }
}