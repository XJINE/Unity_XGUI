using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Filed

        protected object data;
        protected FieldInfo fieldInfo;
        protected FieldGUIInfo guiInfo;
        protected bool updated;

        #endregion Field

        #region Property

        public bool Unsupported { get; protected set; }

        public bool Sync { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIBase(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            this.data = data;
            this.fieldInfo = fieldInfo;
            this.guiInfo = guiInfo;

            this.Sync = guiInfo.Sync;

            InitializeGUI();
            Load();
        }

        #endregion Constrcutor

        #region Method

        protected abstract void InitializeGUI();

        protected abstract void Save();

        protected abstract void Load();

        protected abstract void ShowGUI();

        public abstract void SetTitleColor(Color? color);

        public void SetSyncValue(string value)
        {
            SetSyncValueToGUI(value);
            Save();
        }

        protected abstract void SetSyncValueToGUI(string value);

        public abstract string GetSyncValue();

        public void Show()
        {
            ShowGUI();
            Save();
        }

        #endregion Method
    }
}