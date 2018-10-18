namespace XJGUI
{
    public class StringsGUI : ElementsGUI<string>
    {
        #region Field

        protected float fieldWidth;

        #endregion Field

        public virtual float FieldWidth
        {
            get
            {
                return this.fieldWidth;
            }
            set
            {
                this.fieldWidth = value;

                if (base.value != null)
                {
                    UpdateGUIs();
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
            this.fieldWidth = XJGUILayout.DefaultFieldWidth;
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