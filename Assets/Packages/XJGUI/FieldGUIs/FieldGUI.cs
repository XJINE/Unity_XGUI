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
            base.GUI = new XJGUI.FieldGUI(base.GUIInfo.Title, base.FieldInfo.GetValue(base.Data));
        }

        #endregion Constructor

        #region Method

        protected override void SetValueToInstance()
        {
            if (base.FieldInfo.FieldType.IsValueType)
            {
                base.FieldInfo.SetValue(base.Data, base.GUI.Value);
            }
        }

        protected override void GetValueFromInstance()
        {
            // Nothing to do.
        }

        #endregion Method
    }
}