using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XJGUI
{
    // NOTE:
    // We cannot set a "where T: struct" because of the "string" allow null.

    public abstract class FieldGUIComponents<T> : FieldGUIComponentBase<IList<T>>
    {
        #region Field

        private int previousFrameCount;

        #endregion Field

        #region Constructor

        public FieldGUIComponents(object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            :base(data, fieldInfo, guiInfo)
        {
        }

        #endregion Constructor

        #region Method

        protected override void Load()
        {
            base.Load();
            base.previousValue = new List<T>(base.gui.Value);
        }

        protected override void ShowGUI()
        {
            this.gui.Show();
            base.updated = GetValueIsUpdated(base.gui.Value, base.previousValue);

            // CAUTION:
            // OnGUI called twice or more in same frame.
            // To detect values count changing, we have to check frame.

            if (this.previousFrameCount != Time.frameCount)
            {
                this.previousFrameCount = Time.frameCount;
                base.previousValue = new List<T>(base.gui.Value);
            }
        }

        // CAUTION:
        // We can't detect an array length is changed from Inspector in CheckGUIsUpdate.
        // Only list is enable.

        protected override bool GetValueIsUpdated(IList<T> value1, IList<T> value2)
        {
            if (value1.Count != value2.Count)
            {
                return true;
            }

            for (int i = 0; i < value1.Count; i++)
            {
                if (!value1[i].Equals(value2[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Method
    }
}