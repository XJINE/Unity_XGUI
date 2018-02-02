using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    #region FlexibleWindow Settings

    public static string DefaultWindowTitle = null;
    public static float  DefaultWindowMinWidth = 300;
    public static float  DefaultWindowMinHeight = 300;
    public static float  DefaultWindowMaxWidth = 1000;
    public static float  DefaultWindowMaxHeight = 800;
    public static bool   DefaultWindowIsDraggable = true;
    public static bool   DefaultWindowIsVisible = true;
    public static string DefaultFieldGUIGroup = null;

    #endregion FlexibleWindow Settings

    #region ComponentGUI Settings

    public static string DefaultTitle = null;
    public static bool   DefaultBoldTitle = false;

    #endregion ComponentGUI Settings

    #region ElementGUI/ValueGUI Settings

    public static int   DefaultDecimals = 2;
    public static float DefaultButtonWidth = 100;
    public static float DefaultFieldWidth = 100;
    public static bool  DefaultWithSlider = true;
    public static Color DefaultInvalidValueColor = new Color(1, 0, 0, 1);

    #endregion ElementGUI/ValueGUI Settings

    #region Value Settings

    public static int DefaultValueInt = 0;
    public static int DefaultMinValueInt = -50;
    public static int DefaultMaxValueInt = 50;

    public static float DefaultValueFloat = 0;
    public static float DefaultMinValueFloat = -50;
    public static float DefaultMaxValueFloat = 50;

    public static bool DefaultValueBool = false;
    public static string DefaultValueString = null;

    public static Vector2 DefaultValueVector2 = new Vector2(0, 0);
    public static Vector2 DefaultMinValueVector2 = new Vector2(-50, -50);
    public static Vector2 DefaultMaxValueVector2 = new Vector2(50, 50);

    public static Vector3 DefaultValueVector3 = new Vector3(0, 0, 0);
    public static Vector3 DefaultMinValueVector3 = new Vector3(-50, -50, -50);
    public static Vector3 DefaultMaxValueVector3 = new Vector3(50, 50, 50);

    public static Vector4 DefaultValueVector4 = new Vector4(0, 0, 0, 0);
    public static Vector4 DefaultMinValueVector4 = new Vector4(-50, -50, -50, -50);
    public static Vector4 DefaultMaxValueVector4 = new Vector4(50, 50, 50, 50);

    public static bool  DefaultHSV = false;
    public static Color DefaultValueColor = new Color(0, 0, 0, 1);
    public static Color DefaultMinValueColor = new Color(0, 0, 0, 0);
    public static Color DefaultMaxValueColor = new Color(1, 1, 1, 1);

    public static bool   DefaultIPv4 = false;
    public static string DefaultValueIPv4 = "0.0.0.0";

    #endregion Value Settings

    #region FieldGUI Settings

    public static bool DefaultHide = false;
    public static bool DefaultHideUnsupportedGUI = true;

    #endregion FieldGUI Settings

    #region Sync Settings

    public static bool  DefaultSync = true;
    public static Color DefaultSyncColorServer = new Color(0, 1f, 0f);
    public static Color DefaultSyncColorClient = new Color(1f, 1f, 0f);

    #endregion Sync Settings

    #endregion Field

    #region Method

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

    internal static Texture2D Generate1x1Texture(Color color)
    {
        // CAUTION:
        // Do not generate Texture2D (or any other resources) in constructor.
        // Unity does not support such operation.

        Texture2D texture = new Texture2D(1, 1);
        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.SetPixel(0, 0, color);
        texture.Apply();

        return texture;
    }

    #endregion Method
}