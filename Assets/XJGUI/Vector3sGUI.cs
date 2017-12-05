using UnityEngine;

namespace XJGUI
{
    public class Vector3sGUI : ValuesGUI<Vector3>
    {
        #region Method

        protected override ValueGUI<Vector3> GenerateValueGUI()
        {
            return new Vector3GUI()
            {
                MinValue = base.minValue,
                MaxValue = base.maxValue,
                TextFieldWidth = base.textFieldWidth,
                WithSlider = base.withSlider
            };
        }

        #endregion Method
    }
}