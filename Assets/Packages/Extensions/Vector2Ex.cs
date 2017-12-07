using UnityEngine;

/// <summary>
/// Vector2 に関する拡張機能を実装します。
/// </summary>
public static class Vector2Ex
{
    #region Field

    /// <summary>
    /// (0, -1) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 Down = new Vector2(0, -1);

    /// <summary>
    /// (-1, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 Left = new Vector2(-1, 0);

    /// <summary>
    /// (1, 1) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 One = new Vector2(1, 1);

    /// <summary>
    /// (1, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 Right = new Vector2(1, 0);

    /// <summary>
    /// (0, 1) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 Up = new Vector2(0, 1);

    /// <summary>
    /// (0, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector2 Zero = new Vector2(0, 0);

    #endregion Field

    #region Method

    /// <summary>
    /// ランダムな数値を与えたインスタンスを生成します。
    /// int 型で指定するとき、最小値を含み、最大値は含まれない点に注意してください。
    /// </summary>
    /// <param name="min">
    /// 最小値。
    /// </param>
    /// <param name="max">
    /// 最大値。
    /// </param>
    /// <returns>
    /// ランダムな数値を与えられたインスタンス。
    /// </returns>
    public static Vector2 Random(float min, float max)
    {
        return new Vector2()
        {
            x = UnityEngine.Random.Range(min, max),
            y = UnityEngine.Random.Range(min, max)
        };
    }

    /// <summary>
    /// ランダムな数値を与えたインスタンスを生成します。
    /// int 型で指定するとき、最小値を含み、最大値は含まれない点に注意してください。
    /// </summary>
    /// <param name="min">
    /// 最小値。
    /// </param>
    /// <param name="max">
    /// 最大値。
    /// </param>
    /// <returns>
    /// ランダムな数値を与えられたインスタンス。
    /// </returns>
    public static Vector2 Random(int min, int max)
    {
        return new Vector2()
        {
            x = UnityEngine.Random.Range(min, max),
            y = UnityEngine.Random.Range(min, max)
        };
    }

    /// <summary>
    /// ランダムな数値を与えたインスタンスを生成します。
    /// </summary>
    /// <param name="min">
    /// 最小値。
    /// </param>
    /// <param name="max">
    /// 最大値。
    /// </param>
    /// <returns>
    /// ランダムな数値を与えられたインスタンス。
    /// </returns>
    public static Vector2 Random(Vector2 min, Vector2 max)
    {
        return new Vector2()
        {
            x = UnityEngine.Random.Range(min.x, max.x),
            y = UnityEngine.Random.Range(min.y, max.y),
        };
    }

    #endregion Method
}