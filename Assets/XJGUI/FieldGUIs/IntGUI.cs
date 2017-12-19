using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntGUI : FieldGUIComponent<int>
    {
        #region Constructor

        public IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.IntGUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = (int)base.guiInfo.MinValue,
                MaxValue  = (int)base.guiInfo.MaxValue,
                Value     = (int)base.fieldInfo.GetValue(base.data),
            };
        }

        protected override void SetSyncValueToGUI(string value)
        {
            this.gui.Value = int.Parse(value);
        }

        public override string GetSyncValue()
        {
            return base.updated ? base.gui.Value.ToString("G") : null;
        }

        #endregion Method
    }
}