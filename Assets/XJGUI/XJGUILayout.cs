using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    public static Texture2D TransparentTexture;

    public static bool DefaultHide = false;
    public static bool DefaultHideUnsupportedGUI = true;

    public static string DefaultTitle = null;
    public static bool   DefaultBoldTitle = false;
    public static bool   DefaultWithSlider = true;
    public static int    DefaultDecimals = 2;
    public static float  DefaultFieldWidthValue = 100;
    public static float  DefaultFieldWidthString = 150;

    public static int DefaultValueInt = 0;
    public static int DefaultMinValueInt = -50;
    public static int DefaultMaxValueInt = 50;

    public static float DefaultValueFloat = 0;
    public static float DefaultMinValueFloat = -50;
    public static float DefaultMaxValueFloat = 50;

    public static Vector2 DefaultValueVector2 = new Vector2(0, 0);
    public static Vector2 DefaultMinValueVector2 = new Vector2(-50, -50);
    public static Vector2 DefaultMaxValueVector2 = new Vector2(50, 50);

    public static Vector3 DefaultValueVector3 = new Vector3(0, 0, 0);
    public static Vector3 DefaultMinValueVector3 = new Vector3(-50, -50, -50);
    public static Vector3 DefaultMaxValueVector3 = new Vector3(50, 50, 50);

    public static Vector4 DefaultValueVector4 = new Vector4(0, 0, 0, 0);
    public static Vector4 DefaultMinValueVector4 = new Vector4(-50, -50, -50, -50);
    public static Vector4 DefaultMaxValueVector4 = new Vector4(50, 50, 50, 50);

    public static Color DefaultValueColor = new Color(0, 0, 0, 1);
    public static Color DefaultMinValueColor = new Color(0, 0, 0, 0);
    public static Color DefaultMaxValueColor = new Color(1, 1, 1, 1);
    public static bool  DefaultHSV = false;

    public static bool   DefaultIPv4 = false;
    public static string DefaultIPv4Value = "0.0.0.0";

    public static bool  DefaultSync = true;
    public static Color DefaultSyncColorServer = new Color(0, 1f, 0f);
    public static Color DefaultSyncColorClient = new Color(1f, 1f, 0f);

    #endregion Field

    #region Constructor

    static XJGUILayout()
    {
        XJGUILayout.TransparentTexture = GenerateBackgroundTexture(Color.clear);
    }

    #endregion Constructor

    #region Method

    public static void HorizontalLayout(Action guiAction)
    {
        GUILayout.BeginHorizontal();
        {
            guiAction();
        }
        GUILayout.EndHorizontal();
    }

    public static void VerticalLayout(Action guiAction)
    {
        GUILayout.BeginVertical();
        {
            guiAction();
        }
        GUILayout.EndVertical();
    }

    private static Texture2D GenerateBackgroundTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.SetPixel(0, 0, color);
        texture.Apply();

        return texture;
    }

    private static void SetColorToBackgroundTexture(Texture2D backgroundTexture, Color color)
    {
        backgroundTexture.SetPixel(0, 0, color);
        backgroundTexture.Apply();
    }

    #endregion Method
}