using UnityEngine;

/// <summary>
/// Gizmo に関する拡張機能を実装します。
/// </summary>
public static class GizmosEx
{
    /// <summary>
    /// 十字を描画します。
    /// </summary>
    /// <param name="center">
    /// 十字を描画する場所。
    /// </param>
    /// <param name="lineLength">
    /// 十字の線の長さ。
    /// </param>
    public static void DrawCross(Vector3 center, float lineLength)
    {
        Vector3 from = center;
        Vector3 to   = center;
        float halfLength = lineLength / 2f;

        from.x = from.x - halfLength;
        to.x   = to.x   + halfLength;

        Gizmos.DrawLine(from, to);

        from = center;
        to   = center;

        from.y = from.y - halfLength;
        to.y   = to.y   + halfLength;

        Gizmos.DrawLine(from, to);
    }

    /// <summary>
    /// 矢印を描画します。矢印は from から from + direction まで伸びます。
    /// </summary>
    /// <param name="from">
    /// 矢印の開始位置。
    /// </param>
    /// <param name="direction">
    /// 矢印の方向と長さ。
    /// </param>
    /// <param name="headAngle">
    /// 矢印の先端の角度。
    /// </param>
    public static void DrawArrow(Vector3 from, Vector3 direction, float headAngle = 15)
    {
        Gizmos.DrawRay(from, direction);

        float headLength = Vector3.Distance(from, from + direction) / 3;

        Vector3 up    = Quaternion.LookRotation(direction) * Quaternion.Euler(0,  headAngle, 0) * Vector3.back;
        Vector3 down  = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -headAngle, 0) * Vector3.back;
        Vector3 left  = Quaternion.LookRotation(direction) * Quaternion.Euler(-headAngle, 0, 0) * Vector3.back;
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler( headAngle, 0, 0) * Vector3.back;

        Gizmos.DrawRay(from + direction, right * headLength);
        Gizmos.DrawRay(from + direction, left * headLength);
        Gizmos.DrawRay(from + direction, up * headLength);
        Gizmos.DrawRay(from + direction, down * headLength);
    }

    #region Save / Load

    /// <summary>
    /// キャッシュした Gizmo の色。
    /// </summary>
    private static Color CachedGizmoColor;

    /// <summary>
    /// キャッシュした Gizmo の Matrix4x4 。
    /// </summary>
    private static Matrix4x4 CachedGizmoMatrix;

    /// <summary>
    /// Gizmo の色を 1 つだけ保存します。
    /// </summary>
    public static void SaveColor()
    {
        GizmosEx.CachedGizmoColor = Gizmos.color;
    }

    /// <summary>
    /// 保存した Gizmo の色を復元します。
    /// </summary>
    public static void LoadColor()
    {
        Gizmos.color = GizmosEx.CachedGizmoColor;
    }

    /// <summary>
    /// Gizmo の Matrix を 1 つだけ保存します。
    /// </summary>
    public static void SaveMatrix()
    {
        GizmosEx.CachedGizmoMatrix = Gizmos.matrix;
    }

    /// <summary>
    /// 保存した Gizmo の Matrix を復元します。
    /// </summary>
    public static void LoadMatrix()
    {
        Gizmos.matrix = GizmosEx.CachedGizmoMatrix;
    }

    #endregion Save / Load
}