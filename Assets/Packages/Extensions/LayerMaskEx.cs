using UnityEngine;

/// <summary>
/// LayerMask に関する拡張機能を実装します。
/// </summary>
public static class LayerMaskEx
{
    /// <summary>
    /// 名前の与えられていない Layer の内、最小の Layer のインデックスを取得します。
    /// 既に名前が与えられないまま Layer が利用されているとき不具合が起こる可能性があります。
    /// 取得するインデックスは shiftAmount だけ増加してずらすことができます。
    /// </summary>
    /// <param name="shiftAmount">
    /// 取得するインデックスに加算してずらす量。デフォルトは 0.
    /// </param>
    /// <returns>
    /// 名前の与えられていないレイヤーの、最小のインデックス。
    /// すべてのレイヤーに名前が与えられているとき -1.
    /// </returns>
    public static int GetEmptyLayerIndex(int shiftAmount = 0)
    {
        const int ReservedByUnity3dLayerIndex = 7;
        const int MaxLayerIndex = 31;

        for (int i = ReservedByUnity3dLayerIndex + 1; i <= MaxLayerIndex; i++)
        {
            string layerName = LayerMask.LayerToName(i);

            // null はヒットしないようです(Unity 5.4.x)。

            if (layerName == null || layerName == "")
            {
                return i + shiftAmount;
            }
        }

        return -1;
    }
}