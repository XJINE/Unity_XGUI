using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class FloatsGUI : FieldGUIComponent<IList<float>>
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
                Value = (IList<float>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = base.guiInfo.MinValue,
                MaxValue = base.guiInfo.MaxValue,
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(IList<float> value1, IList<float> value2)
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
            ((ValuesGUI<float>)base.gui).SetValue((float)value, index);
        }

        #endregion Method
    }
}