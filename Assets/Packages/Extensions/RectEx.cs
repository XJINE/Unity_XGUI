using UnityEngine;

/// <summary>
/// Rect に関する拡張機能を実装します.
/// </summary>
public static class RectEx
{
    #region Extension

    /// <summary>
    /// 指定する Rect が含まれるかどうかを検証します.
    /// </summary>
    /// <param name="rect1">
    /// rect2 を含むか検証する Rect.
    /// </param>
    /// <param name="rect2">
    /// rect1 に含まれるか検証する Rect.
    /// </param>
    /// <returns>
    /// 含まれるとき true, 含まれないとき false.
    /// </returns>
    public static bool Contains(this Rect rect1, Rect rect2)
    {
        return rect1.Contains(rect2.min) && rect1.Contains(rect2.max);
    }

    #region Get Point

    /// <summary>
    /// Rect 内のランダムな座標を取得します.
    /// </summary>
    /// <param name="rect">
    /// 座標を取得する Rect.
    /// </param>
    /// <returns>
    /// Rect 内に収まる座標.
    /// </returns>
    public static Vector2 GetRandomPoint(this Rect rect)
    {
        return Vector2Ex.Random(rect.min, rect.max);
    }

    /// <summary>
    /// 左上の座標を取得します.
    /// </summary>
    /// <param name="rect">
    /// 座標を取得する Rect.
    /// </param>
    /// <returns>
    /// 左上の座標.
    /// </returns>
    public static Vector2 GetTopLeftPoint(this Rect rect)
    {
        return new Vector2(rect.xMin, rect.yMax);
    }

    /// <summary>
    /// 右上の座標を取得します.
    /// </summary>
    /// <param name="rect">
    /// 座標を取得する Rect.
    /// </param>
    /// <returns>
    /// 右上の座標.
    /// </returns>
    public static Vector2 GetTopRightPoint(this Rect rect)
    {
        return new Vector2(rect.xMax, rect.yMax);
    }

    /// <summary>
    /// 左下の座標を取得します.
    /// </summary>
    /// <param name="rect">
    /// 座標を取得する Rect.
    /// </param>
    /// <returns>
    /// 左下の座標.
    /// </returns>
    public static Vector2 GetBottomLeftPoint(this Rect rect)
    {
        return new Vector2(rect.xMin, rect.yMin);
    }

    /// <summary>
    /// 右下の座標を取得します.
    /// </summary>
    /// <param name="rect">
    /// 座標を取得する Rect.
    /// </param>
    /// <returns>
    /// 右下の座標.
    /// </returns>
    public static Vector2 GetBottomRightPoint(this Rect rect)
    {
        return new Vector2(rect.xMax, rect.yMin);
    }

    #endregion Get Point

    #endregion Extension
}