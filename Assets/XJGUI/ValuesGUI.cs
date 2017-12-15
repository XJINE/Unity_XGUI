namespace XJGUI
{
    public abstract class ValuesGUI<T> : ElementsGUI<T> where T : struct
    {
        #region Field

        protected T minValue;
        protected T maxValue;
        protected int decimals;
        protected float textFieldWidth;
        protected bool withSlider;

        #endregion Field

        #region Property

        public virtual T MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                this.minValue = value;

                if (base.value == null || CheckGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    ((ValueGUI<T>)base.guis[i]).MinValue = value;
                }
            }
        }

        public virtual T MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                this.maxValue = value;

                if (base.value == null || CheckGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    ((ValueGUI<T>)base.guis[i]).MaxValue = value;
                }
            }
        }

        public virtual int Decimals
        {
            get
            {
                return this.decimals;
            }
            set
            {
                this.decimals = value;

                if (base.value == null || CheckGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    ((ValueGUI<T>)base.guis[i]).Decimals = value;
                }
            }
        }

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
                    ((ValueGUI<T>)base.guis[i]).TextFieldWidth = value;
                }
            }
        }

        public virtual bool WithSlider
        {
            get
            {
                return this.withSlider;
            }
            set
            {
                this.withSlider = value;

                if (base.value == null || CheckGUIsUpdate())
                {
                    return;
                }

                for (int i = 0; i < base.value.Count; i++)
                {
                    ((ValueGUI<T>)base.guis[i]).WithSlider = value;
                }
            }
        }

        #endregion Property

        #region Constructor

        public ValuesGUI() : base()
        {
            // NOTE:
            // this.minValue & this.maxValue are initialized in inherit constructor.

            this.decimals = XJGUILayout.DefaultDecimals;
            this.textFieldWidth = XJGUILayout.DefaultFieldWidthValue;
            this.withSlider = XJGUILayout.DefaultWithSlider;
        }

        #endregion Constructor

        #region Method

        protected override void InitializeGUI(ElementGUI<T> gui)
        {
            base.InitializeGUI(gui);
            ValueGUI<T> valueGUI = (ValueGUI<T>)gui;
            valueGUI.MinValue = this.MinValue;
            valueGUI.MaxValue = this.MaxValue;
            valueGUI.Decimals = this.Decimals;
            valueGUI.TextFieldWidth = this.TextFieldWidth;
            valueGUI.WithSlider = this.WithSlider;
        }

        #endregion Method
    }
}