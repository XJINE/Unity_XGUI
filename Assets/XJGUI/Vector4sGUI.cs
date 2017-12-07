using UnityEngine;

namespace XJGUI
{
    public class Vector4sGUI : ValuesGUI<Vector4>
    {
        #region Constructor

        public Vector4sGUI()
        {
            base.minValue = new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
            base.maxValue = new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        }

        #endregion Constructor

        #region Method

        protected override ValueGUI<Vector4> GenerateValueGUI()
        {
            return new Vector4GUI();
        }

        #endregion Method
    }
}