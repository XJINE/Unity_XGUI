namespace XGUI
{
    public class FlexGUI<T> : ElementGUI<T>
    {
        #region Field

        private ElementGUI<T> _gui;

        #endregion Field

        #region Property

        public override string Title
        {
            get => _gui.Title;
            set => _gui.Title = value;
        }

        // CAUTION:
        // T gets IList or unsupported value in sometimes.
        // So it cant define MinValue/MaxValue type.

        public object MinValue
        {
            get => ReflectionHelper.GetProperty(_gui, "MinValue");
            set => ReflectionHelper.SetProperty(_gui, "MinValue", value);
        }

        public object MaxValue
        {
            get => ReflectionHelper.GetProperty(_gui, "MaxValue");
            set => ReflectionHelper.SetProperty(_gui, "MaxValue", value);
        }

        public int Digits
        {
            get => (int)ReflectionHelper.GetProperty(_gui, "Digits");
            set => ReflectionHelper.SetProperty(_gui, "Digits", value);
        }

        public bool Slider
        {
            get => (bool)ReflectionHelper.GetProperty(_gui, "Slider");
            set => ReflectionHelper.SetProperty(_gui, "Slider", value);
        }

        public float Width
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "Width");
            set => ReflectionHelper.SetProperty(_gui, "Width", value);
        }

        public float Height
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "Height");
            set => ReflectionHelper.SetProperty(_gui, "Height", value);
        }

        public float MinWidth
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "MinWidth");
            set => ReflectionHelper.SetProperty(_gui, "MinWidth", value);
        }

        public float MinHeight
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "MinHeight");
            set => ReflectionHelper.SetProperty(_gui, "MinHeight", value);
        }

        public float MaxWidth
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "MaxWidth");
            set => ReflectionHelper.SetProperty(_gui, "MaxWidth", value);
        }

        public float MaxHeight
        {
            get => (float)ReflectionHelper.GetProperty(_gui, "MaxHeight");
            set => ReflectionHelper.SetProperty(_gui, "MaxHeight", value);
        }

        #endregion Proerty

        #region Constructor

        public FlexGUI() { }

        public FlexGUI(string title) : base(title) { }

        public FlexGUI(string title, object minValue, object maxValue) : base(title)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public FlexGUI(string title, object minValue, object maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }

        public FlexGUI(string title, float minValue, float maxValue) : base(title)
        {
            // NOTE:
            // Setup Min/Max with float value is only available in Constructor.

            var type = typeof(T);
            MinValue = ReflectionHelper.GetMinValue(type, minValue);
            MaxValue = ReflectionHelper.GetMaxValue(type, maxValue);
        }

        public FlexGUI(string title, float minValue, float maxValue, int digits) : this(title, minValue, maxValue)
        {
            Digits = digits;
        }
        
        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();
            _gui = (ElementGUI<T>)ReflectionHelper.GenerateGUI(typeof(T));
        }

        public override T Show(T value)
        {
            return _gui.Show(value);
        }

        #endregion Method
    }
}