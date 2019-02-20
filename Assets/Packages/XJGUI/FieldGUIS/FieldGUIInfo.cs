﻿using System;
using UnityEngine;

namespace XJGUI
{
    public class FieldGUIInfo : Attribute
    {
        #region Property

        public bool   Hide       { get; set; }
        public string Title      { get; set; }
        public float  FieldWidth { get; set; }
        public float  MinValue   { get; set; }
        public float  MaxValue   { get; set; }
        public int    Decimals   { get; set; }
        public Color  MinColor   { get; set; }
        public Color  MaxColor   { get; set; }
        public bool   IPv4       { get; set; }

        #endregion Property

        #region Constructor

        public FieldGUIInfo()
        {
            this.Title      = XJGUILayout.DefaultTitle;
            this.Decimals   = XJGUILayout.DefaultDecimals;
            this.FieldWidth = XJGUILayout.DefaultFieldWidth;
            this.MinValue   = XJGUILayout.DefaultMinValueFloat;
            this.MaxValue   = XJGUILayout.DefaultMaxValueFloat;
            this.MinColor   = XJGUILayout.DefaultMinValueColor;
            this.MaxColor   = XJGUILayout.DefaultMaxValueColor;
            this.IPv4       = XJGUILayout.DefaultIPv4;
            this.Hide       = XJGUILayout.DefaultHide;
        }

        #endregion constructor
    }
}