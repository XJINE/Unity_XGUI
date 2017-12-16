using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    public static Texture2D TransparentTexture;

    public static bool DefaultHide = false;

    public static string DefaultTitle = null;
    public static bool DefaultBoldTitle = false;
    public static bool DefaultWithSlider = true;
    public static int DefaultDecimals = 2;

    public static float DefaultFieldWidthValue = 100;
    public static float DefaultFieldWidthString = 150;

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

    public static bool DefaultIPv4 = false;
    public static string DefaultIPv4Value = "0.0.0.0";

    public static bool DefaultSync = true;
    public static Color DefaultSyncColor = new Color(0, 1f, 0f);

    #endregion Field

    #region Constructor

    static XJGUILayout()
    {
        XJGUILayout.TransparentTexture = GenerateBackgroundTexture(Color.clear);
        XJGUILayout.TransparentTexture.hideFlags = HideFlags.HideAndDontSave;
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
        int width  = 1;
        int height = 1;

        Color[] pixels = new Color[width * height];

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }

        Texture2D texture = new Texture2D(width, height);
        texture.SetPixels(pixels);
        texture.Apply();

        return texture;
    }

    #endregion Method
}