using UnityEngine;

namespace XJGUI
{
    public class Vector4sGUI : ValuesGUI<Vector4>
    {
        #region Constructor

        public Vector4sGUI()
        {
            base.minValue = XJGUILayout.DefaultMinValueVector4;
            base.maxValue = XJGUILayout.DefaultMaxValueVector4;
        }

        #endregion Constructor

        #region Method

        protected override ElementGUI<Vector4> GenerateGUI()
        {
            return new Vector4GUI();
        }

        #endregion Method
    }
}