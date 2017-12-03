//using System.Collections.Generic;
//using UnityEngine;

//namespace XJGUI
//{
//    public class TestClass<T>
//    {

//    }

//    public class SubClass<T> : TestClass<T[]>
//    {
//        public T test;
//        public T[] tests;
//    }

//    public class RealClass : SubClass<int>
//    {
//        public RealClass()
//        {
//            test = 0;
//            tests = new int[3];
//        }
//    }

//    public class Vector2ArrayGUI : VectorArrayGUI<Vector2>
//    {
//        #region Field

//        private Vector2GUI[] vector2GUIs;

//        private FoldoutPanel foldOutPanel;

//        #endregion Field

//        #region Property

//        public override Vector2 MinValue
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

//        public override Vector2[] MaxValue
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

//        /// <summary>
//        /// 小数点以下の桁数を取得, 設定します.
//        /// </summary>
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

//        /// <summary>
//        /// テキストフィールドの幅を取得, 設定します.
//        /// 0 以下の値を指定するとき, 幅は可変で最大になります.
//        /// </summary>
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

//        /// <summary>
//        /// スライダーの表示を取得, 設定します.
//        /// true のときスライダーを表示します.
//        /// </summary>
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

//        /// <summary>
//        /// 値を取得, 設定します.
//        /// </summary>
//        public Vector2[] Values
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

//        #region Constructor
        
//        public Vector2ArrayGUI(int length)
//        {
//            this.foldOutPanel = new FoldoutPanel() { Value = false };

//            this.vector2GUIs = new Vector2GUI[length];

//            for (int i = 0; i < length; i++)
//            {
//                this.vector2GUIs[i] = new Vector2GUI() { };
//            }
//        }

//        #endregion Constructor

//        #region Method

//        public Vector2[] Show()
//        {
//            XJGUILayout.VerticalLayout(() => 
//            {
//                if (base.Title != null)
//                {
//                    this.foldOutPanel.Show(delegate ()
//                    {
//                        ShowVector2GUIs();
//                    });
//                }
//                else
//                {
//                    ShowVector2GUIs();
//                }
//            });

//            return this.values;
//        }

//        protected virtual void ShowVector2GUIs()
//        {
//            for (int i = 0; i < this.vector2GUIs.Length; i++)
//            {
//                this.values[i] = this.vector2GUIs[i].Show();
//            }
//        }

//        #endregion Method
//    }
//}