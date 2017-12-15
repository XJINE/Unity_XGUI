using System;

namespace XJGUI
{
    public class FieldGUIInfo : Attribute
    {
        #region Property

        public bool Hide { get; set; }

        public bool Sync { get; set; }

        public string Title { get; set; }

        public bool BoldTitle { get; set; }

        public float FieldWidth { get; set; }

        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public int Decimals { get; set; }

        public bool IPv4 { get; set; }

        public bool Toolbar { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUIInfo()
        {
            this.Hide       = XJGUILayout.DefaultHide;
            this.Sync       = XJGUILayout.DefaultSync;
            this.Title      = XJGUILayout.DefaultTitle;
            this.BoldTitle  = XJGUILayout.DefaultBoldTitle;
            this.FieldWidth = XJGUILayout.DefaultFieldWidthString;
            this.MinValue   = XJGUILayout.DefaultMinValueFloat;
            this.MaxValue   = XJGUILayout.DefaultMaxValueFloat;
            this.Decimals   = XJGUILayout.DefaultDecimals;
            this.IPv4       = XJGUILayout.DefaultIPv4;
        }

        #endregion constructor
    }
}