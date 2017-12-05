using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class FloatGUI : FieldGUIComponent<float>
    {
        #region Constructor

        public FloatGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
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
            };
        }

        #endregion Method
    }
}