using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    #region FlexibleWindow Settings

    public static float DefaultWindowMinWidth    = 500;
    public static float DefaultWindowMinHeight   = 300;
    public static float DefaultWindowMaxWidth    = 1000;
    public static float DefaultWindowMaxHeight   = 800;
    public static bool  DefaultWindowIsDraggable = true;
    public static bool  DefaultWindowIsVisible   = true;

    #endregion FlexibleWindow Settings

    #region Default GUI Settings

    public static string DefaultTitle             = null;
    public static int    DefaultFieldWidthString  = 100;
    public static int    DefaultFieldWidthValue   = 100;
    public static float  DefaultButtonWidth       = 100;
    public static int    DefaultDecimals          = 4;
    public static bool   DefaultWithSlider        = true;
    public static Color  DefaultInvalidValueColor = new Color(1, 0, 0, 1);

    #endregion Default GUI Settings

    #region Default Value Settings

    public static bool   DefaultValueBool   = false;
    public static string DefaultValueString = null;

    public static int DefaultValueInt    = 0;
    public static int DefaultMinValueInt = -999;
    public static int DefaultMaxValueInt = 999;

    public static float DefaultValueFloat    = 0;
    public static float DefaultMinValueFloat = -999;
    public static float DefaultMaxValueFloat = 999;

    public static Vector2 DefaultValueVector2    = new Vector2(0, 0);
    public static Vector2 DefaultMinValueVector2 = new Vector2(-50, -50);
    public static Vector2 DefaultMaxValueVector2 = new Vector2(50, 50);

    public static Vector3 DefaultValueVector3    = new Vector3(0, 0, 0);
    public static Vector3 DefaultMinValueVector3 = new Vector3(-50, -50, -50);
    public static Vector3 DefaultMaxValueVector3 = new Vector3(50, 50, 50);

    public static Vector4 DefaultValueVector4    = new Vector4(0, 0, 0, 0);
    public static Vector4 DefaultMinValueVector4 = new Vector4(-50, -50, -50, -50);
    public static Vector4 DefaultMaxValueVector4 = new Vector4(50, 50, 50, 50);

    public static Vector2Int DefaultValueVector2Int    = new Vector2Int(0, 0);
    public static Vector2Int DefaultMinValueVector2Int = new Vector2Int(-50, -50);
    public static Vector2Int DefaultMaxValueVector2Int = new Vector2Int(50, 50);

    public static Vector3Int DefaultValueVector3Int    = new Vector3Int(0, 0, 0);
    public static Vector3Int DefaultMinValueVector3Int = new Vector3Int(-50, -50, -50);
    public static Vector3Int DefaultMaxValueVector3Int = new Vector3Int(50, 50, 50);

    public static Color DefaultValueColor    = new Color(0, 0, 0, 1);
    public static Color DefaultMinValueColor = new Color(0, 0, 0, 0);
    public static Color DefaultMaxValueColor = new Color(1, 1, 1, 1);

    public static Matrix4x4 DefaultValueMatrix4x4    = new Matrix4x4();
    public static Matrix4x4 DefaultMinValueMatrix4x4 = new Matrix4x4(new Vector4(-999, -999, -999, -999),
                                                                     new Vector4(-999, -999, -999, -999),
                                                                     new Vector4(-999, -999, -999, -999),
                                                                     new Vector4(-999, -999, -999, -999));
    public static Matrix4x4 DefaultMaxValueMatrix4x4 = new Matrix4x4(new Vector4(999, 999, 999, 999),
                                                                     new Vector4(999, 999, 999, 999),
                                                                     new Vector4(999, 999, 999, 999),
                                                                     new Vector4(999, 999, 999, 999));

    public static bool   DefaultIPv4      = false;
    public static string DefaultValueIPv4 = "0.0.0.0";

    #endregion Value Settings

    #region FieldGUI Settings

    public static bool DefaultHideUnsupportedGUI = true;
    public static bool DefaultFieldGUIFoldout = false;

    #endregion FieldGUI Settings

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
        GUILayout.Label(text, new GUIStyle(GUI.skin.label)
        {
            wordWrap  = !option.HasFlag(LabelOption.NoWrap),
            fontStyle = option.HasFlag(LabelOption.Bold) ? FontStyle.Bold : FontStyle.Normal
        });
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