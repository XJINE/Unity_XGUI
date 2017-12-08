using UnityEngine;

namespace XJGUI
{
    public class Vector2sGUI : ValuesGUI<Vector2>
    {
        #region Constructor

        public Vector2sGUI()
        {
            base.minValue = XJGUILayout.DefaultMinValueVector2;
            base.maxValue = XJGUILayout.DefaultMaxValueVector2;
        }

        #endregion Constructor

        #region Method

        protected override ValueGUI<Vector2> GenerateValueGUI()
        {
            return new Vector2GUI();
        }

        #endregion Method
    }
}