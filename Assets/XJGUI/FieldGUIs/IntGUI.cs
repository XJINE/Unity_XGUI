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

        public override void SetSyncValue(int index, string value)
        {
            this.gui.Value = int.Parse(value);
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = base.gui.Value.ToString("G");
        }

        #endregion Method
    }
}