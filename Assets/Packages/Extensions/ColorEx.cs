using UnityEngine;

/// <summary>
/// Color に関する拡張機能を実装します。
/// </summary>
public static class ColorEx
{
    #region Default Color

    /// <summary>
    /// 基本的な色の配列です。ただし clear を除きます。
    /// </summary>
    public static Color[] DefaultColors = new Color[]
    {
        Color.black,
        Color.blue,
        Color.cyan,
        Color.gray,
        Color.green,
        Color.magenta,
        Color.red,
        Color.white,
        Color.yellow
    };

    /// <summary>
    /// DefaultColors の数。
    /// </summary>
    public static int DefaultColorsLength = DefaultColors.Length;

    /// <summary>
    /// 基本的な色 (DefaultColors) からランダムな色を取得します。
    /// </summary>
    /// <returns>
    /// 基本的な色から選択されたランダムな色。
    /// </returns>
    public static Color GetRandomDefaultColor()
    {
        return ColorEx.DefaultColors[Random.Range(0, ColorEx.DefaultColorsLength)];
    }

    #endregion Default Color

    /// <summary>
    /// HSV Color に変換します。
    /// </summary>
    /// <param name="rgbColor">
    /// HSV Color に変換する RGB Color.
    /// </param>
    /// <returns>
    /// HSV Color.
    /// </returns>
    public static HSVColor ToHSVColor(this Color rgbColor)
    {
        return new HSVColor(rgbColor);
    }
}