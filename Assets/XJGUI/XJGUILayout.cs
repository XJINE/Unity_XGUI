using System;
using UnityEngine;

public static class XJGUILayout
{
    #region Field

    public static Texture2D TransparentTexture;

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