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
            base.GUI = new XJGUI.ColorGUI()
            {
                Title    = guiInfo.Title,
                MinValue = guiInfo.MinValueIsSet ? (Color)guiInfo.MinValue : XJGUILayout.DefaultMinValueColor,
                MaxValue = guiInfo.MaxValueIsSet ? (Color)guiInfo.MaxValue : XJGUILayout.DefaultMaxValueColor,
                Decimals = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}