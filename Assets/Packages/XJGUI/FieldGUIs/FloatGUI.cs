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
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = base.guiInfo.MinValue,
                MaxValue  = base.guiInfo.MaxValue,
                Decimals  = base.guiInfo.Decimals,
                Value     = (float)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            this.gui.Value = float.Parse(value);
        }

        public override string GetSyncValue()
        {
            return base.updated ? this.gui.Value.ToString("G") : null;
        }

        #endregion Method
    }
}