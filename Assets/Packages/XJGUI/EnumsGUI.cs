using System;

namespace XJGUI
{
    public class EnumsGUI<T> : ElementsGUI<T> where T : IComparable, IFormattable, IConvertible
    {
        #region Method

        protected override ElementGUI<T> GenerateGUI()
        {
            return new EnumGUI<T>();
        }

        #endregion Method
    }
}