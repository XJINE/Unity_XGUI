﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    public class FloatsGUI : FieldGUIComponent<IList<float>>
    {
        #region Constructor

        public FloatsGUI(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
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
            return value1 != value2 ? 0 : -1;
        }

        public override void SetValue(object value, int index = -1)
        {
            base.SetValue(value, index);
        }

        #endregion Method
    }
}