using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2sGUI : FieldGUIComponent<IList<Vector2>>
    {
        #region Constructor

        public Vector2sGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.Vector2sGUI()
            {
                Value = (IList<Vector2>)base.fieldInfo.GetValue(base.data),
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                MinValue = new Vector2(base.guiInfo.MinValue, base.guiInfo.MinValue),
                MaxValue = new Vector2(base.guiInfo.MaxValue, base.guiInfo.MaxValue),
                Decimals = base.guiInfo.Decimals,
            };
        }

        protected override int CheckUpdate(IList<Vector2> value1, IList<Vector2> value2)
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
            ((ValuesGUI<Vector2>)base.gui).SetValue((Vector2)value, index);
        }

        #endregion Method
    }
}