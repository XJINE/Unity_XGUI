//using UnityEngine;

//namespace XJGUI
//{
//    public class Vector2GUI : ArrayControllableGUI <Vector2>
//    {
//        #region Field

//        private FloatGUI floatGUIX;
//        private FloatGUI floatGUIY;

//        #endregion Field

//        public Vector2 minValue = new Vector2(float.MinValue, float.MinValue);
//        public Vector2 maxValue = new Vector2(float.MaxValue, float.MaxValue);

//        public float textFieldWidth = -1;
//        public bool withSlider = true;
//        public int decimalPlaces = 2;

//        public override Vector2 Value
//        {
//            get
//            {
//                return base.value;
//            }
//            set
//            {
//                base.value = value;
//                this.floatGUIX.Value = value.x;
//                this.floatGUIY.Value = value.y;
//            }
//        }

//        #region Constructor

//        public Vector2GUI()
//        {
//            this.floatGUIX = new FloatGUI();
//            this.floatGUIY = new FloatGUI();
//        }

//        #endregion Constructor

//        #region Method

//        public override Vector2 Show()
//        {
//            XJGUILayout.VerticalLayout(() => 
//            {
//                base.ShowTitle();

//                if (base.horizontalArray)
//                {
//                    XJGUILayout.HorizontalLayout(() => 
//                    {
//                        this.floatGUIX.Show();
//                        this.floatGUIY.Show();
//                    });
//                }
//                else
//                {
//                    this.floatGUIX.Show();
//                    this.floatGUIY.Show();
//                }
//            });

//            return base.Value;
//        }

//        public void UpdateVector2GUI()
//        {
//            this.floatGUIX.maxValue  = this.maxValue.x;
//            this.floatGUIX.minValue  = this.minValue.y;
//            this.floatGUIX.decimalPlace = this.decimalPlaces;
//            this.floatGUIX.textFieldWidth = this.textFieldWidth;
//            this.floatGUIX.withSlider = this.withSlider;


//            this.floatGUIY.boldTitle = base.boldTitle;
//        }

//        #endregion Method
//    }
//}