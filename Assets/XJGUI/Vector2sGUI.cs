using UnityEngine;

namespace XJGUI
{
    public class Vector2sGUI : ValuesGUI<Vector2>
    {
        #region Method

        protected override ValueGUI<Vector2> GenerateValueGUI()
        {
            return new Vector2GUI()
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