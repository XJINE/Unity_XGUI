using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class UnSupportedGUI : FieldGUIBase
    {
        #region Constructor

        public UnSupportedGUI(object data, FieldInfo fieldInfo, FieldGUIInfoAttribute guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
            base.Unsupported = true;
        }

        #endregion Constructor

        #region Method
        
        protected override void Save()
        {
            // Nothing to do.
        }

        protected override void Load()
        {
            // Nothing to do.
        }

        protected override void ShowGUI()
        {
            GUILayout.Label(base.GUIInfo.Title + " is Unsupported");
        }

        #endregion Method
    }
}