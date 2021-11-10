namespace XGUIs
{
    public class XGUI<T> : ElementGUI<T>
    {
        #region Field

        private ElementGUI<T> _gui;

        #endregion Field

        #region Property

        public T MinValue
        {
            get => (T)GetProperty("MinValue");
            set => SetProperty("MinValue", value);
        }

        public T MaxValue
        {
            get => (T)GetProperty("MaxValue");
            set => SetProperty("MaxValue", value);
        }

        public int Digits
        {
            get => (int)GetProperty("Digits");
            set => SetProperty("Digits", value);
        }

        public float Width
        {
            get => (float)GetProperty("Width");
            set => SetProperty("Width", value);
        }

        public bool Slider
        {
            get => (bool)GetProperty("Slider");
            set => SetProperty("Slider", value);
        }

        #endregion Proerty

        #region Constructor

        public XGUI() { }

        public XGUI(string title) : base(title) { }

        public XGUI(string title, T minValue, T maxValue) : base(title)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public XGUI(string title, T minValue, T maxValue, int digits) : this (title, minValue, maxValue)
        {
            Digits = digits;
        }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            _gui = (ElementGUI<T>)ReflectionHelper.GenerateGUI(TypeInfo.GetTypeInfo(typeof(T)), Title);
        }

        public override T Show(T value)
        {
            return _gui.Show(value);
        }

        private void SetProperty(string propertyName, object value)
        {
            var property = _gui.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return;
            }

            try
            {
                property.SetValue(_gui, value);
            }
            catch
            {
                // ignored
            }
        }

        private object GetProperty(string propertyName)
        {
            var property = _gui.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return null;
            }

            try
            {
               return property.GetValue(_gui);
            }
            catch
            {
                return null;
            }
        }

        #endregion Method
    }
}
