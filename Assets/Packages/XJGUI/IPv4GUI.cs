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

        #region Constructor

        public IPv4GUI() { }

        public IPv4GUI(string title) : base(title) { }

        #endregion Constructor

        #region Method

        protected override void Initialize()
        {
            base.Initialize();

            const int IPV4_VALUE_MIN = 0;
            const int IPV4_VALUE_MAX = 255;

            this.intGUIX = new IntGUI()
            {
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                Slider = false
            };
            this.intGUIY = new IntGUI()
            {
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                Slider = false
            };
            this.intGUIZ = new IntGUI()
            {
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                Slider = false
            };
            this.intGUIW = new IntGUI()
            {
                MinValue   = IPV4_VALUE_MIN,
                MaxValue   = IPV4_VALUE_MAX,
                Slider = false
            };
        }

        public override string Show(string value)
        {
            int[] values = ParseIPv4Text(value);

            XJGUILayout.VerticalLayout(() => 
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() => 
                {
                    value = this.intGUIX.Show(values[0]).ToString();
                    value += ".";

                    GUILayout.Label(".");

                    value += this.intGUIY.Show(values[1]);
                    value += ".";

                    GUILayout.Label(".");

                    value += this.intGUIZ.Show(values[2]);
                    value += ".";

                    GUILayout.Label(".");

                    value += this.intGUIW.Show(values[3]);
                });
            });

            return value;
        }

        protected static int[] ParseIPv4Text(string ipv4Text)
        {
            ipv4Text = ipv4Text ?? "";

            string[] values = ipv4Text.Split('.');

            int[] intValues = new int[4];

            for (int i = 0; i < 4; i++)
            {
                intValues[i] = 0;
            }

            for (int i = 0; i < values.Length && i < 4; i++)
            {
                if (int.TryParse(values[i], out int intValue))
                {
                    intValues[i] = intValue;
                };
            }

            return intValues;
        }

        #endregion Method
    }
}