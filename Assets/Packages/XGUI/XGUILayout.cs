using System;
using System.Collections.Generic;
using System.Linq;
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
    public static int    DefaultDigits            = 4;
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

    #endregion Default Settings

    #region Label

    private static GUIStyle _labelStyle;
    private static GUIStyle LabelStyle
    {
        get
        {
            _labelStyle ??= new GUIStyle(GUI.skin.label);
            return _labelStyle;
        }
    }

    [Flags]
    public enum LabelOption
    {
        Default = 0x0,
        Bold    = 0x1,
        NoWrap  = 0x2,
    }

    #endregion Label

    #endregion Field

    #region Method

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

    public static T SelectionGrid<T>(T value) where T : Enum
    {
        var type = typeof(T);

        if (type.IsEnum)
        {
            return SelectionGrid(value, Enum.GetValues(type).Cast<T>().ToArray());
        }

        return value;
    }

    public static T SelectionGrid<T>(T value, IList<T> values, int xCount = 0)
    {
        var index = Mathf.Max(0, values.IndexOf(value));
        var type  = typeof(T);

        xCount = 0 < xCount ? xCount : values.Count;

        if (type == typeof(string))
        {
            index = GUILayout.SelectionGrid(index, values.Cast<string>().ToArray(), xCount);
        }
        else if (type == typeof(GUIContent))
        {
            index = GUILayout.SelectionGrid(index, values.Cast<GUIContent>().ToArray(), xCount);
        }
        else if (type == typeof(Texture))
        {
            index = GUILayout.SelectionGrid(index, values.Cast<Texture>().ToArray(), xCount);
        }
        else
        {
            index = GUILayout.SelectionGrid(index, values.Select(x => x.ToString()).ToArray(), xCount);
        }

        return values[index];
    }

    public static string GetTitleCase(string title)
    {
        // NOTE:
        // Following case is not good. Only the first character becomes uppercase.
        // return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);

        if (string.IsNullOrEmpty(title))
        {
            return title;
        }

        switch (title.Length)
        {
            case 0:
                return title;
            case 1:
                return new string(new[]{char.ToUpper(title[0])});
        }

        for (var i = 0; i < title.Length - 1; i++)
        {
            if ((char.IsLower(title[i]) && (char.IsUpper(title[i + 1]) || char.IsDigit(title[i + 1])))
             || (char.IsDigit(title[i]) && char.IsUpper(title[i + 1])))
            {
                title = title.Insert(i + 1, " ");
            }
        }

        return char.ToUpper(title[0]) + title.Substring(1);
    }

    #endregion Method
}