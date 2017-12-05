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
                MinValue = base.MinValue,
                MaxValue = base.MaxValue,
                TextFieldWidth = base.TextFieldWidth,
                WithSlider = base.WithSlider
            };
        }

        #endregion Method
    }
}