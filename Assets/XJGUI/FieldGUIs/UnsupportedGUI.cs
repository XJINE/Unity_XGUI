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


        public override void SetSyncValue(int index, string value)
        {
            // Nothing to do.
        }

        public override void GetSyncValue(out int index, out string value)
        {
            index = -1;
            value = null;
        }

        #endregion Method
    }
}