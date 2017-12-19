using System;
using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class BoolsGUI : FieldGUIComponents<bool>
    {
        #region Constructor

        public BoolsGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.BoolsGUI()
            {
                Value     = (IList<bool>)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        public override void SetSyncValue(int index, string value)
        {
            DebugEx.Log("HERE1 : " + base.gui.Value + " / " + base.gui.Value[0]);

            base.fieldInfo.SetValue(base.data, new List<bool>() { false, false, false });
            ((ElementsGUI<bool>)base.gui).Value = new List<bool>() { false, false, false };
            //((ElementsGUI<bool>)base.gui).SetValue(index, Convert.ToBoolean(value));

            DebugEx.Log("HERE2 : " + base.gui.Value + " / " + base.gui.Value[0]);
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = base.updateIndex;
            value = index < 0 ? null : base.gui.Value[index].ToString();
        }

        #endregion Method
    }
}