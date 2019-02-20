using System;

namespace XJGUI
{
    public class FieldGUIInfo : Attribute
    {
        #region Property

        public bool    Hide       { get; set; }
        public bool    IPv4       { get; set; }
        public string  Title      { get; set; }
        public float?  FieldWidth { get; set; }
        public object  MinValue   { get; set; }
        public object  MaxValue   { get; set; }
        public int?    Decimals   { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUIInfo() { }

        #endregion constructor
    }
}