using UnityEngine;

/// <summary>
/// Vector3Int に関する拡張機能を実装します。
/// </summary>
public static class Vector3IntEx
{
    #region Field

    /// <summary>
    /// (0, 0, -1) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Back = new Vector3Int(0, 0, -1);

    /// <summary>
    /// (0, -1, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Down = new Vector3Int(0, -1, 0);

    /// <summary>
    /// (0, 0, 1) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Forward = new Vector3Int(0, 0, 1);

    /// <summary>
    /// (-1, 0, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Left = new Vector3Int(-1, 0, 0);

    /// <summary>
    /// (1, 1, 1) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int One = new Vector3Int(1, 1, 1);

    /// <summary>
    /// (1, 0, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Right = new Vector3Int(1, 0, 0);

    /// <summary>
    /// (0, 1, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Up = new Vector3Int(0, 1, 0);

    /// <summary>
    /// (0, 0, 0) を示すインスタンス。
    /// </summary>
    public static readonly Vector3Int Zero = new Vector3Int(0, 0, 0);

    #endregion Field

    #region Method

    /// <summary>
    /// ランダムな数値を与えたインスタンスを生成します。
    /// int 型で指定するとき、最小値を含み、最大値は含まれない点に注意してください。
    /// </summary>
    /// <param name="min">最小値。</param>
    /// <param name="max">最大値。</param>
    /// <returns>
    /// ランダムな数値を与えられたインスタンス。
    /// </returns>
    public static Vector3Int Random(int min, int max)
    {
        return new Vector3Int()
        {
            x = UnityEngine.Random.Range(min, max),
            y = UnityEngine.Random.Range(min, max),
            z = UnityEngine.Random.Range(min, max),
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
    public static Vector3Int Random(Vector3Int min, Vector3Int max)
    {
        return new Vector3Int()
        {
            x = UnityEngine.Random.Range(min.x, max.x),
            y = UnityEngine.Random.Range(min.y, max.y),
            z = UnityEngine.Random.Range(min.z, max.z),
        };
    }

    /// <summary>
    /// 最も長い成分を取得します。
    /// </summary>
    /// <param name="Vector3Int">
    /// 成分を分析する Vector3Int 。
    /// </param>
    /// <param name="value">
    /// 最も長い成分の値。
    /// </param>
    /// <param name="valueAbs">
    /// 最も長い成分の値の絶対値。
    /// </param>
    /// <param name="valueSign">
    /// 最も長い成分の符号。
    /// </param>
    /// <param name="axis">
    /// 最も長い成分の座標軸。
    /// </param>
    public static void GetLongestComponent(this Vector3Int Vector3Int,
                                           out float value,
                                           out float valueAbs,
                                           out float valueSign,
                                           out Axis axis)
    {
        float signX = Mathf.Sign(Vector3Int.x);
        float signY = Mathf.Sign(Vector3Int.y);
        float signZ = Mathf.Sign(Vector3Int.z);

        float absX = Vector3Int.x * signX;
        float absY = Vector3Int.y * signY;
        float absZ = Vector3Int.z * signZ;

        value = Vector3Int.x;
        valueAbs = absX;
        valueSign = signX;
        axis = Axis.X;

        if (valueAbs < absY)
        {
            value = Vector3Int.y;
            valueAbs = absY;
            valueSign = signY;
            axis = Axis.Y;
        }

        if (valueAbs < absZ)
        {
            value = Vector3Int.z;
            valueAbs = absZ;
            valueSign = signZ;
            axis = Axis.Z;
        }
    }

    #endregion Method
}