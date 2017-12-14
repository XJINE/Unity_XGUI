using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3sGUI : FieldGUIComponent<IList<Vector3>>
    {
        #region Constructor

        public Vector3sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector3sGUI()
            {
                Value = (IList<Vector3>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector3(base.guiInfo.MinValue,
                                       base.guiInfo.MinValue,
                                       base.guiInfo.MinValue),
                MaxValue = new Vector3(base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue,
                                       base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(IList<Vector3> value1, IList<Vector3> value2)
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
            ((ValuesGUI<Vector3>)base.gui).SetValue((Vector3)value, index);
        }

        #endregion Method
    }
}