using System.Collections.Generic;

namespace XJGUI
{
    public abstract class ValuesGUI<T> : ComponentBaseGUI<ICollection<T>> where T : struct
    {
        #region Field

        protected FoldoutPanel foldOutPanel;

        #endregion Field

        #region Property

        public virtual T MinValue { get; set; }

        public virtual T MaxValue { get; set; }

        public float TextFieldWidth { get; set; }

        public bool WithSlider { get; set; }

        #endregion Property

        #region Constructor

        public ValuesGUI()
        {
            this.foldOutPanel = new FoldoutPanel();
        }

        #endregion Constructor
    }
}