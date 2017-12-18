using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatsGUI : FieldGUIComponents<float>
    {
        #region Constructor

        public FloatsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.FloatsGUI()
            {
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue  = base.guiInfo.MinValue,
                MaxValue  = base.guiInfo.MaxValue,
                Decimals  = base.guiInfo.Decimals,
                Value = (IList<float>)base.fieldInfo.GetValue(base.data),
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            ((ValuesGUI<float>)base.gui).SetValue(index, float.Parse(value));
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : this.gui.Value[index].ToString("G");
        }

        #endregion Method
    }
}