using UnityEngine;

namespace XJGUI
{
    public class Vector4sGUI : ValuesGUI<Vector4>
    {
        #region Method

        protected override ValueGUI<Vector4> GenerateValueGUI()
        {
            return new Vector4GUI()
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