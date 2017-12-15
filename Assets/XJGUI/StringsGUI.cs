namespace XJGUI
{
    public class StringsGUI : ElementsGUI<string>
    {
        #region Field

        protected float textFieldWidth;

        #endregion Field

        public virtual float TextFieldWidth
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
                    ((StringGUI)base.guis[i]).TextFieldWidth = value;
                }
            }
        }

        #region Method

        protected override ElementGUI<string> GenerateValueGUI()
        {
            return new StringGUI()
            {
                TextFieldWidth = this.TextFieldWidth
            };
        }

        #endregion Method
    }
}