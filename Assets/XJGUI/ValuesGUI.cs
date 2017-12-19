namespace XJGUI
{
    public abstract class ValuesGUI<T> : ElementsGUI<T> where T : struct
    {
        #region Field

        protected T minValue;
        protected T maxValue;
        protected int decimals;
        protected float fieldWidth;
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

                if (base.value == null)
                {
                    return;
                }

                UpdateGUIs();
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

                if (base.value == null)
                {
                    return;
                }

                UpdateGUIs();
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

                if (base.value == null)
                {
                    return;
                }

                UpdateGUIs();
            }
        }

        public virtual float FieldWidth
        {
            get
            {
                return this.fieldWidth;
            }
            set
            {
                this.fieldWidth = value;

                if (base.value == null)
                {
                    return;
                }

                UpdateGUIs();
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

                if (base.value == null)
                {
                    return;
                }

                UpdateGUIs();
            }
        }

        #endregion Property

        #region Constructor

        public ValuesGUI() : base()
        {
            // NOTE:
            // this.minValue & this.maxValue are initialized in inherit constructor.

            this.decimals = XJGUILayout.DefaultDecimals;
            this.fieldWidth = XJGUILayout.DefaultFieldWidth;
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
            valueGUI.FieldWidth = this.FieldWidth;
            valueGUI.WithSlider = this.WithSlider;
        }

        #endregion Method
    }
}