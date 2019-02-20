using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector4GUI : FieldGUIElement<Vector4>
    {
        #region Constructor

        public Vector4GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector4GUI()
            {
                Title    = base.GUIInfo.Title,
                MinValue = new Vector4(base.GUIInfo.MinValue, base.GUIInfo.MinValue, base.GUIInfo.MinValue, base.GUIInfo.MinValue),
                MaxValue = new Vector4(base.GUIInfo.MaxValue, base.GUIInfo.MaxValue, base.GUIInfo.MaxValue, base.GUIInfo.MaxValue),
                Decimals = base.GUIInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}