using UnityEngine;

/// <summary>
/// Rect に関する拡張機能を実装します.
/// </summary>
public static class RayEx
{
    /// <summary>
    /// From-To となる Ray のインスタンスを生成します.
    /// </summary>
    /// <param name="from">
    /// Ray の原点.
    /// </param>
    /// <param name="to">
    /// Ray の終点.
    /// </param>
    /// <returns>
    /// Ray のインスタンス.
    /// </returns>
    public static Ray CreateFromToRay(Vector3 from, Vector3 to)
    {
        return new Ray(from, to - from);
    }
}