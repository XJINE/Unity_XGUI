using System;
using UnityEngine;

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

        public Color MinColor { get; set; }

        public Color MaxColor { get; set; }

        public bool HSV { get; set; }

        public bool IPv4 { get; set; }

        public bool Toolbar { get; set; }

        public string Group { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUIInfo()
        {
            this.Title      = XJGUILayout.DefaultTitle;
            this.BoldTitle  = XJGUILayout.DefaultBoldTitle;
            this.Decimals   = XJGUILayout.DefaultDecimals;
            this.FieldWidth = XJGUILayout.DefaultFieldWidth;
            this.MinValue   = XJGUILayout.DefaultMinValueFloat;
            this.MaxValue   = XJGUILayout.DefaultMaxValueFloat;
            this.MinColor   = XJGUILayout.DefaultMinValueColor;
            this.MaxColor   = XJGUILayout.DefaultMaxValueColor;
            this.IPv4       = XJGUILayout.DefaultIPv4;
            this.Hide       = XJGUILayout.DefaultHide;
            this.Sync       = XJGUILayout.DefaultSync;
            this.Group      = XJGUILayout.DefaultFieldGUIGroup;
        }

        #endregion constructor
    }
}