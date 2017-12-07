using System.Collections.Generic;
using System.Reflection;

namespace XJGUI.FieldGUIComponents
{
    // NOTE:
    // There is no way to get the selected value.
    // So this is useless.

    public class Toolbar<T> : FieldGUIComponent<T>
    {
        #region Constructor

        public Toolbar(System.Object data, FieldInfo fieldInfo, FieldGUIInfo guiInfo)
            : base(data, fieldInfo, guiInfo)
        {
            base.Unsupported = true;
        }

        #endregion Constructor

        #region Method

        protected override void Save()
        {
            // NOTE:
            // Nodata is must be save.
        }

        protected override void Load()
        {
            IList<T> values = (IList<T>)base.fieldInfo.GetValue(base.data);

            if (values != null && values.Count != 0)
            {
                this.gui.Value = values[0];
            }
            else
            {
                this.gui.Value = default(T);
            }
        }

        protected override void InitializeGUI()
        {
            T value;
            IList<T> values = (IList<T>)base.fieldInfo.GetValue(base.data);
            int valuesCount = 0;
            int girdX = 0;
            bool foldOut = false;

            if (values == null)
            {
                value = default(T);
            }
            else
            {
                value = values[0];
                valuesCount = values.Count;
            }

            if (valuesCount >= 4)
            {
                girdX = 3;
            }
            if (valuesCount > 10)
            {
                girdX = 5;
                foldOut = true;
            }

            base.gui = new XJGUI.Toolbar<T>
            {
                Value = value,
                Values = values,
                Title = base.guiInfo.Title,
                BoldTitle = base.guiInfo.BoldTitle,
                GridX = girdX,
                Foldout = foldOut,
            };
        }

        #endregion Method
    }
}