//namespace XJGUI
//{
//    public abstract class VectorArrayGUI<T> : AbstractGUI<T>
//    {
//        #region Field

//        #endregion Field

//        #region Property

//        public virtual T MinValue
//        {
//            get
//            {
//                return this.vector2GUIs[0].MinValue;
//            }
//            set
//            {
//                int length = this.vector2GUIs.Length;

//                for (int i = 0; i < length; i++)
//                {
//                    this.vector2GUIs[i].MinValue = value;
//                }
//            }
//        }

//        public virtual T MaxValue
//        {
//            get
//            {
//                return this.vector2GUIs[0].MaxValue;
//            }
//            set
//            {
//                int length = this.vector2GUIs.Length;

//                for (int i = 0; i < length; i++)
//                {
//                    this.vector2GUIs[i].MaxValue = value;
//                }
//            }
//        }

//        public int DecimalPlaces
//        {
//            get
//            {
//                return this.vector2GUIs[0].DecimalPlaces;
//            }
//            set
//            {
//                int length = this.vector2GUIs.Length;

//                for (int i = 0; i < length; i++)
//                {
//                    this.vector2GUIs[i].DecimalPlaces = value;
//                }
//            }
//        }

//        public float TextFieldWidth
//        {
//            get
//            {
//                return this.vector2GUIs[0].TextFieldWidth;
//            }
//            set
//            {
//                int length = this.vector2GUIs.Length;

//                for (int i = 0; i < length; i++)
//                {
//                    this.vector2GUIs[i].TextFieldWidth = value;
//                }
//            }
//        }

//        public bool WithSlider
//        {
//            get
//            {
//                return this.vector2GUIs[0].WithSlider;
//            }
//            set
//            {
//                int length = this.vector2GUIs.Length;

//                for (int i = 0; i < length; i++)
//                {
//                    this.vector2GUIs[i].WithSlider = value;
//                }
//            }
//        }

//        public new T[] Value
//        {
//            get
//            {
//                return this.values;
//            }
//            set
//            {
//                int valuesLength = this.values.Length;

//                if (valuesLength != value.Length)
//                {
//                    throw new System.Exception
//                    (string.Format(ErrorMessage.DifferentDataLengthError, "Current Values", "New Values"));
//                }

//                for (int i = 0; i < valuesLength; i++)
//                {
//                    this.values[i] = value[i];
//                    this.vector2GUIs[i].Value = value[i];
//                }
//            }
//        }

//        #endregion Property
//    }
//}