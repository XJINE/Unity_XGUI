using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class ColorGUI : FieldGUIElement<Color>
    {
        #region Constructor

        public ColorGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.ColorGUI()
            {
                Title = guiInfo.Title,

                MinValue = guiInfo.MinValue == null ?
                           XJGUILayout.DefaultMinValueColor : (Color)guiInfo.MinValue,

                MaxValue = guiInfo.MaxValue == null ?
                           XJGUILayout.DefaultMaxValueColor : (Color)guiInfo.MaxValue,

                Decimals = guiInfo.Decimals == null ?
                           XJGUILayout.DefaultDecimals : (int)guiInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}