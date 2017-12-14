using System.Reflection;
using UnityEngine;

namespace XJGUI.FieldGUIs
{
    public class UnSupportedGUI : FieldGUIBase
    {
        #region Constructor

        public UnSupportedGUI(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
            base.IsUnsupported = true;
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI()
        {
            // Nothing to do.
        }

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
            GUILayout.Label("Unsupported Field : " + base.fieldInfo.Name);
        }

        public override void SetValue(object value, int index = -1)
        {
            // Nothing to do.
        }

        public override object GetValue()
        {
            return null;
        }

        #endregion Method
    }
}