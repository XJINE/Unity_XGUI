using UnityEngine;

/// <summary>
/// Bounds の拡張メソッドやユーティリティメソッドを実装します.
/// </summary>
public static class BoundsEx
{
    #region Extension

    /// <summary>
    /// 指定する Bounds が含まれるかどうかを検証します.
    /// </summary>
    /// <param name="bounds1">
    /// bounds2 を含むか検証する Bounds.
    /// </param>
    /// <param name="bounds2">
    /// bounds1 に含まれるか検証する Bounds.
    /// </param>
    /// <returns>
    /// 含まれるとき true, 含まれないとき false.
    /// </returns>
    public static bool Contains(this Bounds bounds1, Bounds bounds2)
    {
        return bounds1.Contains(bounds2.min) && bounds1.Contains(bounds2.max);
    }

    /// <summary>
    /// 指定する Bounds が重なっているかどうかを検証します.
    /// (一方の Bounds の点が、もう一方の Bounds のいずれかに含まれるかどうか、あるいはその逆を検証します.)
    /// </summary>
    /// <param name="bounds1">
    /// 重なるかどうかを検証する Bounds.
    /// </param>
    /// <param name="bounds2">
    /// 重なるかどうかを検証する Bounds.
    /// </param>
    /// <returns></returns>
    public static bool Overlaps(this Bounds bounds1, Bounds bounds2)
    {
        Vector3[] bounds1CornerPoints = bounds1.GetCornerPoints();

        for (int i = 0; i < 8; i++)
        {
            if (bounds2.Contains(bounds1CornerPoints[i]))
            {
                return true;
            }
        }

        Vector3[] bounds2CornerPoints = bounds2.GetCornerPoints();

        for (int i = 0; i < 8; i++)
        {
            if (bounds1.Contains(bounds2CornerPoints[i]))
            {
                return true;
            }
        }

        return false;
    }

    #region Distance

    /// <summary>
    /// 中心の距離を算出して取得します.
    /// </summary>
    /// <param name="self">
    /// 中心を算出する Bounds A.
    /// </param>
    /// <param name="bounds">
    /// 中心を算出する Bounds B.
    /// </param>
    /// <returns>
    /// 2 つの Bounds の中心の距離.
    /// </returns>
    public static float DistanceCenter(this Bounds self, Bounds bounds)
    {
        return Vector3.Distance(self.center, bounds.center);
    }

    /// <summary>
    /// 中心の X 軸の距離を算出して取得します.
    /// </summary>
    /// <param name="self">
    /// 中心を算出する Bounds A.
    /// </param>
    /// <param name="bounds">
    /// 中心を算出する Bounds B.
    /// </param>
    /// <returns>
    /// 2 つの Bounds の中心の距離.
    /// </returns>
    public static float DistanceCenterX(this Bounds self, Bounds bounds)
    {
        return Mathf.Abs(self.center.y - bounds.center.y);
    }

    /// <summary>
    /// 中心の Y 軸の距離を算出して取得します.
    /// </summary>
    /// <param name="self">
    /// 中心を算出する Bounds A.
    /// </param>
    /// <param name="bounds">
    /// 中心を算出する Bounds B.
    /// </param>
    /// <returns>
    /// 2 つの Bounds の中心の距離.
    /// </returns>
    public static float DistanceCenterY(this Bounds self, Bounds bounds)
    {
        return Mathf.Abs(self.center.x - bounds.center.x);
    }

    /// <summary>
    /// 中心の Z 軸の距離を算出して取得します.
    /// </summary>
    /// <param name="self">
    /// 中心を算出する Bounds A.
    /// </param>
    /// <param name="bounds">
    /// 中心を算出する Bounds B.
    /// </param>
    /// <returns>
    /// 2 つの Bounds の中心の距離.
    /// </returns>
    public static float DistanceCenterZ(this Bounds self, Bounds bounds)
    {
        return Mathf.Abs(self.center.z - bounds.center.z);
    }

    #endregion Distance

    #region Get Point

    /// <summary>
    /// Bounds 内のランダムな座標を取得します.
    /// </summary>
    /// <param name="bounds">
    /// ランダムな座標を取得する領域.
    /// </param>
    /// <returns>
    /// bounds 内のランダムな座標.
    /// </returns>
    public static Vector3 GetRandomPoint(this Bounds bounds)
    {
        return Vector3Ex.Random(bounds.min, bounds.max);
    }

    /// <summary>
    /// 正面左上、正面右上、正面左下、正面右下、後面左上、後面右上、後面左下、後面右下、の順になった頂点の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 正面左上、正面右上、正面左下、正面右下、後面左上、後面右上、後面左下、後面右下、の順になった頂点の座標.
    /// </returns>
    public static Vector3[] GetCornerPoints(this Bounds bounds)
    {
        return new Vector3[]
        {
            GetFrontTopLeftPoint(bounds),
            GetFrontTopRightPoint(bounds),
            GetFrontBottomLeftPoint(bounds),
            GetFrontBottomRightPoint(bounds),
            GetBackTopLeftPoint(bounds),
            GetBackTopRightPoint(bounds),
            GetBackBottomLeftPoint(bounds),
            GetBackBottomRightPoint(bounds),
        };
    }

    /// <summary>
    /// Bounds の前面左上の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 前面左上の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 前面左上の座標.
    /// </returns>
    private static Vector3 GetFrontTopLeftPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x - bounds.extents.x,
            y = bounds.center.y + bounds.extents.y,
            z = bounds.center.z - bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の前面右上の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 前面右上の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 前面右上の座標.
    /// </returns>
    private static Vector3 GetFrontTopRightPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x + bounds.extents.x,
            y = bounds.center.y + bounds.extents.y,
            z = bounds.center.z - bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の前面左下の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 前面左下の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 前面左下の座標.
    /// </returns>
    private static Vector3 GetFrontBottomLeftPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x - bounds.extents.x,
            y = bounds.center.y - bounds.extents.y,
            z = bounds.center.z - bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の前面右下の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 前面右下の座標を取得する Bounds.
    /// </param>
    /// <returns>
    ///前面右下の座標.
    /// </returns>
    private static Vector3 GetFrontBottomRightPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x + bounds.extents.x,
            y = bounds.center.y - bounds.extents.y,
            z = bounds.center.z - bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の背面左上の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 背面左上の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 背面左上の座標.
    /// </returns>
    private static Vector3 GetBackTopLeftPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x - bounds.extents.x,
            y = bounds.center.y + bounds.extents.y,
            z = bounds.center.z + bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の背面右上の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 背面右上の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 背面右上の座標.
    /// </returns>
    private static Vector3 GetBackTopRightPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x + bounds.extents.x,
            y = bounds.center.y + bounds.extents.y,
            z = bounds.center.z + bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の背面左下の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 背面左下の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 背面左下の座標.
    /// </returns>
    private static Vector3 GetBackBottomLeftPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x - bounds.extents.x,
            y = bounds.center.y - bounds.extents.y,
            z = bounds.center.z + bounds.extents.z,
        };
    }

    /// <summary>
    /// Bounds の背面右下の座標を算出して取得します.
    /// </summary>
    /// <param name="bounds">
    /// 背面右下の座標を取得する Bounds.
    /// </param>
    /// <returns>
    /// 背面右下の座標.
    /// </returns>
    private static Vector3 GetBackBottomRightPoint(this Bounds bounds)
    {
        return new Vector3()
        {
            x = bounds.center.x + bounds.extents.x,
            y = bounds.center.y - bounds.extents.y,
            z = bounds.center.z + bounds.extents.z,
        };
    }

    #endregion Get Point

    #endregion Extension
}