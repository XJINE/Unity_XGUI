using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector2GUI : FieldGUIElement<Vector2>
    {
        #region Constructor

        public Vector2GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector2GUI()
            {
                Title    = base.GUIInfo.Title,
                MinValue = new Vector2(base.GUIInfo.MinValue, base.GUIInfo.MinValue),
                MaxValue = new Vector2(base.GUIInfo.MaxValue, base.GUIInfo.MaxValue),
                Decimals = base.GUIInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}