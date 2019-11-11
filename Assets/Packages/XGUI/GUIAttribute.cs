using System;

namespace XGUI
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GUIAttribute : Attribute
    {
        #region Property

        public bool   Hide     { get; set; } = false;
        public string Title    { get; set; } = null;
        public float  Width    { get; set; } = float.NaN;
        public float  MinValue { get; set; } = float.NaN;
        public float  MaxValue { get; set; } = float.NaN;

        #endregion Property
    }
}