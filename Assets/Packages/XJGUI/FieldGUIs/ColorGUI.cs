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
                MinValue = guiInfo.MinValueIsSet ? new Color(guiInfo.MinValue, guiInfo.MinValue, guiInfo.MinValue, guiInfo.MinValue) : XJGUILayout.DefaultMinValueColor,
                MaxValue = guiInfo.MaxValueIsSet ? new Color(guiInfo.MaxValue, guiInfo.MaxValue, guiInfo.MaxValue, guiInfo.MaxValue) : XJGUILayout.DefaultMaxValueColor,
                Decimals = guiInfo.DecimalsIsSet ? guiInfo.Decimals : XJGUILayout.DefaultDecimals
            };
        }

        #endregion Constructor
    }
}