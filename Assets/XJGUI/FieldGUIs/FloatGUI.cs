using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatGUI : FieldGUIComponent<float>
    {
        #region Constructor

        public FloatGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.FloatGUI()
            {
                Value = (float)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = base.guiInfo.MinValue,
                MaxValue = base.guiInfo.MaxValue,
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(float value1, float value2)
        {
            return value1 == value2 ? -1 : 0;
        }

        #endregion Method
    }
}