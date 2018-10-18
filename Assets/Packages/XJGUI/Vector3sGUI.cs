using UnityEngine;

namespace XJGUI
{
    public class Vector3sGUI : ValuesGUI<Vector3>
    {
        #region Constructor

        public Vector3sGUI()
        {
            base.minValue = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            base.maxValue = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        }

        #endregion Constructor

        #region Method

        protected override ElementGUI<Vector3> GenerateGUI()
        {
            return new Vector3GUI();
        }

        #endregion Method
    }
}