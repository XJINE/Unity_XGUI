﻿using System.Reflection;

namespace XJGUI.FieldGUIs
{
    public class IntGUI : FieldGUIElement<int>
    {
        #region Constructor

        public IntGUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.IntGUI()
            {
                Title      = guiInfo.Title,
                FieldWidth = guiInfo.FieldWidthIsSet ? guiInfo.FieldWidth : XJGUILayout.DefaultFieldWidthValue,
                MinValue   = guiInfo.MinValueIsSet ? (int)guiInfo.MinValue : XJGUILayout.DefaultMinValueInt,
                MaxValue   = guiInfo.MaxValueIsSet ? (int)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueInt,
            };
        }

        #endregion Constructor
    }
}