using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector4sGUI : FieldGUIComponent<IList<Vector4>>
    {
        #region Constructor

        public Vector4sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector4sGUI()
            {
                Value = (IList<Vector4>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector4(base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue),
                MaxValue = new Vector4(base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(IList<Vector4> value1, IList<Vector4> value2)
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
            ((ValuesGUI<Vector4>)base.gui).SetValue((Vector4)value, index);
        }

        #endregion Method
    }
}