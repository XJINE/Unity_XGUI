﻿using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class BoolGUI : FieldGUIComponent<bool>
    {
        #region Constructor

        public BoolGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            base.gui = new XJGUI.BoolGUI()
            {
                Value     = (bool)base.fieldInfo.GetValue(base.data),
                Title     = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
            };
        }

        #endregion Method
    }
}