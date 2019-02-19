using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    #region FlexibleWindow Settings

    public static float DefaultWindowMinWidth    = 300;
    public static float DefaultWindowMinHeight   = 300;
    public static float DefaultWindowMaxWidth    = 1000;
    public static float DefaultWindowMaxHeight   = 800;
    public static bool  DefaultWindowIsDraggable = true;
    public static bool  DefaultWindowIsVisible   = true;

    #endregion FlexibleWindow Settings

    #region ComponentGUI Settings

    public static string DefaultTitle     = null;
    public static bool   DefaultBoldTitle = false;

    #endregion ComponentGUI Settings

    #region TextFieldGUI Settings

    public static int DefaultFieldWidthString = 100;
    public static int DefaultFieldWidthValue  = 100;

    #endregion TextFieldGUI Settings

    #region ValueGUI Settings

    public static float DefaultButtonWidth       = 100;
    public static Color DefaultInvalidValueColor = new Color(1, 0, 0, 1);

    public static int  DefaultDecimals   = 4;
    public static bool DefaultWithSlider = true;

    #endregion ValueGUI Settings

    #region Default Value Settings

    public static string DefaultValueString = null;

    public static int DefaultValueInt    = 0;
    public static int DefaultMinValueInt = -999;
    public static int DefaultMaxValueInt = 999;

    public static float DefaultValueFloat    = 0;
    public static float DefaultMinValueFloat = -999;
    public static float DefaultMaxValueFloat = 999;

    public static bool DefaultValueBool   = false;

    public static Vector2 DefaultValueVector2    = new Vector2(0, 0);
    public static Vector2 DefaultMinValueVector2 = new Vector2(-50, -50);
    public static Vector2 DefaultMaxValueVector2 = new Vector2(50, 50);

    public static Vector3 DefaultValueVector3    = new Vector3(0, 0, 0);
    public static Vector3 DefaultMinValueVector3 = new Vector3(-50, -50, -50);
    public static Vector3 DefaultMaxValueVector3 = new Vector3(50, 50, 50);

    public static Vector4 DefaultValueVector4    = new Vector4(0, 0, 0, 0);
    public static Vector4 DefaultMinValueVector4 = new Vector4(-50, -50, -50, -50);
    public static Vector4 DefaultMaxValueVector4 = new Vector4(50, 50, 50, 50);

    public static bool  DefaultHSV           = false;
    public static Color DefaultValueColor    = new Color(0, 0, 0, 1);
    public static Color DefaultMinValueColor = new Color(0, 0, 0, 0);
    public static Color DefaultMaxValueColor = new Color(1, 1, 1, 1);

    public static bool   DefaultIPv4      = false;
    public static string DefaultValueIPv4 = "0.0.0.0";

    #endregion Value Settings

    #region FieldGUI Settings

    public static bool DefaultHide               = false;
    public static bool DefaultHideUnsupportedGUI = true;

    #endregion FieldGUI Settings

    #region Sync Settings

    public static bool  DefaultSync                 = true;
    public static Color DefaultTitleColor           = new Color(1, 1, 1);
    public static Color DefaultTitleColorSyncServer = new Color(0, 1f, 0f);
    public static Color DefaultTitleColorSyncClient = new Color(1f, 1f, 0f);

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

    #endregion Method
}