using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntsGUI : FieldGUIComponent<IList<int>>
    {
        #region Constructor

        public IntsGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.IntsGUI()
            {
                Value = (IList<int>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = (int)base.guiInfo.MinValue,
                MaxValue = (int)base.guiInfo.MaxValue,
            };
        }

        protected override int CheckUpdate(IList<int> value1, IList<int> value2)
        {
            for (int i = 0; i < value1.Count; i++)
            {
                if (value1[i] == value2[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public override void SetValue(object value, int index = -1)
        {
            ((ValuesGUI<int>)base.gui).SetValue((int)value, index);
        }

        #endregion Method
    }
}