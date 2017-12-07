using UnityEngine;

namespace XJGUI
{
    public class Vector2sGUI : ValuesGUI<Vector2>
    {
        #region Constructor

        public Vector2sGUI()
        {
            base.minValue = new Vector2(float.MinValue, float.MinValue);
            base.maxValue = new Vector2(float.MaxValue, float.MaxValue);
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