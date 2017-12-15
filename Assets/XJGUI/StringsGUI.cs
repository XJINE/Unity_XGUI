namespace XJGUI
{
    public class StringsGUI : ElementsGUI<string>
    {
        #region Field

        protected float textFieldWidth;

        #endregion Field

        public virtual float FieldWidth
        {
            get
            {
                return this.textFieldWidth;
            }
            set
            {
                this.textFieldWidth = value;

                if (base.value == null || CheckGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    ((StringGUI)base.guis[i]).FieldWidth = value;
                }
            }
        }

        #region Constructor

        public StringsGUI() : base()
        {
            this.textFieldWidth = XJGUILayout.DefaultFieldWidthString;
        }

        #endregion Constructor

        #region Method

        protected override ElementGUI<string> GenerateGUI()
        {
            return new StringGUI()
            {
                FieldWidth = this.FieldWidth
            };
        }

        #endregion Method
    }
}