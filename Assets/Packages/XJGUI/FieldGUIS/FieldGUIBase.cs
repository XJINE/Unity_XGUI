using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    public abstract class FieldGUIBase
    {
        #region Filed

        protected object       data;
        protected FieldInfo    fieldInfo;
        protected FieldGUIInfo guiInfo;
        protected bool updated;

        #endregion Field

        #region Property

        public bool Unsupported { get; protected set; }

        #endregion Property

        #region Constructor

        public FieldGUIBase(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
        {
            this.data      = data;
            this.fieldInfo = fieldInfo;
            this.guiInfo   = guiInfo;

            InitializeGUI();
            Load();
        }

        #endregion Constrcutor

        #region Method

        protected abstract void InitializeGUI();

        protected abstract void ShowGUI();

        protected abstract void Save();

        protected abstract void Load();

        public abstract void SetTitleColor(Color? color);

        public void Show()
        {
            ShowGUI();
            Save();
        }

        #endregion Method
    }
}