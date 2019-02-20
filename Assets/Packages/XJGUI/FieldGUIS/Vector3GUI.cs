using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class Vector3GUI : FieldGUIElement<Vector3>
    {
        #region Constructor

        public Vector3GUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.gui = new XJGUI.Vector3GUI()
            {
                Title    = base.GUIInfo.Title,
                MinValue = new Vector3(base.GUIInfo.MinValue, base.GUIInfo.MinValue, base.GUIInfo.MinValue),
                MaxValue = new Vector3(base.GUIInfo.MaxValue, base.GUIInfo.MaxValue, base.GUIInfo.MaxValue),
                Decimals = base.GUIInfo.Decimals,
            };
        }

        #endregion Constructor
    }
}