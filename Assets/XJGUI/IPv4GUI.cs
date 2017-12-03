using UnityEngine;

namespace XJGUI
{
    public class IPv4GUI : BaseGUI<string>
    {
        #region Field

        private IntGUI x;
        private IntGUI y;
        private IntGUI z;
        private IntGUI w;

        #endregion Field

        #region Property

        public override string Value
        {
            get
            {
                return base.value;
            }
            set
            {
                int[] values = ParseIPAddressText(value);
                this.x.Value = values[0];
                this.y.Value = values[1];
                this.z.Value = values[2];
                this.w.Value = values[3];
                base.value   = values[0] + "." + values[1] + "." + values[2] + "." + values[3];
            }
        }

        #endregion Property

        #region Constructor

        public IPv4GUI()
        {
            const int IPV4_VALUE_MIN = 0;
            const int IPV4_VALUE_MAX = 255;

            int[] values = ParseIPAddressText(base.value);

            this.x = new IntGUI()
            {
                Value = values[0],
                minValue = IPV4_VALUE_MIN,
                maxValue = IPV4_VALUE_MAX,
                withSlider = false
            };

            this.y = new IntGUI()
            {
                Value = values[1],
                minValue = IPV4_VALUE_MIN,
                maxValue = IPV4_VALUE_MAX,
                withSlider = false
            };

            this.z = new IntGUI()
            {
                Value = values[2],
                minValue = IPV4_VALUE_MIN,
                maxValue = IPV4_VALUE_MAX,
                withSlider = false
            };

            this.w = new IntGUI()
            {
                Value = values[3],
                minValue = IPV4_VALUE_MIN,
                maxValue = IPV4_VALUE_MAX,
                withSlider = false
            };

            base.value = x.Value + "." + y.Value + "." + z.Value + "." + w.Value;
        }

        #endregion Constructor

        #region Method

        protected virtual int[] ParseIPAddressText(string ipAddressText)
        {
            string[] values = ipAddressText.Split('.');

            int[] intValues = new int[4];

            for (int i = 0; i < 4; i++)
            {
                intValues[i] = 0;
            }

            for(int i = 0; i < values.Length && i < 4; i++)
            {
                int intValue = 0;
                int.TryParse(values[i], out intValue);
                intValues[i] = intValue;
            }

            return intValues;
        }

        public string Show()
        {
            XJGUILayout.VerticalLayout(() => 
            {
                base.ShowTitle();

                XJGUILayout.HorizontalLayout(() => 
                {
                    int x = this.x.Show();
                    GUILayout.Label(".");

                    int y = this.y.Show();
                    GUILayout.Label(".");

                    int z = this.z.Show();
                    GUILayout.Label(".");

                    int w = this.w.Show();

                    this.value = x + "." + y + "." + z + "." + w;
                });
            });

            return base.value;
        }
    }
        #endregion Method
}