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
                Title    = base.GUIInfo.Title,
                MinValue = base.GUIInfo.MinColor,
                MaxValue = base.GUIInfo.MaxColor,
                Decimals = base.GUIInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}