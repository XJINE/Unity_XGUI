﻿using System;
using UnityEngine;

public static class XGUILayout
{
    #region Field

    #region FlexWindow Settings

    public static float DefaultWindowMinWidth    = 500;
    public static float DefaultWindowMinHeight   = 300;
    public static float DefaultWindowMaxWidth    = 1000;
    public static float DefaultWindowMaxHeight   = 800;
    public static bool  DefaultWindowIsDraggable = true;
    public static bool  DefaultWindowIsVisible   = true;

    #endregion FlexWindow Settings

    #region Default GUI Settings

    public static string DefaultTitle             = null;
    public static float  DefaultWidth             = 100;
    public static int    DefaultDecimals          = 4;
    public static bool   DefaultSlider            = true;
    public static Color  DefaultInvalidValueColor = new (1, 0, 0, 1);

    #endregion Default GUI Settings

    #region Default Settings

    public static int DefaultMinValueInt = -9999999;
    public static int DefaultMaxValueInt =  9999999;

    public static float DefaultMinValueFloat = -9999999;
    public static float DefaultMaxValueFloat =  9999999;

    public static Vector2 DefaultMinValueVector2 = new (-9999999, -9999999);
    public static Vector2 DefaultMaxValueVector2 = new ( 9999999,  9999999);

    public static Vector3 DefaultMinValueVector3 = new (-9999999, -9999999, -9999999);
    public static Vector3 DefaultMaxValueVector3 = new ( 9999999,  9999999,  9999999);

    public static Vector4 DefaultMinValueVector4 = new (-9999999, -9999999, -9999999, -9999999);
    public static Vector4 DefaultMaxValueVector4 = new ( 9999999,  9999999,  9999999,  9999999);

    public static Vector2Int DefaultMinValueVector2Int = new (-9999999, -9999999);
    public static Vector2Int DefaultMaxValueVector2Int = new ( 9999999,  9999999);

    public static Vector3Int DefaultMinValueVector3Int = new (-50, -50, -50);
    public static Vector3Int DefaultMaxValueVector3Int = new (50, 50, 50);

    public static Color DefaultMinValueColor = new (0, 0, 0, 0);
    public static Color DefaultMaxValueColor = new (1, 1, 1, 1);

    public static Matrix4x4 DefaultMinValueMatrix4x4 = new (new Vector4(-9999999, -9999999, -9999999, -9999999),
                                                            new Vector4(-9999999, -9999999, -9999999, -9999999),
                                                            new Vector4(-9999999, -9999999, -9999999, -9999999),
                                                            new Vector4(-9999999, -9999999, -9999999, -9999999));
    public static Matrix4x4 DefaultMaxValueMatrix4x4 = new (new Vector4( 9999999,  9999999,  9999999,  9999999),
                                                            new Vector4( 9999999,  9999999,  9999999,  9999999),
                                                            new Vector4( 9999999,  9999999,  9999999,  9999999),
                                                            new Vector4( 9999999,  9999999,  9999999,  9999999));
    public static bool DefaultHideUnsupportedGUI = true;

    #endregion Default Settings

    private static GUIStyle _labelStyle;
    private static GUIStyle LabelStyle
    {
        get
        {
            _labelStyle ??= new GUIStyle(GUI.skin.label);
            return _labelStyle;
        }
    }

    #endregion Field

    #region Method

    [Flags]
    public enum LabelOption
    {
        Default = 0x0,
        Bold    = 0x1,
        NoWrap  = 0x2,
    }

    public static void Label(string text, LabelOption option = LabelOption.Default)
    {
        LabelStyle.wordWrap = !option.HasFlag(LabelOption.NoWrap);
        LabelStyle.fontStyle = option.HasFlag(LabelOption.Bold) ? FontStyle.Bold : FontStyle.Normal;

        GUILayout.Label(text, LabelStyle);
    }

    public static void HorizontalLayout(Action guiAction, GUIStyle style = null)
    {
        if (style == null)
        {
            GUILayout.BeginHorizontal();
        }
        else
        {
            GUILayout.BeginHorizontal(style);
        }

        guiAction();

        GUILayout.EndHorizontal();
    }

    public static void VerticalLayout(Action guiAction, GUIStyle style = null)
    {
        if (style == null)
        {
            GUILayout.BeginVertical();
        }
        else
        {
            GUILayout.BeginVertical(style);
        }

        guiAction();

        GUILayout.EndVertical();
    }

    #endregion Method
}