using UnityEngine;

namespace XJGUI
{
    public class IPv4GUI : Element<string>
    {
        #region Field

        private IntGUI intGUIX;
        private IntGUI intGUIY;
        private IntGUI intGUIZ;
        private IntGUI intGUIW;

        #endregion Field

        #region Property

        public override string Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                int[] values = ParseIPv4Text(value);

                this.intGUIX.Value = values[0];
                this.intGUIY.Value = values[1];
                this.intGUIZ.Value = values[2];
                this.intGUIW.Value = values[3];

                base.Value = this.intGUIX.Value + "."
                           + this.intGUIY.Value + "."
                           + this.intGUIZ.Value + "."
                           + this.intGUIW.Value;
            }
        }

        #endregion Property

        #region Constructor

        public IPv4GUI() { }

        public IPv4GUI(string title) : base(title) { }

        public IPv4GUI(string title, string value) : base(title, value) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

                        const int IPV4_VALUE_MIN = 0;
            const int IPV4_VALUE_MAX = 255;

            int[] defaultValue = ParseIPv4Text(XJGUILayout.DefaultValueIPv4);

            this.intGUIX = new IntGUI()
            {
                Value      = defaultValue[0],
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                WithSlider = false
            };
            this.intGUIY = new IntGUI()
            {
                Value      = defaultValue[1],
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                WithSlider = false
            };
            this.intGUIZ = new IntGUI()
            {
                Value      = defaultValue[2],
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                WithSlider = false
            };
            this.intGUIW = new IntGUI()
            {
                Value      = defaultValue[3],
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                WithSlider = false
            };

            this.Value = defaultValue[0] + "."
                       + defaultValue[1] + "."
                       + defaultValue[2] + "."
                       + defaultValue[3];
        }

        public override string Show()
        {
            XJGUILayout.VerticalLayout(() => 
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() => 
                {
                    int x = this.intGUIX.Show();

                    GUILayout.Label(".");

                    int y = this.intGUIY.Show();

                    GUILayout.Label(".");

                    int z = this.intGUIZ.Show();

                    GUILayout.Label(".");

                    int w = this.intGUIW.Show();

                    base.Value = x + "." + y + "." + z + "." + w;
                });
            });

            return this.Value;
        }

        protected virtual int[] ParseIPv4Text(string ipv4Text)
        {
            string[] values = ipv4Text.Split('.');

            int[] intValues = new int[4];

            for (int i = 0; i < 4; i++)
            {
                intValues[i] = 0;
            }

            for (int i = 0; i < values.Length && i < 4; i++)
            {
                int intValue = 0;
                int.TryParse(values[i], out intValue);
                intValues[i] = intValue;
            }

            return intValues;
        }

        #endregion Method
    }
}